
namespace Task1_2_WinForms
{
    partial class FormOutput
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
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelGreetingsFromLibrary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelOutput
            // 
            this.labelOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(346, 190);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(61, 13);
            this.labelOutput.TabIndex = 0;
            this.labelOutput.Text = "labelOutput";
            this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGreetingsFromLibrary
            // 
            this.labelGreetingsFromLibrary.AutoSize = true;
            this.labelGreetingsFromLibrary.Location = new System.Drawing.Point(346, 224);
            this.labelGreetingsFromLibrary.Name = "labelGreetingsFromLibrary";
            this.labelGreetingsFromLibrary.Size = new System.Drawing.Size(35, 13);
            this.labelGreetingsFromLibrary.TabIndex = 1;
            this.labelGreetingsFromLibrary.Text = "label1";
            // 
            // FormOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 440);
            this.Controls.Add(this.labelGreetingsFromLibrary);
            this.Controls.Add(this.labelOutput);
            this.Name = "FormOutput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelGreetingsFromLibrary;
    }
}