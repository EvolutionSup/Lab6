namespace Lab4
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
            this.textBoxInputString = new System.Windows.Forms.TextBox();
            this.comboBoxConsole = new System.Windows.Forms.ComboBox();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxInputString
            // 
            this.textBoxInputString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInputString.Location = new System.Drawing.Point(12, 12);
            this.textBoxInputString.Name = "textBoxInputString";
            this.textBoxInputString.Size = new System.Drawing.Size(369, 30);
            this.textBoxInputString.TabIndex = 0;
            this.textBoxInputString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInputString_KeyDown);
            // 
            // comboBoxConsole
            // 
            this.comboBoxConsole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConsole.DropDownWidth = 250;
            this.comboBoxConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxConsole.FormattingEnabled = true;
            this.comboBoxConsole.Location = new System.Drawing.Point(387, 12);
            this.comboBoxConsole.Name = "comboBoxConsole";
            this.comboBoxConsole.Size = new System.Drawing.Size(157, 24);
            this.comboBoxConsole.TabIndex = 1;
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BackColor = System.Drawing.Color.White;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(12, 48);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(532, 390);
            this.pictureBoxDisplay.TabIndex = 2;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Controls.Add(this.comboBoxConsole);
            this.Controls.Add(this.textBoxInputString);
            this.Name = "Form1";
            this.Text = "Lab4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInputString;
        private System.Windows.Forms.ComboBox comboBoxConsole;
        private System.Windows.Forms.PictureBox pictureBoxDisplay;
    }
}

