using SquirrelFinder;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddToWatch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAvailableBindings = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLocalSites = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxWatching = new System.Windows.Forms.CheckedListBox();
            this.buttonRemoveSelected = new System.Windows.Forms.Button();
            this.textBoxPublicUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddPublicSite = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddToWatch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listBoxAvailableBindings);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxLocalSites);
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 428);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local Sites";
            // 
            // buttonAddToWatch
            // 
            this.buttonAddToWatch.Location = new System.Drawing.Point(248, 398);
            this.buttonAddToWatch.Name = "buttonAddToWatch";
            this.buttonAddToWatch.Size = new System.Drawing.Size(113, 23);
            this.buttonAddToWatch.TabIndex = 4;
            this.buttonAddToWatch.Text = "Add to Watch";
            this.buttonAddToWatch.UseVisualStyleBackColor = true;
            this.buttonAddToWatch.Click += new System.EventHandler(this.buttonAddToWatch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Available Bindings";
            // 
            // listBoxAvailableBindings
            // 
            this.listBoxAvailableBindings.FormattingEnabled = true;
            this.listBoxAvailableBindings.Location = new System.Drawing.Point(9, 173);
            this.listBoxAvailableBindings.Name = "listBoxAvailableBindings";
            this.listBoxAvailableBindings.Size = new System.Drawing.Size(352, 212);
            this.listBoxAvailableBindings.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sites";
            // 
            // comboBoxLocalSites
            // 
            this.comboBoxLocalSites.FormattingEnabled = true;
            this.comboBoxLocalSites.Location = new System.Drawing.Point(9, 38);
            this.comboBoxLocalSites.Name = "comboBoxLocalSites";
            this.comboBoxLocalSites.Size = new System.Drawing.Size(352, 21);
            this.comboBoxLocalSites.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.checkedListBoxWatching);
            this.groupBox2.Controls.Add(this.buttonRemoveSelected);
            this.groupBox2.Location = new System.Drawing.Point(416, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 282);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Watching";
            // 
            // checkedListBoxWatching
            // 
            this.checkedListBoxWatching.FormattingEnabled = true;
            this.checkedListBoxWatching.Location = new System.Drawing.Point(7, 27);
            this.checkedListBoxWatching.Name = "checkedListBoxWatching";
            this.checkedListBoxWatching.Size = new System.Drawing.Size(377, 79);
            this.checkedListBoxWatching.TabIndex = 6;
            // 
            // buttonRemoveSelected
            // 
            this.buttonRemoveSelected.Location = new System.Drawing.Point(259, 112);
            this.buttonRemoveSelected.Name = "buttonRemoveSelected";
            this.buttonRemoveSelected.Size = new System.Drawing.Size(125, 23);
            this.buttonRemoveSelected.TabIndex = 5;
            this.buttonRemoveSelected.Text = "Remove Selected";
            this.buttonRemoveSelected.UseVisualStyleBackColor = true;
            this.buttonRemoveSelected.Click += new System.EventHandler(this.buttonRemoveSelected_Click);
            // 
            // textBoxPublicUrl
            // 
            this.textBoxPublicUrl.Location = new System.Drawing.Point(423, 144);
            this.textBoxPublicUrl.Name = "textBoxPublicUrl";
            this.textBoxPublicUrl.Size = new System.Drawing.Size(296, 20);
            this.textBoxPublicUrl.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Add Public Url";
            // 
            // buttonAddPublicSite
            // 
            this.buttonAddPublicSite.Location = new System.Drawing.Point(725, 141);
            this.buttonAddPublicSite.Name = "buttonAddPublicSite";
            this.buttonAddPublicSite.Size = new System.Drawing.Size(75, 24);
            this.buttonAddPublicSite.TabIndex = 4;
            this.buttonAddPublicSite.Text = "Add";
            this.buttonAddPublicSite.UseVisualStyleBackColor = true;
            this.buttonAddPublicSite.Click += new System.EventHandler(this.buttonAddPublicSite_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(377, 133);
            this.dataGridView1.TabIndex = 7;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 521);
            this.Controls.Add(this.buttonAddPublicSite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPublicUrl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Config";
            this.Text = "Config";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddToWatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAvailableBindings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLocalSites;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListBoxWatching;
        private System.Windows.Forms.Button buttonRemoveSelected;
        private System.Windows.Forms.TextBox textBoxPublicUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddPublicSite;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}