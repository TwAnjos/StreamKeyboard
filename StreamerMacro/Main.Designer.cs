namespace StreamerMacro
{
    partial class Main
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
            this.Macros = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // Macros
            // 
            this.Macros.Location = new System.Drawing.Point(12, 12);
            this.Macros.Name = "Macros";
            this.Macros.Size = new System.Drawing.Size(459, 406);
            this.Macros.TabIndex = 0;
            this.Macros.TabStop = false;
            this.Macros.Text = "Key macro functions";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 616);
            this.Controls.Add(this.Macros);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Streamer Macro";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Macros;
    }
}

