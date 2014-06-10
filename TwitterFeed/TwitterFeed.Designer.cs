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
            this.txtFind1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFeed
            // 
            this.txtFeed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFeed.Location = new System.Drawing.Point(12, 146);
            this.txtFeed.Multiline = true;
            this.txtFeed.Name = "txtFeed";
            this.txtFeed.ReadOnly = true;
            this.txtFeed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFeed.Size = new System.Drawing.Size(268, 379);
            this.txtFeed.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(205, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 110);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(12, 12);
            this.txtFind.MinimumSize = new System.Drawing.Size(4, 40);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(153, 40);
            this.txtFind.TabIndex = 3;
            this.txtFind.Text = "0";
            // 
            // txtFind1
            // 
            this.txtFind1.Location = new System.Drawing.Point(12, 82);
            this.txtFind1.MinimumSize = new System.Drawing.Size(4, 40);
            this.txtFind1.Name = "txtFind1";
            this.txtFind1.Size = new System.Drawing.Size(153, 40);
            this.txtFind1.TabIndex = 4;
            this.txtFind1.Text = "0";
            // 
            // TwitterFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 537);
            this.Controls.Add(this.txtFind1);
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
        private System.Windows.Forms.TextBox txtFind1;

    }
}

