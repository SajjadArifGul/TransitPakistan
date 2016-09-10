namespace TransitSMS
{
    partial class ConectionForm
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
            this.COMPortBox = new System.Windows.Forms.TextBox();
            this.BaudRateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeoutBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProceedButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(44, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // COMPortBox
            // 
            this.COMPortBox.Location = new System.Drawing.Point(148, 64);
            this.COMPortBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.COMPortBox.Name = "COMPortBox";
            this.COMPortBox.Size = new System.Drawing.Size(264, 26);
            this.COMPortBox.TabIndex = 1;
            // 
            // BaudRateBox
            // 
            this.BaudRateBox.Location = new System.Drawing.Point(148, 100);
            this.BaudRateBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BaudRateBox.Name = "BaudRateBox";
            this.BaudRateBox.Size = new System.Drawing.Size(264, 26);
            this.BaudRateBox.TabIndex = 3;
            this.BaudRateBox.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(44, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate";
            // 
            // TimeoutBox
            // 
            this.TimeoutBox.Location = new System.Drawing.Point(148, 136);
            this.TimeoutBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TimeoutBox.Name = "TimeoutBox";
            this.TimeoutBox.Size = new System.Drawing.Size(264, 26);
            this.TimeoutBox.TabIndex = 5;
            this.TimeoutBox.Text = "300";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(44, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Timeout";
            // 
            // ProceedButton
            // 
            this.ProceedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.ProceedButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(44)))));
            this.ProceedButton.FlatAppearance.BorderSize = 0;
            this.ProceedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(44)))));
            this.ProceedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(50)))));
            this.ProceedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProceedButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ProceedButton.Location = new System.Drawing.Point(148, 181);
            this.ProceedButton.Name = "ProceedButton";
            this.ProceedButton.Size = new System.Drawing.Size(264, 29);
            this.ProceedButton.TabIndex = 38;
            this.ProceedButton.Text = "Enter Details and Proceed";
            this.ProceedButton.UseVisualStyleBackColor = false;
            this.ProceedButton.Click += new System.EventHandler(this.ProceedButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(142, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 31);
            this.label4.TabIndex = 39;
            this.label4.Text = "Transit SMS";
            // 
            // ConectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(457, 232);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProceedButton);
            this.Controls.Add(this.TimeoutBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BaudRateBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.COMPortBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConectionForm";
            this.Text = "Conection Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox COMPortBox;
        private System.Windows.Forms.TextBox BaudRateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TimeoutBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ProceedButton;
        private System.Windows.Forms.Label label4;
    }
}