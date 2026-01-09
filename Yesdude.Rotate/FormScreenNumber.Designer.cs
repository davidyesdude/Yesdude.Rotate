namespace Yesdude.Rotate
{
    partial class FormScreenNumber
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
            labelNumber = new Label();
            SuspendLayout();
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Font = new Font("Segoe UI", 384F, FontStyle.Bold);
            labelNumber.ForeColor = Color.ForestGreen;
            labelNumber.Location = new Point(-63, -80);
            labelNumber.Margin = new Padding(41, 0, 41, 0);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(580, 682);
            labelNumber.TabIndex = 0;
            labelNumber.Text = "0";
            labelNumber.Click += labelNumber_Click;
            labelNumber.MouseMove += labelNumber_MouseMove;
            // 
            // FormScreenNumber
            // 
            AutoScaleDimensions = new SizeF(95F, 227F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            CausesValidation = false;
            ClientSize = new Size(400, 600);
            ControlBox = false;
            Controls.Add(labelNumber);
            Font = new Font("Segoe UI", 128F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(41, 45, 41, 45);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormScreenNumber";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += FormScreenNumber_Load;
            Click += FormScreenNumber_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNumber;
    }
}