﻿namespace Cours_Windows_Form
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
            this.Btn_ClickMe = new System.Windows.Forms.Button();
            this.lbl_Button = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_ClickMe
            // 
            this.Btn_ClickMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ClickMe.Location = new System.Drawing.Point(108, 42);
            this.Btn_ClickMe.Name = "Btn_ClickMe";
            this.Btn_ClickMe.Size = new System.Drawing.Size(160, 106);
            this.Btn_ClickMe.TabIndex = 0;
            this.Btn_ClickMe.Text = "Click me";
            this.Btn_ClickMe.UseVisualStyleBackColor = true;
            this.Btn_ClickMe.Click += new System.EventHandler(this.Btn_ClickMe_Click);
            // 
            // lbl_Button
            // 
            this.lbl_Button.AutoSize = true;
            this.lbl_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Button.Location = new System.Drawing.Point(396, 278);
            this.lbl_Button.Name = "lbl_Button";
            this.lbl_Button.Size = new System.Drawing.Size(109, 39);
            this.lbl_Button.TabIndex = 1;
            this.lbl_Button.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(716, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 492);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_Button);
            this.Controls.Add(this.Btn_ClickMe);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_ClickMe;
        private System.Windows.Forms.Label lbl_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

