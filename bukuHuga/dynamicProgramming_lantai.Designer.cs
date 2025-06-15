namespace bukuHuga
{
    partial class dynamicProgramming_lantai
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dynamicProgramming_lantai));
            this.label1 = new System.Windows.Forms.Label();
            this.Ncount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHitungDP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Location = new System.Drawing.Point(105, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 176);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ncount
            // 
            this.Ncount.Location = new System.Drawing.Point(46, 245);
            this.Ncount.Name = "Ncount";
            this.Ncount.Size = new System.Drawing.Size(57, 20);
            this.Ncount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "N:";
            // 
            // btnHitungDP
            // 
            this.btnHitungDP.Location = new System.Drawing.Point(118, 245);
            this.btnHitungDP.Name = "btnHitungDP";
            this.btnHitungDP.Size = new System.Drawing.Size(60, 23);
            this.btnHitungDP.TabIndex = 4;
            this.btnHitungDP.Text = "Hitung";
            this.btnHitungDP.UseVisualStyleBackColor = true;
            this.btnHitungDP.Click += new System.EventHandler(this.btnHitungDP_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::bukuHuga.Properties.Resources.dp;
            this.pictureBox1.Location = new System.Drawing.Point(211, 179);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // dynamicProgramming_lantai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHitungDP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ncount);
            this.Controls.Add(this.label1);
            this.Name = "dynamicProgramming_lantai";
            this.Size = new System.Drawing.Size(560, 353);
            this.Load += new System.EventHandler(this.dynamicProgramming_lantai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Ncount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHitungDP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
