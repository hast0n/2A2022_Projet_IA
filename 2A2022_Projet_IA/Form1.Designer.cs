﻿using System;

namespace _2A2022_Projet_IA
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.casGroupBox = new System.Windows.Forms.GroupBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.hLabel = new System.Windows.Forms.Label();
            this.hComboBox = new System.Windows.Forms.ComboBox();
            this.angleLabel = new System.Windows.Forms.Label();
            this.angleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.casGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(138, 373);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cas 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cas 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Cas 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(326, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(159, 306);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(121, 21);
            this.colorComboBox.TabIndex = 5;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.colorComboBox_SelectedIndexChanged);
            // 
            // casGroupBox
            // 
            this.casGroupBox.Controls.Add(this.button1);
            this.casGroupBox.Controls.Add(this.button2);
            this.casGroupBox.Controls.Add(this.button3);
            this.casGroupBox.Location = new System.Drawing.Point(159, 12);
            this.casGroupBox.Name = "casGroupBox";
            this.casGroupBox.Size = new System.Drawing.Size(121, 156);
            this.casGroupBox.TabIndex = 6;
            this.casGroupBox.TabStop = false;
            this.casGroupBox.Text = "Cas de navigation";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(159, 290);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(85, 13);
            this.colorLabel.TabIndex = 7;
            this.colorLabel.Text = "Couleur du tracé";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(508, 338);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(118, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Effacer les tracés";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // hLabel
            // 
            this.hLabel.AutoSize = true;
            this.hLabel.Location = new System.Drawing.Point(159, 175);
            this.hLabel.Name = "hLabel";
            this.hLabel.Size = new System.Drawing.Size(60, 13);
            this.hLabel.TabIndex = 9;
            this.hLabel.Text = "Heuristique";
            // 
            // hComboBox
            // 
            this.hComboBox.FormattingEnabled = true;
            this.hComboBox.Location = new System.Drawing.Point(159, 192);
            this.hComboBox.Name = "hComboBox";
            this.hComboBox.Size = new System.Drawing.Size(121, 21);
            this.hComboBox.TabIndex = 10;
            this.hComboBox.SelectedIndexChanged += new System.EventHandler(this.hComboBox_SelectedIndexChanged);
            // 
            // angleLabel
            // 
            this.angleLabel.AutoSize = true;
            this.angleLabel.Location = new System.Drawing.Point(162, 230);
            this.angleLabel.Name = "angleLabel";
            this.angleLabel.Size = new System.Drawing.Size(87, 13);
            this.angleLabel.TabIndex = 11;
            this.angleLabel.Text = "Angle d\'action (°)";
            // 
            // angleNumericUpDown
            // 
            this.angleNumericUpDown.Location = new System.Drawing.Point(159, 247);
            this.angleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleNumericUpDown.Name = "angleNumericUpDown";
            this.angleNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.angleNumericUpDown.TabIndex = 12;
            this.angleNumericUpDown.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.angleNumericUpDown.ValueChanged += new System.EventHandler(this.angleNumericUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 373);
            this.Controls.Add(this.angleNumericUpDown);
            this.Controls.Add(this.angleLabel);
            this.Controls.Add(this.hComboBox);
            this.Controls.Add(this.hLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.casGroupBox);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.MaximumSize = new System.Drawing.Size(654, 412);
            this.MinimumSize = new System.Drawing.Size(654, 412);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.casGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.GroupBox casGroupBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button clearButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label hLabel;
        private System.Windows.Forms.ComboBox hComboBox;
        private System.Windows.Forms.Label angleLabel;
        private System.Windows.Forms.NumericUpDown angleNumericUpDown;
    }
}

