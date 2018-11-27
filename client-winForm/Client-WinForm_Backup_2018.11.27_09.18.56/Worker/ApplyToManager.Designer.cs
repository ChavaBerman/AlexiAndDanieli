namespace Client_WinForm.Worker
{
    partial class ApplyToManager
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
            this.txt_message = new System.Windows.Forms.RichTextBox();
            this.btn_sendApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(81, 107);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(572, 239);
            this.txt_message.TabIndex = 0;
            this.txt_message.Text = "";
            // 
            // btn_sendApply
            // 
            this.btn_sendApply.Location = new System.Drawing.Point(578, 363);
            this.btn_sendApply.Name = "btn_sendApply";
            this.btn_sendApply.Size = new System.Drawing.Size(75, 23);
            this.btn_sendApply.TabIndex = 1;
            this.btn_sendApply.Text = "Send";
            this.btn_sendApply.UseVisualStyleBackColor = true;
            this.btn_sendApply.Click += new System.EventHandler(this.btn_sendApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subject:";
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(265, 56);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(244, 20);
            this.txt_subject.TabIndex = 3;
            // 
            // ApplyToManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sendApply);
            this.Controls.Add(this.txt_message);
            this.Name = "ApplyToManager";
            this.Text = "ApplyToManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_message;
        private System.Windows.Forms.Button btn_sendApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_subject;
    }
}