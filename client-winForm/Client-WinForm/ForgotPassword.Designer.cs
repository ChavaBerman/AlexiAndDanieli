namespace Client_WinForm
{
    partial class ForgotPassword
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
            this.txt_worker_name = new System.Windows.Forms.TextBox();
            this.txt_email_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_send_email = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_worker_name
            // 
            this.txt_worker_name.Location = new System.Drawing.Point(267, 63);
            this.txt_worker_name.Name = "txt_worker_name";
            this.txt_worker_name.Size = new System.Drawing.Size(166, 20);
            this.txt_worker_name.TabIndex = 0;
            // 
            // txt_email_address
            // 
            this.txt_email_address.Location = new System.Drawing.Point(267, 138);
            this.txt_email_address.Name = "txt_email_address";
            this.txt_email_address.Size = new System.Drawing.Size(166, 20);
            this.txt_email_address.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Worker name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email address";
            // 
            // btn_send_email
            // 
            this.btn_send_email.Location = new System.Drawing.Point(288, 216);
            this.btn_send_email.Name = "btn_send_email";
            this.btn_send_email.Size = new System.Drawing.Size(130, 40);
            this.btn_send_email.TabIndex = 4;
            this.btn_send_email.Text = "Send me a new password";
            this.btn_send_email.UseVisualStyleBackColor = true;
            this.btn_send_email.Click += new System.EventHandler(this.btn_send_email_Click);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_send_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_email_address);
            this.Controls.Add(this.txt_worker_name);
            this.Name = "ForgotPassword";
            this.Text = "ForgotPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_worker_name;
        private System.Windows.Forms.TextBox txt_email_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_send_email;
    }
}