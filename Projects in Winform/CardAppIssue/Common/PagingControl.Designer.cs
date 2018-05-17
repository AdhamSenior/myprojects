namespace Common
{
    partial class PagingControl
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
            this.kbtnFirst = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnPrevious = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktbPage = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kbtnNext = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnLast = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kbtnFirst
            // 
            this.kbtnFirst.Location = new System.Drawing.Point(0, 0);
            this.kbtnFirst.Name = "kbtnFirst";
            this.kbtnFirst.Size = new System.Drawing.Size(30, 25);
            this.kbtnFirst.TabIndex = 0;
            this.kbtnFirst.Values.Text = "|<";
            // 
            // kbtnPrevious
            // 
            this.kbtnPrevious.Location = new System.Drawing.Point(32, 0);
            this.kbtnPrevious.Name = "kbtnPrevious";
            this.kbtnPrevious.Size = new System.Drawing.Size(30, 25);
            this.kbtnPrevious.TabIndex = 1;
            this.kbtnPrevious.Values.Text = "<";
            // 
            // ktbPage
            // 
            this.ktbPage.Location = new System.Drawing.Point(64, 2);
            this.ktbPage.Name = "ktbPage";
            this.ktbPage.ReadOnly = true;
            this.ktbPage.Size = new System.Drawing.Size(100, 20);
            this.ktbPage.TabIndex = 2;
            this.ktbPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kbtnNext
            // 
            this.kbtnNext.Location = new System.Drawing.Point(167, 0);
            this.kbtnNext.Name = "kbtnNext";
            this.kbtnNext.Size = new System.Drawing.Size(30, 25);
            this.kbtnNext.TabIndex = 3;
            this.kbtnNext.Values.Text = ">";
            // 
            // kbtnLast
            // 
            this.kbtnLast.Location = new System.Drawing.Point(200, 0);
            this.kbtnLast.Name = "kbtnLast";
            this.kbtnLast.Size = new System.Drawing.Size(30, 25);
            this.kbtnLast.TabIndex = 4;
            this.kbtnLast.Values.Text = ">|";
            // 
            // PagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ktbPage);
            this.Controls.Add(this.kbtnLast);
            this.Controls.Add(this.kbtnNext);
            this.Controls.Add(this.kbtnPrevious);
            this.Controls.Add(this.kbtnFirst);
            this.MaximumSize = new System.Drawing.Size(230, 25);
            this.Name = "PagingControl";
            this.Size = new System.Drawing.Size(230, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnFirst;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnPrevious;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPage;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnNext;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnLast;
    }
}
