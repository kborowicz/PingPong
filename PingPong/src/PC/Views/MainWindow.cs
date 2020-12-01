﻿using MathNet.Numerics.LinearAlgebra;
using PingPong.Applications;
using PingPong.KUKA;
<<<<<<<< HEAD:PingPong/src/PC/Views/MainWindow.cs
========
using PingPong.Maths;
using PingPong.Maths.Solver;
>>>>>>>> 965747147b5a3b14d757b020c56d3885205d0eb0:PingPong/src/PC/Forms/MainWindow.cs
using PingPong.OptiTrack;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong.Views {
    public partial class MainWindow : Form {

        private KUKARobot robot1;

        private KUKARobot robot2;

        private OptiTrackSystem optiTrack;

        private BallData ballData;

        private CalibrationWindow calibrationWindow;

        private IApplication application;

        public MainWindow() {
            InitializeComponent();
            InitializeControls();
            robot1 = InitializeRobot1();
            robot2 = InitializeRobot2();
            optiTrack = InitializeOptiTrackSystem();
            ballData = new BallData();
<<<<<<<< HEAD:PingPong/src/PC/Views/MainWindow.cs
            application = new Ping(robot1);
            
========
            application = new Ping(robot1, threadSafeChart1);

            //robot1.Initialized += () => robot1.Shift(new E6POS(0, -150, 0), 3);

>>>>>>>> 965747147b5a3b14d757b020c56d3885205d0eb0:PingPong/src/PC/Forms/MainWindow.cs
            var rotationMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
                { -0.011,  0.006, -1.0 },
                { -1.0, -0.002,  0.011 },
                { -0.002,  1.0,  0.006 }
            });

            var translationVector = Vector<double>.Build.DenseOfArray(new double[] {
                782.814, 741.213, 147.467
            });

<<<<<<<< HEAD:PingPong/src/PC/Views/MainWindow.cs
            //E6POS current3 = new E6POS(0, 125, 550);
            //E6POS current5 = new E6POS(0, 125, 550);
            //E6POS target = current3 + new E6POS(150, 0, 0);

            //TrajectoryGenerator gen3 = new TrajectoryGenerator(current3);
            //TrajectoryGenerator5 gen5 = new TrajectoryGenerator5(current5);

            //gen3.SetTargetPosition(target, 4);
            //gen5.SetTargetPosition(target, 4);

            //Random random = new Random();

            //Task.Run(() => {
            //    while (true) {
            //        E6POS c3 = gen3.GetNextCorrection(current3);
            //        E6POS c5 = gen5.GetNextCorrection(current5);

            //        E6POS rand = new E6POS((random.NextDouble() - 0.5) * 0.01, (random.NextDouble() - 0.5) * 0.01, (random.NextDouble() - 0.5) * 0.01);
            //        current3 += c3 + rand;
            //        current5 += c5 + rand;

            //        threadSafeChart1.AddPoint(current5.X, gen5.Velocity[0]);
            //        Thread.Sleep(4);
            //    }
            //});

            //incXBtn.Click += (s, e) => {
            //    target += new E6POS(50, 0, 0);
            //    gen3.SetTargetPosition(target, 4);
            //    gen5.SetTargetPosition(target, 4);
            //};

            //decXBtn.Click += (s, e) => {
            //    target -= new E6POS(50, 0, 0);
            //    gen3.SetTargetPosition(target, 4);
            //    gen5.SetTargetPosition(target, 4);
            //};
========
            Transformation transformation = new Transformation(rotationMatrix, translationVector);
            Polyfit2 polyfitX = new Polyfit2(1);
            Polyfit2 polyfitY = new Polyfit2(1);
            Polyfit2 polyfitZ = new Polyfit2(2);

            double Z = 283.0;
            int maxPoints = 15;
            int sampleOffset = 5;

            bool parabolaDrawn = false;

            double tx = 0.0;
            int samples = 0;
            double prevTimestamp = 0.0;

            void DrawParabola() {
                if (parabolaDrawn) {
                    return;
                }

                parabolaDrawn = true;

                var xCoeffs = polyfitX.CalculateCoefficients();
                var yCoeffs = polyfitY.CalculateCoefficients();
                var zCoeffs = polyfitZ.CalculateCoefficients();

                UpdateUI(() => {
                    for (int i = 0; i < polyfitZ.PointCount; i++) {
                        chart1.Series[0].Points.AddXY(polyfitZ.xValues[i], polyfitZ.yValues[i]);
                    }

                    for (double t = 0; t < 1.0; t += 0.1) {
                        double z = zCoeffs[2] * t * t + zCoeffs[1] * t + zCoeffs[0];
                        chart1.Series[1].Points.AddXY(t, z);
                    }
                });

                double T = QuadraticSolver.SolveReal(zCoeffs[2], zCoeffs[1], zCoeffs[0] - Z)[1];

                double predX = xCoeffs[1] * T + xCoeffs[0];
                double predY = yCoeffs[1] * T + yCoeffs[0];
                double predZ = Z;

                T = T - tx;
                Console.WriteLine($"T={T}, xpred={xCoeffs[1] * T + xCoeffs[0]}, ypred={yCoeffs[1] * T + yCoeffs[0]}");

                robot1.MoveTo(new E6POS(predX, predY, predZ), T * 1.0);
            }

            // speed limit teachmode has been exceeded

            optiTrack.FrameReceived += frame => {
                var position = transformation.Convert(frame.Position);

                double ballX = position[0];
                double ballY = position[1];
                double ballZ = position[2];

                if (!parabolaDrawn && ballX != 782.814 && ballX != 741.213 && ballX != 147.467) {
                    if (polyfitZ.PointCount == maxPoints || ballZ < -100) {
                        DrawParabola();
                    } else if (samples % sampleOffset == 0) {
                        //TODO: ogarnąc czas, ewentualnie uzyc stopwatcha

                        polyfitX.AddPoint(tx, ballX);
                        polyfitY.AddPoint(tx, ballY);
                        polyfitZ.AddPoint(tx, ballZ);
                    }

                    samples++;

                    double deltaT = frame.Timestamp - prevTimestamp;

                    if (deltaT > 1) {
                        deltaT = 0.004;
                    }

                    tx += deltaT;
                    prevTimestamp = frame.Timestamp;
                }
            };

            button1.Click += (s, e) => {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Update();

                polyfitX.Clear();
                polyfitY.Clear();
                polyfitZ.Clear();

                samples = 0;
                parabolaDrawn = false;
            };
>>>>>>>> 965747147b5a3b14d757b020c56d3885205d0eb0:PingPong/src/PC/Forms/MainWindow.cs
        }

        public void ShowCalibrationWindow() {
            if (calibrationWindow == null || calibrationWindow.IsDisposed) {
                calibrationWindow = new CalibrationWindow(optiTrack, ballData, robot1, robot2);
            }

            calibrationWindow.Show();
            calibrationWindow.Activate();
            calibrationWindow.WindowState = FormWindowState.Normal;
            calibrationWindow.Location = new Point(Location.X, Location.Y);
        }

        private void InitializeControls() {
            incXBtn.Click += (s, e) => robot1.Shift(new E6POS(50, 0, 0), 10.0);
            decXBtn.Click += (s, e) => robot1.Shift(new E6POS(-50, 0, 0), 10.0);

            incYBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 50, 0), 10.0);
            decYBtn.Click += (s, e) => robot1.Shift(new E6POS(0, -50, 0), 10.0);

            incZBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 50), 10.0);
            decZBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, -50), 10.0);

            incABtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 0, 1, 0, 0), 10.0);
            decABtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 0, -1, 0, 0), 10.0);

            incBBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 0, 0, 1, 0), 10.0);
            decBBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 0, 0, -1, 0), 10.0);

            incCBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 0, 0, 0, 1), 10.0);
            decCBtn.Click += (s, e) => robot1.Shift(new E6POS(0, 0, 0, 0, 0, -1), 10.0);

            calibrationBtn.Click += (s, e) => ShowCalibrationWindow();
        }

        private KUKARobot InitializeRobot1() {
<<<<<<<< HEAD:PingPong/src/PC/Views/MainWindow.cs
            RobotLimits limits = new RobotLimits(
                (-450, 450),
                (600, 1000),
                (200, 750),
                (-360, 360),
                (-360, 360),
                (-360, 360),
                (-360, 360),
                (-360, 360),
                (-360, 360),
                (1, 0.05)
            );
========
            RobotLimits limits = new RobotLimits {
                LimitX = (-450, 450),
                LimitY = (600, 1100),
                LimitZ = (200, 750),
                LimitA1 = (-360, 360),
                LimitA2 = (-360, 360),
                LimitA3 = (-360, 360),
                LimitA4 = (-360, 360),
                LimitA5 = (-360, 360),
                LimitA6 = (-360, 360),
                LimitCorrection = (1, 0.05)
            };
>>>>>>>> 965747147b5a3b14d757b020c56d3885205d0eb0:PingPong/src/PC/Forms/MainWindow.cs

            KUKARobot robot1 = new KUKARobot(8081, limits);
            robot1Panel.AssignRobot(robot1);
            robot1.Initialize();

            return robot1;
        }

        private KUKARobot InitializeRobot2() {
            //TODO: limity dla drugiego robota!
            RobotLimits limits = null;

            KUKARobot robot2 = new KUKARobot(8082, limits);
            //robot2Panel.SetKUKARobot(robot2);
            robot2.Initialize();

            return robot2;
        }

        private OptiTrackSystem InitializeOptiTrackSystem() {
            OptiTrackSystem optiTrack = new OptiTrackSystem();

            optiTrack.FrameReceived += frame => {
                ballData.Update(frame);
            };

            optiTrack.Initialize();

            return optiTrack;
        }

        private void UpdateUI(Action updateAction) {
            if (InvokeRequired) {
                Action actionWrapper = () => {
                    updateAction.Invoke();
                };

                Invoke(actionWrapper);
                return;
            }

            updateAction.Invoke();
        }

    }
}