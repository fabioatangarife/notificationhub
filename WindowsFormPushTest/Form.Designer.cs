namespace WindowsFormPushTest
{
    partial class Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tag = new System.Windows.Forms.ComboBox();
            this.sender = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.messagetext = new System.Windows.Forms.TextBox();
            this.state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hi Gapster Admin!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select a Tag to send notification";
            // 
            // tag
            // 
            this.tag.FormattingEnabled = true;
            this.tag.Items.AddRange(new object[] {
            "mde_net",
            "gap_latam"});
            this.tag.Location = new System.Drawing.Point(198, 68);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(163, 21);
            this.tag.TabIndex = 2;
            this.tag.Text = "mde_net";
            // 
            // sender
            // 
            this.sender.Location = new System.Drawing.Point(34, 139);
            this.sender.Name = "sender";
            this.sender.Size = new System.Drawing.Size(75, 23);
            this.sender.TabIndex = 3;
            this.sender.Text = "Send";
            this.sender.UseVisualStyleBackColor = true;
            this.sender.Click += new System.EventHandler(this.Sender_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message";
            // 
            // messagetext
            // 
            this.messagetext.Location = new System.Drawing.Point(198, 95);
            this.messagetext.Name = "messagetext";
            this.messagetext.Size = new System.Drawing.Size(163, 20);
            this.messagetext.TabIndex = 5;
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(31, 188);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(0, 13);
            this.state.TabIndex = 6;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 302);
            this.Controls.Add(this.state);
            this.Controls.Add(this.messagetext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sender);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form";
            this.Text = "GAP Notification sender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tag;
        private System.Windows.Forms.Button sender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox messagetext;
        private System.Windows.Forms.Label state;
    }
}

