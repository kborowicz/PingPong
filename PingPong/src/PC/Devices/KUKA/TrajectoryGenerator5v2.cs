﻿using System;

namespace PingPong.KUKA {
    class TrajectoryGenerator5v2 {

        private class Polynominal {

            private double k0, k1, k2, k3, k4, k5; // Polynominal coefficients

            private double xn, vn, an; // next value, velocity and acceleration

            /// <summary>
            /// Current (theoretical) position
            /// </summary>
            public double X { get; private set; }

            /// <summary>
            /// Current (theoretical) velocity
            /// </summary>
            public double V { get; private set; }

            /// <summary>
            /// Current (theoretical) acceleration
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

        private readonly RobotVector homePosition;

        private RobotVector reachedPosition;

        private RobotVector targetPosition;

        private RobotVector targetVelocity;

        private double targetDuration;

        private double elapsedTime;

        private bool targetPositionReached;

        public RobotVector TargetPosition {
            get {
                lock (syncLock) {
                    return targetPosition;
                }
            }
        }

        public bool IsTargetPositionReached {
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

        public TrajectoryGenerator5v2(RobotVector homePosition) {
            this.homePosition = homePosition;

            targetPositionReached = true;
            targetPosition = homePosition;
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

                polyX.UpdateCoefficients(currentPosition.X, this.targetPosition.X, this.targetVelocity.X, this.targetDuration);
                polyY.UpdateCoefficients(currentPosition.Y, this.targetPosition.Y, this.targetVelocity.Y, this.targetDuration);
                polyZ.UpdateCoefficients(currentPosition.Z, this.targetPosition.Z, this.targetVelocity.Z, this.targetDuration);
                polyA.UpdateCoefficients(currentPosition.A, this.targetPosition.A, this.targetVelocity.A, this.targetDuration);
                polyB.UpdateCoefficients(currentPosition.B, this.targetPosition.B, this.targetVelocity.B, this.targetDuration);
                polyC.UpdateCoefficients(currentPosition.C, this.targetPosition.C, this.targetVelocity.C, this.targetDuration);
            }
        }

        public RobotVector GetNextValue(RobotVector currentPosition) {
            lock (syncLock) {
                if (!targetPositionReached && elapsedTime < targetDuration) {
                    elapsedTime += Ts;

                    double nx = polyX.GetValueAt(elapsedTime);
                    double ny = polyY.GetValueAt(elapsedTime);
                    double nz = polyZ.GetValueAt(elapsedTime);
                    double na = polyA.GetValueAt(elapsedTime);
                    double nb = polyB.GetValueAt(elapsedTime);
                    double nc = polyC.GetValueAt(elapsedTime);

                    return new RobotVector(nx, ny, nz, na, nb, nc) - homePosition;
                } else {
                    if (!targetPositionReached) {
                        reachedPosition = currentPosition - homePosition;
                    }

                    targetPositionReached = true;
                    polyX.Reset(targetVelocity.X);
                    polyY.Reset(targetVelocity.Y);
                    polyZ.Reset(targetVelocity.Z);
                    polyA.Reset(targetVelocity.A);
                    polyB.Reset(targetVelocity.B);
                    polyC.Reset(targetVelocity.C);

                    return reachedPosition;
                }
            }
        }

    }
}