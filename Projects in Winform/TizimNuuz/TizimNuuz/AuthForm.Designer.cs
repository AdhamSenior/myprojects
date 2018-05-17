namespace TizimNuuz
{
    partial class AuthForm
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
            this.ktbLogin = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.ktbPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.klblLogin = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.klblPass = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kwlblTitle = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnEnter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // ktbLogin
            // 
            this.ktbLogin.Location = new System.Drawing.Point(112, 85);
            this.ktbLogin.Name = "ktbLogin";
            this.ktbLogin.Size = new System.Drawing.Size(235, 20);
            this.ktbLogin.TabIndex = 1;
            // 
            // ktbPassword
            // 
            this.ktbPassword.Location = new System.Drawing.Point(112, 111);
            this.ktbPassword.Name = "ktbPassword";
            this.ktbPassword.PasswordChar = '●';
            this.ktbPassword.Size = new System.Drawing.Size(235, 20);
            this.ktbPassword.TabIndex = 3;
            this.ktbPassword.UseSystemPasswordChar = true;
            // 
            // klblLogin
            // 
            this.klblLogin.Location = new System.Drawing.Point(12, 85);
            this.klblLogin.Name = "klblLogin";
            this.klblLogin.Size = new System.Drawing.Size(41, 20);
            this.klblLogin.TabIndex = 0;
            this.klblLogin.Values.Text = "Login";
            // 
            // klblPass
            // 
            this.klblPass.Location = new System.Drawing.Point(12, 111);
            this.klblPass.Name = "klblPass";
            this.klblPass.Size = new System.Drawing.Size(62, 20);
            this.klblPass.TabIndex = 2;
            this.klblPass.Values.Text = "Password";
            // 
            // kwlblTitle
            // 
            this.kwlblTitle.AutoSize = false;
            this.kwlblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kwlblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.kwlblTitle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlblTitle.Location = new System.Drawing.Point(12, 40);
            this.kwlblTitle.Name = "kwlblTitle";
            this.kwlblTitle.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kwlblTitle.Size = new System.Drawing.Size(335, 19);
            this.kwlblTitle.StateNormal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kwlblTitle.Text = "Login to the system";
            this.kwlblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kbtnEnter
            // 
            this.kbtnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnEnter.Location = new System.Drawing.Point(257, 183);
            this.kbtnEnter.Name = "kbtnEnter";
            this.kbtnEnter.TabIndex = 4;
            this.kbtnEnter.Values.Text = "Enter";
            // 
            // AuthForm
            // 
            this.AcceptButton = this.kbtnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 226);
            this.Controls.Add(this.kbtnEnter);
            this.Controls.Add(this.kwlblTitle);
            this.Controls.Add(this.klblPass);
            this.Controls.Add(this.klblLogin);
            this.Controls.Add(this.ktbPassword);
            this.Controls.Add(this.ktbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(375, 260);
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthForm";
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel klblLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel klblPass;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kwlblTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnEnter;
    }
}