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
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRecycle = new System.Windows.Forms.Button();
            this.linkLabelUrl = new System.Windows.Forms.LinkLabel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.panelStatusLight = new System.Windows.Forms.Panel();
            this.linkLabelAppDirectory = new System.Windows.Forms.LinkLabel();
            this.linkLabelLogs = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(132, 29);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(70, 29);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(56, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
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
            this.linkLabelUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUrl_LinkClicked);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(299, 29);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(56, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
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
            this.linkLabelLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogs_LinkClicked);
            // 
            // NutInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.linkLabelLogs);
            this.Controls.Add(this.linkLabelAppDirectory);
            this.Controls.Add(this.panelStatusLight);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.linkLabelUrl);
            this.Controls.Add(this.buttonRecycle);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Name = "NutInfo";
            this.Size = new System.Drawing.Size(361, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonRecycle;
        private System.Windows.Forms.LinkLabel linkLabelUrl;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Panel panelStatusLight;
        private System.Windows.Forms.LinkLabel linkLabelAppDirectory;
        private System.Windows.Forms.LinkLabel linkLabelLogs;
    }
}
