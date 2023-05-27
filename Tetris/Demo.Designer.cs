namespace Tetris
{
    partial class Demo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Demo));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLines = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Image = ((System.Drawing.Image)(resources.GetObject("Canvas.Image")));
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Canvas.Size = new System.Drawing.Size(599, 1000);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(710, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lines";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLines);
            this.panel1.Location = new System.Drawing.Point(616, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 45);
            this.panel1.TabIndex = 9;
            // 
            // lblLines
            // 
            this.lblLines.BackColor = System.Drawing.Color.Transparent;
            this.lblLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLines.Location = new System.Drawing.Point(4, 3);
            this.lblLines.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(170, 38);
            this.lblLines.TabIndex = 4;
            this.lblLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImage
            // 
            this.btnImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnImage.Image = global::Tetris.Properties.Resources.Linkedin;
            this.btnImage.Location = new System.Drawing.Point(616, 14);
            this.btnImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(34, 34);
            this.btnImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnImage.TabIndex = 11;
            this.btnImage.TabStop = false;
            this.btnImage.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 1000);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "Demo";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Demo_Load);
            this.Controls.SetChildIndex(this.Canvas, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnImage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.PictureBox btnImage;
    }
}

