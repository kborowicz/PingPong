﻿namespace PingPong.Views {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.incXBtn = new System.Windows.Forms.Button();
            this.decXBtn = new System.Windows.Forms.Button();
            this.incYBtn = new System.Windows.Forms.Button();
            this.decYBtn = new System.Windows.Forms.Button();
            this.incZBtn = new System.Windows.Forms.Button();
            this.decZBtn = new System.Windows.Forms.Button();
            this.incABtn = new System.Windows.Forms.Button();
            this.decABtn = new System.Windows.Forms.Button();
            this.incBBtn = new System.Windows.Forms.Button();
            this.decBBtn = new System.Windows.Forms.Button();
            this.incCBtn = new System.Windows.Forms.Button();
            this.decCBtn = new System.Windows.Forms.Button();
            this.calibrationBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.robot1Panel = new PingPong.Views.RobotDataPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.threadSafeChart = new PingPong.Views.ThreadSafeChart();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // incXBtn
            // 
            this.incXBtn.Location = new System.Drawing.Point(6, 6);
            this.incXBtn.Name = "incXBtn";
            this.incXBtn.Size = new System.Drawing.Size(61, 23);
            this.incXBtn.TabIndex = 0;
            this.incXBtn.Text = "X+";
            this.incXBtn.UseVisualStyleBackColor = true;
            // 
            // decXBtn
            // 
            this.decXBtn.Location = new System.Drawing.Point(73, 6);
            this.decXBtn.Name = "decXBtn";
            this.decXBtn.Size = new System.Drawing.Size(61, 23);
            this.decXBtn.TabIndex = 1;
            this.decXBtn.Text = "X-";
            this.decXBtn.UseVisualStyleBackColor = true;
            // 
            // incYBtn
            // 
            this.incYBtn.Location = new System.Drawing.Point(6, 35);
            this.incYBtn.Name = "incYBtn";
            this.incYBtn.Size = new System.Drawing.Size(61, 23);
            this.incYBtn.TabIndex = 2;
            this.incYBtn.Text = "Y+";
            this.incYBtn.UseVisualStyleBackColor = true;
            // 
            // decYBtn
            // 
            this.decYBtn.Location = new System.Drawing.Point(73, 35);
            this.decYBtn.Name = "decYBtn";
            this.decYBtn.Size = new System.Drawing.Size(61, 23);
            this.decYBtn.TabIndex = 3;
            this.decYBtn.Text = "Y-";
            this.decYBtn.UseVisualStyleBackColor = true;
            // 
            // incZBtn
            // 
            this.incZBtn.Location = new System.Drawing.Point(6, 64);
            this.incZBtn.Name = "incZBtn";
            this.incZBtn.Size = new System.Drawing.Size(61, 23);
            this.incZBtn.TabIndex = 4;
            this.incZBtn.Text = "Z+";
            this.incZBtn.UseVisualStyleBackColor = true;
            // 
            // decZBtn
            // 
            this.decZBtn.Location = new System.Drawing.Point(73, 64);
            this.decZBtn.Name = "decZBtn";
            this.decZBtn.Size = new System.Drawing.Size(61, 23);
            this.decZBtn.TabIndex = 5;
            this.decZBtn.Text = "Z-";
            this.decZBtn.UseVisualStyleBackColor = true;
            // 
            // incABtn
            // 
            this.incABtn.Location = new System.Drawing.Point(6, 93);
            this.incABtn.Name = "incABtn";
            this.incABtn.Size = new System.Drawing.Size(61, 23);
            this.incABtn.TabIndex = 6;
            this.incABtn.Text = "A+";
            this.incABtn.UseVisualStyleBackColor = true;
            // 
            // decABtn
            // 
            this.decABtn.Location = new System.Drawing.Point(73, 93);
            this.decABtn.Name = "decABtn";
            this.decABtn.Size = new System.Drawing.Size(61, 23);
            this.decABtn.TabIndex = 7;
            this.decABtn.Text = "A-";
            this.decABtn.UseVisualStyleBackColor = true;
            // 
            // incBBtn
            // 
            this.incBBtn.Location = new System.Drawing.Point(6, 122);
            this.incBBtn.Name = "incBBtn";
            this.incBBtn.Size = new System.Drawing.Size(61, 23);
            this.incBBtn.TabIndex = 8;
            this.incBBtn.Text = "B+";
            this.incBBtn.UseVisualStyleBackColor = true;
            // 
            // decBBtn
            // 
            this.decBBtn.Location = new System.Drawing.Point(73, 122);
            this.decBBtn.Name = "decBBtn";
            this.decBBtn.Size = new System.Drawing.Size(61, 23);
            this.decBBtn.TabIndex = 9;
            this.decBBtn.Text = "B-";
            this.decBBtn.UseVisualStyleBackColor = true;
            // 
            // incCBtn
            // 
            this.incCBtn.Location = new System.Drawing.Point(6, 151);
            this.incCBtn.Name = "incCBtn";
            this.incCBtn.Size = new System.Drawing.Size(61, 23);
            this.incCBtn.TabIndex = 10;
            this.incCBtn.Text = "C+";
            this.incCBtn.UseVisualStyleBackColor = true;
            // 
            // decCBtn
            // 
            this.decCBtn.Location = new System.Drawing.Point(73, 151);
            this.decCBtn.Name = "decCBtn";
            this.decCBtn.Size = new System.Drawing.Size(61, 23);
            this.decCBtn.TabIndex = 11;
            this.decCBtn.Text = "C-";
            this.decCBtn.UseVisualStyleBackColor = true;
            // 
            // calibrationBtn
            // 
            this.calibrationBtn.Location = new System.Drawing.Point(6, 180);
            this.calibrationBtn.Name = "calibrationBtn";
            this.calibrationBtn.Size = new System.Drawing.Size(128, 23);
            this.calibrationBtn.TabIndex = 26;
            this.calibrationBtn.Text = "Calibration tool";
            this.calibrationBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.incYBtn);
            this.panel1.Controls.Add(this.incXBtn);
            this.panel1.Controls.Add(this.calibrationBtn);
            this.panel1.Controls.Add(this.decXBtn);
            this.panel1.Controls.Add(this.decCBtn);
            this.panel1.Controls.Add(this.decYBtn);
            this.panel1.Controls.Add(this.incCBtn);
            this.panel1.Controls.Add(this.incZBtn);
            this.panel1.Controls.Add(this.decBBtn);
            this.panel1.Controls.Add(this.decZBtn);
            this.panel1.Controls.Add(this.incBBtn);
            this.panel1.Controls.Add(this.incABtn);
            this.panel1.Controls.Add(this.decABtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(993, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 511);
            this.panel1.TabIndex = 28;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(993, 511);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.robot1Panel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KUKA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // robot1Panel
            // 
            this.robot1Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.robot1Panel.Location = new System.Drawing.Point(3, 3);
            this.robot1Panel.MaxSamples = 5000;
            this.robot1Panel.Name = "robot1Panel";
            this.robot1Panel.RefreshTimeOffset = 80;
            this.robot1Panel.Size = new System.Drawing.Size(979, 479);
            this.robot1Panel.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.threadSafeChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OptiTrack";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // threadSafeChart
            // 
            this.threadSafeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadSafeChart.Location = new System.Drawing.Point(3, 3);
            this.threadSafeChart.MaxSamples = 1000;
            this.threadSafeChart.Name = "threadSafeChart";
            this.threadSafeChart.RefreshTimeOffset = 80;
            this.threadSafeChart.Size = new System.Drawing.Size(979, 479);
            this.threadSafeChart.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1134, 511);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ping Pong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button incXBtn;
        private System.Windows.Forms.Button decXBtn;
        private System.Windows.Forms.Button incYBtn;
        private System.Windows.Forms.Button decYBtn;
        private System.Windows.Forms.Button incZBtn;
        private System.Windows.Forms.Button decZBtn;
        private System.Windows.Forms.Button incABtn;
        private System.Windows.Forms.Button decABtn;
        private System.Windows.Forms.Button incBBtn;
        private System.Windows.Forms.Button decBBtn;
        private System.Windows.Forms.Button incCBtn;
        private System.Windows.Forms.Button decCBtn;
        private System.Windows.Forms.Button calibrationBtn;
        private System.Windows.Forms.Panel panel1;
        private RobotDataPanel robot1Panel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ThreadSafeChart threadSafeChart;
    }
}