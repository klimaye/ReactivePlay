namespace TwitterFeed
{
    partial class TwitterFeed
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
            this.txtFeed = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRetweetCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFeed
            // 
            this.txtFeed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFeed.Location = new System.Drawing.Point(12, 137);
            this.txtFeed.Multiline = true;
            this.txtFeed.Name = "txtFeed";
            this.txtFeed.ReadOnly = true;
            this.txtFeed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFeed.Size = new System.Drawing.Size(268, 388);
            this.txtFeed.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(205, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 105);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(96, 25);
            this.txtFind.MinimumSize = new System.Drawing.Size(4, 20);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(90, 20);
            this.txtFind.TabIndex = 3;
            this.txtFind.Text = "e3";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(96, 62);
            this.txtTag.MinimumSize = new System.Drawing.Size(4, 20);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(90, 20);
            this.txtTag.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Handle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tag";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Retweet Count";
            // 
            // txtRetweetCount
            // 
            this.txtRetweetCount.Location = new System.Drawing.Point(96, 97);
            this.txtRetweetCount.MinimumSize = new System.Drawing.Size(4, 20);
            this.txtRetweetCount.Name = "txtRetweetCount";
            this.txtRetweetCount.Size = new System.Drawing.Size(90, 20);
            this.txtRetweetCount.TabIndex = 7;
            this.txtRetweetCount.Text = "0";
            // 
            // TwitterFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 537);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRetweetCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFeed);
            this.Name = "TwitterFeed";
            this.Text = "Feed";
            this.Load += new System.EventHandler(this.TwitterFeed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFeed;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRetweetCount;

    }
}

