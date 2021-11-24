namespace ConsoleApp1
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
            this.gbDataServer = new System.Windows.Forms.GroupBox();
            this.tbDataServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDataServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDataServer
            // 
            this.gbDataServer.Controls.Add(this.tbDataServer);
            this.gbDataServer.Controls.Add(this.label5);
            this.gbDataServer.ForeColor = System.Drawing.Color.Black;
            this.gbDataServer.Location = new System.Drawing.Point(35, 123);
            this.gbDataServer.Name = "gbDataServer";
            this.gbDataServer.Size = new System.Drawing.Size(643, 54);
            this.gbDataServer.TabIndex = 2;
            this.gbDataServer.TabStop = false;
            this.gbDataServer.Text = " Data Server ";
            this.gbDataServer.Enter += new System.EventHandler(this.gbDataServer_Enter);
            // 
            // tbDataServer
            // 
            this.tbDataServer.Location = new System.Drawing.Point(153, 19);
            this.tbDataServer.Margin = new System.Windows.Forms.Padding(4);
            this.tbDataServer.Name = "tbDataServer";
            this.tbDataServer.Size = new System.Drawing.Size(408, 21);
            this.tbDataServer.TabIndex = 1;
            this.tbDataServer.TextChanged += new System.EventHandler(this.tbDataServer_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(82, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Domain :  ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 491);
            this.Controls.Add(this.gbDataServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbDataServer.ResumeLayout(false);
            this.gbDataServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDataServer;
        private System.Windows.Forms.TextBox tbDataServer;
        private System.Windows.Forms.Label label5;
    }
}