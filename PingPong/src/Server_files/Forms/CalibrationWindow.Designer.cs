﻿namespace PingPong.Forms {
    partial class CalibrationWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.robotSelect = new System.Windows.Forms.ComboBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m12 = new System.Windows.Forms.Label();
            this.m13 = new System.Windows.Forms.Label();
            this.m14 = new System.Windows.Forms.Label();
            this.m24 = new System.Windows.Forms.Label();
            this.m23 = new System.Windows.Forms.Label();
            this.m22 = new System.Windows.Forms.Label();
            this.m21 = new System.Windows.Forms.Label();
            this.m31 = new System.Windows.Forms.Label();
            this.m32 = new System.Windows.Forms.Label();
            this.m34 = new System.Windows.Forms.Label();
            this.m44 = new System.Windows.Forms.Label();
            this.m43 = new System.Windows.Forms.Label();
            this.m42 = new System.Windows.Forms.Label();
            this.m41 = new System.Windows.Forms.Label();
            this.m11 = new System.Windows.Forms.Label();
            this.m33 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transformation matrix";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 171);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(264, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // robotSelect
            // 
            this.robotSelect.FormattingEnabled = true;
            this.robotSelect.Location = new System.Drawing.Point(12, 12);
            this.robotSelect.Name = "robotSelect";
            this.robotSelect.Size = new System.Drawing.Size(168, 21);
            this.robotSelect.TabIndex = 3;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(186, 11);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(90, 23);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start calibration";
            this.startBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.m12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.m13, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.m14, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.m24, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.m23, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.m22, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.m21, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m31, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.m32, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.m34, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.m44, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.m43, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.m42, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.m41, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.m11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m33, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 61);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 104);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // m12
            // 
            this.m12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m12.AutoSize = true;
            this.m12.Location = new System.Drawing.Point(91, 6);
            this.m12.Name = "m12";
            this.m12.Size = new System.Drawing.Size(13, 13);
            this.m12.TabIndex = 1;
            this.m12.Text = "0";
            // 
            // m13
            // 
            this.m13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m13.AutoSize = true;
            this.m13.Location = new System.Drawing.Point(156, 6);
            this.m13.Name = "m13";
            this.m13.Size = new System.Drawing.Size(13, 13);
            this.m13.TabIndex = 2;
            this.m13.Text = "0";
            // 
            // m14
            // 
            this.m14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m14.AutoSize = true;
            this.m14.Location = new System.Drawing.Point(223, 6);
            this.m14.Name = "m14";
            this.m14.Size = new System.Drawing.Size(13, 13);
            this.m14.TabIndex = 3;
            this.m14.Text = "0";
            // 
            // m24
            // 
            this.m24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m24.AutoSize = true;
            this.m24.Location = new System.Drawing.Point(223, 31);
            this.m24.Name = "m24";
            this.m24.Size = new System.Drawing.Size(13, 13);
            this.m24.TabIndex = 4;
            this.m24.Text = "0";
            // 
            // m23
            // 
            this.m23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m23.AutoSize = true;
            this.m23.Location = new System.Drawing.Point(156, 31);
            this.m23.Name = "m23";
            this.m23.Size = new System.Drawing.Size(13, 13);
            this.m23.TabIndex = 5;
            this.m23.Text = "0";
            // 
            // m22
            // 
            this.m22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m22.AutoSize = true;
            this.m22.Location = new System.Drawing.Point(91, 31);
            this.m22.Name = "m22";
            this.m22.Size = new System.Drawing.Size(13, 13);
            this.m22.TabIndex = 6;
            this.m22.Text = "0";
            // 
            // m21
            // 
            this.m21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m21.AutoSize = true;
            this.m21.Location = new System.Drawing.Point(26, 31);
            this.m21.Name = "m21";
            this.m21.Size = new System.Drawing.Size(13, 13);
            this.m21.TabIndex = 7;
            this.m21.Text = "0";
            // 
            // m31
            // 
            this.m31.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m31.AutoSize = true;
            this.m31.Location = new System.Drawing.Point(26, 56);
            this.m31.Name = "m31";
            this.m31.Size = new System.Drawing.Size(13, 13);
            this.m31.TabIndex = 8;
            this.m31.Text = "0";
            // 
            // m32
            // 
            this.m32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m32.AutoSize = true;
            this.m32.Location = new System.Drawing.Point(91, 56);
            this.m32.Name = "m32";
            this.m32.Size = new System.Drawing.Size(13, 13);
            this.m32.TabIndex = 9;
            this.m32.Text = "0";
            // 
            // m34
            // 
            this.m34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m34.AutoSize = true;
            this.m34.Location = new System.Drawing.Point(223, 56);
            this.m34.Name = "m34";
            this.m34.Size = new System.Drawing.Size(13, 13);
            this.m34.TabIndex = 11;
            this.m34.Text = "0";
            // 
            // m44
            // 
            this.m44.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m44.AutoSize = true;
            this.m44.Location = new System.Drawing.Point(223, 83);
            this.m44.Name = "m44";
            this.m44.Size = new System.Drawing.Size(13, 13);
            this.m44.TabIndex = 12;
            this.m44.Text = "0";
            // 
            // m43
            // 
            this.m43.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m43.AutoSize = true;
            this.m43.Location = new System.Drawing.Point(156, 83);
            this.m43.Name = "m43";
            this.m43.Size = new System.Drawing.Size(13, 13);
            this.m43.TabIndex = 13;
            this.m43.Text = "0";
            // 
            // m42
            // 
            this.m42.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m42.AutoSize = true;
            this.m42.Location = new System.Drawing.Point(91, 83);
            this.m42.Name = "m42";
            this.m42.Size = new System.Drawing.Size(13, 13);
            this.m42.TabIndex = 14;
            this.m42.Text = "0";
            // 
            // m41
            // 
            this.m41.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m41.AutoSize = true;
            this.m41.Location = new System.Drawing.Point(26, 83);
            this.m41.Name = "m41";
            this.m41.Size = new System.Drawing.Size(13, 13);
            this.m41.TabIndex = 15;
            this.m41.Text = "0";
            // 
            // m11
            // 
            this.m11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m11.AutoSize = true;
            this.m11.Location = new System.Drawing.Point(26, 6);
            this.m11.Name = "m11";
            this.m11.Size = new System.Drawing.Size(13, 13);
            this.m11.TabIndex = 0;
            this.m11.Text = "0";
            // 
            // m33
            // 
            this.m33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m33.AutoSize = true;
            this.m33.Location = new System.Drawing.Point(156, 56);
            this.m33.Name = "m33";
            this.m33.Size = new System.Drawing.Size(13, 13);
            this.m33.TabIndex = 10;
            this.m33.Text = "0";
            // 
            // CalibrationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 206);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.robotSelect);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CalibrationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox robotSelect;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label m12;
        private System.Windows.Forms.Label m13;
        private System.Windows.Forms.Label m14;
        private System.Windows.Forms.Label m24;
        private System.Windows.Forms.Label m23;
        private System.Windows.Forms.Label m22;
        private System.Windows.Forms.Label m21;
        private System.Windows.Forms.Label m31;
        private System.Windows.Forms.Label m32;
        private System.Windows.Forms.Label m34;
        private System.Windows.Forms.Label m44;
        private System.Windows.Forms.Label m43;
        private System.Windows.Forms.Label m42;
        private System.Windows.Forms.Label m41;
        private System.Windows.Forms.Label m11;
        private System.Windows.Forms.Label m33;
    }
}