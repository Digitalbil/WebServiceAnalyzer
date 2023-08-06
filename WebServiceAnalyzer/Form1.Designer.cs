namespace WebServiceAnalyzer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGetUrlOrWsdl = new System.Windows.Forms.Button();
            this.listBoxMethods = new System.Windows.Forms.ListBox();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWebserviceName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // buttonGetUrlOrWsdl
            // 
            this.buttonGetUrlOrWsdl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonGetUrlOrWsdl.Location = new System.Drawing.Point(30, 61);
            this.buttonGetUrlOrWsdl.Name = "buttonGetUrlOrWsdl";
            this.buttonGetUrlOrWsdl.Size = new System.Drawing.Size(131, 23);
            this.buttonGetUrlOrWsdl.TabIndex = 2;
            this.buttonGetUrlOrWsdl.Text = "Get URL or WSDL";
            this.buttonGetUrlOrWsdl.UseVisualStyleBackColor = true;
            this.buttonGetUrlOrWsdl.Click += new System.EventHandler(this.buttonGetUrlOrWsdl_Click);
            // 
            // listBoxMethods
            // 
            this.listBoxMethods.FormattingEnabled = true;
            this.listBoxMethods.ItemHeight = 19;
            this.listBoxMethods.Location = new System.Drawing.Point(30, 101);
            this.listBoxMethods.Name = "listBoxMethods";
            this.listBoxMethods.Size = new System.Drawing.Size(354, 346);
            this.listBoxMethods.TabIndex = 3;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(217, 60);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(273, 27);
            this.textBoxUrl.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(496, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Find WSDL Locally";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Webservice Name:";
            // 
            // labelWebserviceName
            // 
            this.labelWebserviceName.AutoSize = true;
            this.labelWebserviceName.Location = new System.Drawing.Point(563, 113);
            this.labelWebserviceName.Name = "labelWebserviceName";
            this.labelWebserviceName.Size = new System.Drawing.Size(33, 19);
            this.labelWebserviceName.TabIndex = 7;
            this.labelWebserviceName.Text = "N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(783, 533);
            this.Controls.Add(this.labelWebserviceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.listBoxMethods);
            this.Controls.Add(this.buttonGetUrlOrWsdl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetUrlOrWsdl;
        private System.Windows.Forms.ListBox listBoxMethods;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelWebserviceName;
    }
}

