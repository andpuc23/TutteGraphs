
namespace TuttesGraphsVisualise
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.redrawBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // redrawBtn
            // 
            this.redrawBtn.Location = new System.Drawing.Point(1006, 1041);
            this.redrawBtn.Name = "redrawBtn";
            this.redrawBtn.Size = new System.Drawing.Size(156, 76);
            this.redrawBtn.TabIndex = 0;
            this.redrawBtn.Text = "Redraw";
            this.redrawBtn.UseVisualStyleBackColor = true;
            this.redrawBtn.Click += new System.EventHandler(this.redrawBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 1129);
            this.Controls.Add(this.redrawBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redrawBtn;
    }
}

