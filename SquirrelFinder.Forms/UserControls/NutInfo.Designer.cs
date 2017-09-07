namespace SquirrelFinder.Forms.UserControls
{
    partial class NutInfo
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
            this.buttonToggle = new System.Windows.Forms.Button();
            this.buttonRecycle = new System.Windows.Forms.Button();
            this.linkLabelUrl = new System.Windows.Forms.LinkLabel();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.panelStatusLight = new System.Windows.Forms.Panel();
            this.linkLabelAppDirectory = new System.Windows.Forms.LinkLabel();
            this.linkLabelLogs = new System.Windows.Forms.LinkLabel();
            this.linkLabelErrors = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonToggle
            // 
            this.buttonToggle.Location = new System.Drawing.Point(70, 29);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(56, 23);
            this.buttonToggle.TabIndex = 1;
            this.buttonToggle.Text = "Start";
            this.buttonToggle.UseVisualStyleBackColor = true;
            // 
            // buttonRecycle
            // 
            this.buttonRecycle.Location = new System.Drawing.Point(8, 29);
            this.buttonRecycle.Name = "buttonRecycle";
            this.buttonRecycle.Size = new System.Drawing.Size(56, 23);
            this.buttonRecycle.TabIndex = 2;
            this.buttonRecycle.Text = "Recycle";
            this.buttonRecycle.UseVisualStyleBackColor = true;
            // 
            // linkLabelUrl
            // 
            this.linkLabelUrl.AutoSize = true;
            this.linkLabelUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelUrl.Location = new System.Drawing.Point(8, 5);
            this.linkLabelUrl.Name = "linkLabelUrl";
            this.linkLabelUrl.Size = new System.Drawing.Size(72, 17);
            this.linkLabelUrl.TabIndex = 3;
            this.linkLabelUrl.TabStop = true;
            this.linkLabelUrl.Text = "linkLabel1";
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Location = new System.Drawing.Point(299, 29);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(56, 23);
            this.ButtonRemove.TabIndex = 4;
            this.ButtonRemove.Text = "Remove";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            // 
            // panelStatusLight
            // 
            this.panelStatusLight.Location = new System.Drawing.Point(337, 5);
            this.panelStatusLight.Name = "panelStatusLight";
            this.panelStatusLight.Size = new System.Drawing.Size(15, 15);
            this.panelStatusLight.TabIndex = 5;
            // 
            // linkLabelAppDirectory
            // 
            this.linkLabelAppDirectory.AutoSize = true;
            this.linkLabelAppDirectory.Location = new System.Drawing.Point(194, 34);
            this.linkLabelAppDirectory.Name = "linkLabelAppDirectory";
            this.linkLabelAppDirectory.Size = new System.Drawing.Size(37, 13);
            this.linkLabelAppDirectory.TabIndex = 6;
            this.linkLabelAppDirectory.TabStop = true;
            this.linkLabelAppDirectory.Text = "Files...";
            // 
            // linkLabelLogs
            // 
            this.linkLabelLogs.AutoSize = true;
            this.linkLabelLogs.Location = new System.Drawing.Point(237, 34);
            this.linkLabelLogs.Name = "linkLabelLogs";
            this.linkLabelLogs.Size = new System.Drawing.Size(39, 13);
            this.linkLabelLogs.TabIndex = 7;
            this.linkLabelLogs.TabStop = true;
            this.linkLabelLogs.Text = "Logs...";
            // 
            // linkLabelErrors
            // 
            this.linkLabelErrors.AutoSize = true;
            this.linkLabelErrors.Location = new System.Drawing.Point(240, 5);
            this.linkLabelErrors.Name = "linkLabelErrors";
            this.linkLabelErrors.Size = new System.Drawing.Size(49, 13);
            this.linkLabelErrors.TabIndex = 8;
            this.linkLabelErrors.TabStop = true;
            this.linkLabelErrors.Text = "Errors (0)";
            // 
            // NutInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.linkLabelErrors);
            this.Controls.Add(this.linkLabelLogs);
            this.Controls.Add(this.linkLabelAppDirectory);
            this.Controls.Add(this.panelStatusLight);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.linkLabelUrl);
            this.Controls.Add(this.buttonRecycle);
            this.Controls.Add(this.buttonToggle);
            this.Name = "NutInfo";
            this.Size = new System.Drawing.Size(361, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonToggle;
        private System.Windows.Forms.Button buttonRecycle;
        private System.Windows.Forms.LinkLabel linkLabelUrl;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Panel panelStatusLight;
        private System.Windows.Forms.LinkLabel linkLabelAppDirectory;
        private System.Windows.Forms.LinkLabel linkLabelLogs;
        private System.Windows.Forms.LinkLabel linkLabelErrors;
    }
}
