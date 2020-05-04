namespace webCrawler
{
    partial class MainForm
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
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crawlingButton = new System.Windows.Forms.Button();
            this.s = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.samehostCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxnumTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlTextBox.Location = new System.Drawing.Point(199, 101);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(382, 23);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "enter the URL :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(335, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "The Crawler";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // crawlingButton
            // 
            this.crawlingButton.Location = new System.Drawing.Point(324, 278);
            this.crawlingButton.Name = "crawlingButton";
            this.crawlingButton.Size = new System.Drawing.Size(163, 69);
            this.crawlingButton.TabIndex = 3;
            this.crawlingButton.Text = "Start Crawling";
            this.crawlingButton.UseVisualStyleBackColor = true;
            this.crawlingButton.Click += new System.EventHandler(this.crawlingButton_Click);
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s.Location = new System.Drawing.Point(88, 156);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(104, 17);
            this.s.TabIndex = 5;
            this.s.Text = "Select location:";
            this.s.Click += new System.EventHandler(this.s_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.Location = new System.Drawing.Point(199, 156);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(382, 23);
            this.pathTextBox.TabIndex = 4;
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(625, 156);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(12, 386);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.Size = new System.Drawing.Size(549, 137);
            this.logRichTextBox.TabIndex = 7;
            this.logRichTextBox.Text = "";
            this.logRichTextBox.TextChanged += new System.EventHandler(this.logRichTextBox_TextChanged);
            // 
            // samehostCheckBox
            // 
            this.samehostCheckBox.AutoSize = true;
            this.samehostCheckBox.Location = new System.Drawing.Point(199, 246);
            this.samehostCheckBox.Name = "samehostCheckBox";
            this.samehostCheckBox.Size = new System.Drawing.Size(197, 17);
            this.samehostCheckBox.TabIndex = 8;
            this.samehostCheckBox.Text = "Only save pages from the same host";
            this.samehostCheckBox.UseVisualStyleBackColor = true;
            this.samehostCheckBox.CheckedChanged += new System.EventHandler(this.samehostCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Maximum number of pages:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // maxnumTextBox
            // 
            this.maxnumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxnumTextBox.Location = new System.Drawing.Point(199, 202);
            this.maxnumTextBox.Name = "maxnumTextBox";
            this.maxnumTextBox.Size = new System.Drawing.Size(149, 23);
            this.maxnumTextBox.TabIndex = 9;
            this.maxnumTextBox.TextChanged += new System.EventHandler(this.maxnumTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 535);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxnumTextBox);
            this.Controls.Add(this.samehostCheckBox);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.s);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.crawlingButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button crawlingButton;
        private System.Windows.Forms.Label s;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.CheckBox samehostCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxnumTextBox;
    }
}