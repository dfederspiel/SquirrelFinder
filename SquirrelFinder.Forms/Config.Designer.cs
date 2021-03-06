﻿using SquirrelFinder;

namespace SquirrelFinder.Forms
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddToWatch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAvailableBindings = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLocalSites = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxPublicUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddPublicSite = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxIsSitefinity = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.loadPreviousConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonAddToWatch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listBoxAvailableBindings);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxLocalSites);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "IIS Sites on your computer that can be monitored, auto-initialized, and kept aliv" +
    "e.";
            // 
            // buttonAddToWatch
            // 
            this.buttonAddToWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddToWatch.Location = new System.Drawing.Point(247, 408);
            this.buttonAddToWatch.Name = "buttonAddToWatch";
            this.buttonAddToWatch.Size = new System.Drawing.Size(113, 29);
            this.buttonAddToWatch.TabIndex = 4;
            this.buttonAddToWatch.Text = "Add to Watch";
            this.buttonAddToWatch.UseVisualStyleBackColor = true;
            this.buttonAddToWatch.Click += new System.EventHandler(this.ButtonAddToWatch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Available Bindings";
            // 
            // listBoxAvailableBindings
            // 
            this.listBoxAvailableBindings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAvailableBindings.FormattingEnabled = true;
            this.listBoxAvailableBindings.ItemHeight = 16;
            this.listBoxAvailableBindings.Location = new System.Drawing.Point(7, 149);
            this.listBoxAvailableBindings.Name = "listBoxAvailableBindings";
            this.listBoxAvailableBindings.Size = new System.Drawing.Size(352, 100);
            this.listBoxAvailableBindings.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose a Nut";
            // 
            // comboBoxLocalSites
            // 
            this.comboBoxLocalSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLocalSites.FormattingEnabled = true;
            this.comboBoxLocalSites.Location = new System.Drawing.Point(10, 81);
            this.comboBoxLocalSites.Name = "comboBoxLocalSites";
            this.comboBoxLocalSites.Size = new System.Drawing.Size(349, 24);
            this.comboBoxLocalSites.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(400, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 372);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Watching";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(375, 338);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // textBoxPublicUrl
            // 
            this.textBoxPublicUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPublicUrl.Location = new System.Drawing.Point(97, 106);
            this.textBoxPublicUrl.Name = "textBoxPublicUrl";
            this.textBoxPublicUrl.Size = new System.Drawing.Size(264, 23);
            this.textBoxPublicUrl.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Add Public Url";
            // 
            // buttonAddPublicSite
            // 
            this.buttonAddPublicSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPublicSite.Location = new System.Drawing.Point(247, 406);
            this.buttonAddPublicSite.Name = "buttonAddPublicSite";
            this.buttonAddPublicSite.Size = new System.Drawing.Size(113, 31);
            this.buttonAddPublicSite.TabIndex = 4;
            this.buttonAddPublicSite.Text = "Add to Watch";
            this.buttonAddPublicSite.UseVisualStyleBackColor = true;
            this.buttonAddPublicSite.Click += new System.EventHandler(this.ButtonAddPublicSite_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(798, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPreviousConfigToolStripMenuItem,
            this.loadConfigToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Enabled = false;
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadConfigToolStripMenuItem.Text = "Load Config...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Enabled = false;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.checkBoxIsSitefinity);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboBoxProtocol);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.buttonAddPublicSite);
            this.groupBox3.Controls.Add(this.textBoxPublicUrl);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 443);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // checkBoxIsSitefinity
            // 
            this.checkBoxIsSitefinity.AutoSize = true;
            this.checkBoxIsSitefinity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsSitefinity.Location = new System.Drawing.Point(97, 135);
            this.checkBoxIsSitefinity.Name = "checkBoxIsSitefinity";
            this.checkBoxIsSitefinity.Size = new System.Drawing.Size(94, 21);
            this.checkBoxIsSitefinity.TabIndex = 10;
            this.checkBoxIsSitefinity.Text = "Is Sitefinity";
            this.checkBoxIsSitefinity.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Domain";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Protocol";
            // 
            // comboBoxProtocol
            // 
            this.comboBoxProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            "http",
            "https"});
            this.comboBoxProtocol.Location = new System.Drawing.Point(7, 106);
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.Size = new System.Drawing.Size(84, 24);
            this.comboBoxProtocol.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(349, 34);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sites you want to watch that aren\'t on your computer, like a staging or productio" +
    "n site.";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SquirrelFinder.Forms.Resources.Squirrel;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(681, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 100);
            this.panel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(415, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 39);
            this.label5.TabIndex = 8;
            this.label5.Text = "Squirrel Finder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Keep track of your nuts, without even looking.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(8, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 481);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(378, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local Nuts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(378, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Public Nuts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // loadPreviousConfigToolStripMenuItem
            // 
            this.loadPreviousConfigToolStripMenuItem.Name = "loadPreviousConfigToolStripMenuItem";
            this.loadPreviousConfigToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadPreviousConfigToolStripMenuItem.Text = "Load Previous Config";
            this.loadPreviousConfigToolStripMenuItem.Click += new System.EventHandler(this.loadPreviousConfigToolStripMenuItem_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(814, 560);
            this.MinimumSize = new System.Drawing.Size(814, 560);
            this.Name = "Config";
            this.Text = "Squirrel Finder Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Config_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddToWatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAvailableBindings;
        private System.Windows.Forms.ComboBox comboBoxLocalSites;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxPublicUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddPublicSite;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxIsSitefinity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem loadPreviousConfigToolStripMenuItem;
    }
}