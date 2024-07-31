namespace Sklady
{
    partial class MainView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            processingPanel = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            checkBox4 = new System.Windows.Forms.CheckBox();
            checkBox5 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            processingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(18, 590);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(116, 37);
            button1.TabIndex = 0;
            button1.Text = "Process";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar1.Location = new System.Drawing.Point(18, 396);
            progressBar1.Margin = new System.Windows.Forms.Padding(4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(769, 45);
            progressBar1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            richTextBox1.Location = new System.Drawing.Point(385, 66);
            richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(402, 285);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(382, 47);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Errors log:";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Location = new System.Drawing.Point(18, 66);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(360, 286);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 46);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 15);
            label2.TabIndex = 5;
            label2.Text = "Files:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = Properties.Resources.ajax_loader;
            pictureBox1.InitialImage = Properties.Resources.ajax_loader;
            pictureBox1.Location = new System.Drawing.Point(4, 10);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(28, 22);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // processingPanel
            // 
            processingPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            processingPanel.Controls.Add(label3);
            processingPanel.Controls.Add(pictureBox1);
            processingPanel.Location = new System.Drawing.Point(155, 590);
            processingPanel.Margin = new System.Windows.Forms.Padding(4);
            processingPanel.Name = "processingPanel";
            processingPanel.Size = new System.Drawing.Size(200, 34);
            processingPanel.TabIndex = 7;
            processingPanel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(38, 8);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(110, 15);
            label3.TabIndex = 7;
            label3.Text = "Processing results...";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 367);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(108, 15);
            label4.TabIndex = 8;
            label4.Text = "Export preparation:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox1.Location = new System.Drawing.Point(424, 482);
            checkBox1.Margin = new System.Windows.Forms.Padding(4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(116, 21);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "checked if g=г";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox2.Location = new System.Drawing.Point(424, 514);
            checkBox2.Margin = new System.Windows.Forms.Padding(4);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(114, 21);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "checked if l=u";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox3.Location = new System.Drawing.Point(640, 486);
            checkBox3.Margin = new System.Windows.Forms.Padding(4);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(115, 21);
            checkBox3.TabIndex = 11;
            checkBox3.Text = "checked if г=ґ";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(444, 456);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 20);
            label5.TabIndex = 12;
            label5.Text = "For Polish";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(647, 456);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(95, 20);
            label6.TabIndex = 13;
            label6.Text = "For Russian";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox4.Location = new System.Drawing.Point(424, 544);
            checkBox4.Margin = new System.Windows.Forms.Padding(4);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(119, 21);
            checkBox4.TabIndex = 14;
            checkBox4.Text = "checked if ę=е";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox5.Location = new System.Drawing.Point(424, 576);
            checkBox5.Margin = new System.Windows.Forms.Padding(4);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(119, 21);
            checkBox5.TabIndex = 15;
            checkBox5.Text = "checked if ą=о";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // MainView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(processingPanel);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "MainView";
            Size = new System.Drawing.Size(802, 646);
            Load += MainView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            processingPanel.ResumeLayout(false);
            processingPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel processingPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.CheckBox checkBox5;
    }
}
