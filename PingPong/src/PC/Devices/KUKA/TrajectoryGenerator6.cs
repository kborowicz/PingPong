﻿using System;

namespace PingPong.KUKA {
    class TrajectoryGenerator6 {

        private class Polynominal {

            private double k0, k1, k2, k3, k4, k5; // Polynominal coefficients

            private double xn, vn, an; // next value, velocity and acceleration

            /// <summary>
            /// Current position
            /// </summary>
            public double X { get; private set; }

            /// <summary>
            /// Current velocity
            /// </summary>
            public double V { get; private set; }

            /// <summary>
            /// Current acceleration
            /// </summary>
            public double A { get; private set; }

            public void UpdateCoefficients(double x0, double x1, double v1, double T) {
                double T1 = T;
                double T2 = T1 * T1;
                double T3 = T1 * T2;
                double T4 = T1 * T3;
                double T5 = T1 * T4;

                k0 = x0;
                k1 = vn;
                k2 = an / 2.0;
                k3 = 1.0 / (2.0 * T3) * (-3.0 * T2 * an - 12.0 * T1 * vn - 8.0 * T1 * v1 + 20.0 * (x1 - x0));
                k4 = 1.0 / (2.0 * T4) * (3.0 * T2 * an + 16.0 * T1 * vn + 14.0 * T1 * v1 - 30.0 * (x1 - x0));
                k5 = 1.0 / (2.0 * T5) * (-T2 * an - 6.0 * T1 * (vn + v1) + 12.0 * (x1 - x0));
            }

            public double GetValueAt(double t) {
                double t1 = t;
                double t2 = t1 * t1;
                double t3 = t1 * t2;
                double t4 = t1 * t3;
                double t5 = t1 * t4;

                X = xn;
                V = vn;
                A = an;

                xn = k5 * t5 + k4 * t4 + k3 * t3 + k2 * t2 + k1 * t1 + k0;
                vn = 5.0 * k5 * t4 + 4.0 * k4 * t3 + 3.0 * k3 * t2 + 2.0 * k2 * t1 + k1;
                an = 20.0 * k5 * t3 + 12.0 * k4 * t2 + 6.0 * k3 * t1 + 2.0 * k2;

                return xn;
            }

            public void Reset(double targetVelocity) {
                V = vn = targetVelocity;
                A = an = 0.0;
            }

        }

        private const double Ts = 0.004;

        private readonly Polynominal polyX = new Polynominal();

        private readonly Polynominal polyY = new Polynominal();

        private readonly Polynominal polyZ = new Polynominal();

        private readonly Polynominal polyA = new Polynominal();

        private readonly Polynominal polyB = new Polynominal();

        private readonly Polynominal polyC = new Polynominal();

        private readonly object syncLock = new object();

        private bool targetPositionReached;

        private RobotVector targetPosition;

        private RobotVector targetVelocity;

        private double targetDuration;

        private double elapsedTime;

        public RobotVector TargetPosition {
            get {
                lock (syncLock) {
                    return targetPosition;
                }
            }
        }

        public bool TargetPositionReached {
            get {
                lock (syncLock) {
                    return targetPositionReached;
                }
            }
        }

        public RobotVector Velocity {
            get {
                lock (syncLock) {
                    return new RobotVector(polyX.V, polyY.V, polyZ.V, polyA.V, polyB.V, polyC.V);
                }
            }
        }

        public RobotVector Acceleration {
            get {
                lock (syncLock) {
                    return new RobotVector(polyX.A, polyY.A, polyZ.A, polyA.A, polyB.A, polyC.A);
                }
            }
        }

        public TrajectoryGenerator6(RobotVector currentPosition) {
            targetPositionReached = true;
            targetPosition = currentPosition;
            targetVelocity = RobotVector.Zero;
            targetDuration = 0.0;
            elapsedTime = 0.0;
        }

        public void SetTargetPosition(RobotVector currentPosition, RobotVector targetPosition, RobotVector targetVelocity, double targetDuration) {
            if (targetDuration <= 0.0) {
                throw new ArgumentException($"Duration value must be greater than 0, get {targetDuration}");
            }

            bool targetPositionChanged = !targetPosition.Compare(this.targetPosition, 0.1, 1);
            bool targetVelocityChanged = !targetVelocity.Compare(this.targetVelocity, 0.1, 1);
            bool targetDurationChanged = targetDuration != this.targetDuration;

            if (targetDurationChanged || targetPositionChanged || targetVelocityChanged) {
                lock (syncLock) {
                    targetPositionReached = false;
                    this.targetPosition = targetPosition;
                    this.targetVelocity = targetVelocity;
                    this.targetDuration = targetDuration;
                    elapsedTime = 0.0;
                }

                polyX.UpdateCoefficients(currentPosition.X, targetPosition.X, targetVelocity.X, targetDuration);
                polyY.UpdateCoefficients(currentPosition.Y, targetPosition.Y, targetVelocity.Y, targetDuration);
                polyZ.UpdateCoefficients(currentPosition.Z, targetPosition.Z, targetVelocity.Z, targetDuration);
                polyA.UpdateCoefficients(currentPosition.A, targetPosition.A, targetVelocity.A, targetDuration);
                polyB.UpdateCoefficients(currentPosition.B, targetPosition.B, targetVelocity.B, targetDuration);
                polyC.UpdateCoefficients(currentPosition.C, targetPosition.C, targetVelocity.C, targetDuration);
            }
        }

        public RobotVector GetNextCorrection() {
            lock (syncLock) {
                if (elapsedTime < targetDuration) {
                    targetPositionReached = false;
                    elapsedTime += Ts;

                    RobotVector nextPosition = new RobotVector(
                        polyX.GetValueAt(elapsedTime),
                        polyY.GetValueAt(elapsedTime),
                        polyZ.GetValueAt(elapsedTime),
                        polyA.GetValueAt(elapsedTime),
                        polyB.GetValueAt(elapsedTime),
                        polyC.GetValueAt(elapsedTime)
                    );

                    RobotVector currentPosition = new RobotVector(
                        polyX.X, polyY.X, polyZ.X, polyA.X, polyB.X, polyC.X
                    );

                    return nextPosition - currentPosition;
                } else {
                    targetPositionReached = true;
                    polyX.Reset(targetVelocity.X);
                    polyY.Reset(targetVelocity.Y);
                    polyZ.Reset(targetVelocity.Z);
                    polyA.Reset(targetVelocity.A);
                    polyB.Reset(targetVelocity.B);
                    polyC.Reset(targetVelocity.C);

                    return RobotVector.Zero;
                }
            }
        }

    }
}