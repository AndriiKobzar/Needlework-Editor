namespace Needlework_Editor
{
    partial class SizeSetter
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
            this.label1 = new System.Windows.Forms.Label();
            this.widthSetter = new System.Windows.Forms.NumericUpDown();
            this.heightSetter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.distanceSetter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.widthSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина";
            // 
            // widthSetter
            // 
            this.widthSetter.Location = new System.Drawing.Point(103, 30);
            this.widthSetter.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.widthSetter.Name = "widthSetter";
            this.widthSetter.Size = new System.Drawing.Size(120, 20);
            this.widthSetter.TabIndex = 1;
            // 
            // heightSetter
            // 
            this.heightSetter.Location = new System.Drawing.Point(103, 60);
            this.heightSetter.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.heightSetter.Name = "heightSetter";
            this.heightSetter.Size = new System.Drawing.Size(120, 20);
            this.heightSetter.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Висота";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(103, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // distanceSetter
            // 
            this.distanceSetter.Location = new System.Drawing.Point(103, 92);
            this.distanceSetter.Name = "distanceSetter";
            this.distanceSetter.Size = new System.Drawing.Size(120, 20);
            this.distanceSetter.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Відстань";
            // 
            // SizeSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 167);
            this.Controls.Add(this.distanceSetter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.heightSetter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthSetter);
            this.Controls.Add(this.label1);
            this.Name = "SizeSetter";
            this.Text = "SizeSetter";
            ((System.ComponentModel.ISupportInitialize)(this.widthSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceSetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown widthSetter;
        private System.Windows.Forms.NumericUpDown heightSetter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown distanceSetter;
        private System.Windows.Forms.Label label3;

    }
}