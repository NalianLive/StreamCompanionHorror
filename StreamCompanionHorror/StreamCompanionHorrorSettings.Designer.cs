namespace StreamCompanionHorror
{
    partial class StreamCompanionHorrorSettings
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
            this.checkboxEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkboxEnable
            // 
            this.checkboxEnable.AutoSize = true;
            this.checkboxEnable.Location = new System.Drawing.Point(3, 3);
            this.checkboxEnable.Name = "checkboxEnable";
            this.checkboxEnable.Size = new System.Drawing.Size(59, 17);
            this.checkboxEnable.TabIndex = 0;
            this.checkboxEnable.Text = "Enable";
            this.checkboxEnable.UseVisualStyleBackColor = true;
            this.checkboxEnable.CheckedChanged += new System.EventHandler(this.checkboxEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "StreamCompanion Horror by LewisTehMinerz";
            // 
            // StreamCompanionHorrorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkboxEnable);
            this.Name = "StreamCompanionHorrorSettings";
            this.Size = new System.Drawing.Size(235, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxEnable;
        private System.Windows.Forms.Label label1;
    }
}
