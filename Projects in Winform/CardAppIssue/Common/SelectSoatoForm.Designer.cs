namespace Common
{
    partial class SelectSoatoForm
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
            this.ktvItems = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.kbtnSelect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // ktvItems
            // 
            this.ktvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktvItems.Location = new System.Drawing.Point(12, 12);
            this.ktvItems.Name = "ktvItems";
            this.ktvItems.Size = new System.Drawing.Size(445, 346);
            this.ktvItems.TabIndex = 0;
            // 
            // kbtnSelect
            // 
            this.kbtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSelect.Location = new System.Drawing.Point(367, 364);
            this.kbtnSelect.Name = "kbtnSelect";
            this.kbtnSelect.Size = new System.Drawing.Size(90, 25);
            this.kbtnSelect.TabIndex = 1;
            this.kbtnSelect.Values.Text = "Select";
            // 
            // SelectSoatoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 401);
            this.Controls.Add(this.kbtnSelect);
            this.Controls.Add(this.ktvItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(475, 425);
            this.Name = "SelectSoatoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectSoatoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTreeView ktvItems;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSelect;
    }
}