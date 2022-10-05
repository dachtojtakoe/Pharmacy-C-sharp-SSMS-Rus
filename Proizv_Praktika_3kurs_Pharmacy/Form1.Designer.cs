namespace Proizv_Praktika_3kurs_Pharmacy
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ExitBut = new System.Windows.Forms.Button();
            this.EnterBut = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maya", 24.12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(129, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Аптека";
            // 
            // ExitBut
            // 
            this.ExitBut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExitBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.ExitBut.Location = new System.Drawing.Point(61, 318);
            this.ExitBut.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBut.Name = "ExitBut";
            this.ExitBut.Size = new System.Drawing.Size(148, 37);
            this.ExitBut.TabIndex = 2;
            this.ExitBut.Text = "Выход";
            this.ExitBut.UseVisualStyleBackColor = false;
            this.ExitBut.Click += new System.EventHandler(this.ExitBut_Click);
            // 
            // EnterBut
            // 
            this.EnterBut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.EnterBut.FlatAppearance.BorderColor = System.Drawing.Color.Linen;
            this.EnterBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.EnterBut.Location = new System.Drawing.Point(50, 237);
            this.EnterBut.Margin = new System.Windows.Forms.Padding(2);
            this.EnterBut.Name = "EnterBut";
            this.EnterBut.Size = new System.Drawing.Size(169, 66);
            this.EnterBut.TabIndex = 3;
            this.EnterBut.Text = "Войти";
            this.EnterBut.UseVisualStyleBackColor = false;
            this.EnterBut.Click += new System.EventHandler(this.EnterBut_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(119)))), ((int)(((byte)(144)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Proizv_Praktika_3kurs_Pharmacy.Properties.Resources.chemistry;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-5, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(119)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(276, 366);
            this.Controls.Add(this.EnterBut);
            this.Controls.Add(this.ExitBut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitBut;
        private System.Windows.Forms.Button EnterBut;
    }
}

