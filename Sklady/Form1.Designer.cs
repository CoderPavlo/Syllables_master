namespace Sklady
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            charactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            mainView1 = new MainView();
            tabPage2 = new System.Windows.Forms.TabPage();
            testView1 = new TestView();
            tabPage4 = new System.Windows.Forms.TabPage();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            tabPage3 = new System.Windows.Forms.TabPage();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            button11 = new System.Windows.Forms.Button();
            dataGridView6 = new System.Windows.Forms.DataGridView();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dataGridView5 = new System.Windows.Forms.DataGridView();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            button6 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            dataGridView2 = new System.Windows.Forms.DataGridView();
            tabPage5 = new System.Windows.Forms.TabPage();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            dataGridView3 = new System.Windows.Forms.DataGridView();
            tabPage6 = new System.Windows.Forms.TabPage();
            button9 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            dataGridView4 = new System.Windows.Forms.DataGridView();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(927, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, settingsToolStripMenuItem, charactersToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // charactersToolStripMenuItem
            // 
            charactersToolStripMenuItem.Name = "charactersToolStripMenuItem";
            charactersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            charactersToolStripMenuItem.Text = "Characters";
            charactersToolStripMenuItem.Click += charactersToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 24);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(927, 609);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(mainView1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage1.Size = new System.Drawing.Size(919, 581);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // mainView1
            // 
            mainView1.Dock = System.Windows.Forms.DockStyle.Fill;
            mainView1.InputData = null;
            mainView1.Location = new System.Drawing.Point(4, 4);
            mainView1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            mainView1.Name = "mainView1";
            mainView1.Size = new System.Drawing.Size(911, 573);
            mainView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(testView1);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage2.Size = new System.Drawing.Size(843, 584);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Test";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // testView1
            // 
            testView1.Dock = System.Windows.Forms.DockStyle.Fill;
            testView1.Location = new System.Drawing.Point(4, 4);
            testView1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            testView1.Name = "testView1";
            testView1.Size = new System.Drawing.Size(835, 576);
            testView1.TabIndex = 1;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dataGridView1);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(843, 584);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Texts Statistics";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(4, 32);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new System.Drawing.Size(836, 480);
            dataGridView1.TabIndex = 2;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(progressBar1);
            tabPage3.Controls.Add(button11);
            tabPage3.Controls.Add(dataGridView6);
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(dataGridView5);
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(button1);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(dataGridView2);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(843, 584);
            tabPage3.TabIndex = 4;
            tabPage3.Text = "Words Statistics(EN)";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar1.Location = new System.Drawing.Point(36, 424);
            progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(769, 20);
            progressBar1.TabIndex = 26;
            // 
            // button11
            // 
            button11.Location = new System.Drawing.Point(323, 462);
            button11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(139, 38);
            button11.TabIndex = 25;
            button11.Text = "Open folder";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // dataGridView6
            // 
            dataGridView6.AllowUserToAddRows = false;
            dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView6.ColumnHeadersVisible = false;
            dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column2 });
            dataGridView6.Location = new System.Drawing.Point(734, 37);
            dataGridView6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dataGridView6.Name = "dataGridView6";
            dataGridView6.RowHeadersVisible = false;
            dataGridView6.RowHeadersWidth = 82;
            dataGridView6.Size = new System.Drawing.Size(102, 359);
            dataGridView6.TabIndex = 24;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(729, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 21);
            label2.TabIndex = 23;
            label2.Text = "Приголосні:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(640, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 21);
            label1.TabIndex = 22;
            label1.Text = "Голосні:";
            // 
            // dataGridView5
            // 
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.ColumnHeadersVisible = false;
            dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column1 });
            dataGridView5.Location = new System.Drawing.Point(626, 37);
            dataGridView5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.RowHeadersVisible = false;
            dataGridView5.RowHeadersWidth = 82;
            dataGridView5.Size = new System.Drawing.Size(102, 359);
            dataGridView5.TabIndex = 21;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(572, 464);
            button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(119, 38);
            button6.TabIndex = 20;
            button6.Text = "Export Results";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += button6_Click_1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(154, 462);
            button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(139, 38);
            button1.TabIndex = 19;
            button1.Text = "Open txt file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(259, 508);
            button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(88, 26);
            button3.TabIndex = 18;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new System.Drawing.Point(4, 12);
            dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new System.Drawing.Size(612, 392);
            dataGridView2.TabIndex = 17;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(button5);
            tabPage5.Controls.Add(button4);
            tabPage5.Controls.Add(button2);
            tabPage5.Controls.Add(dataGridView3);
            tabPage5.Location = new System.Drawing.Point(4, 24);
            tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new System.Drawing.Size(843, 584);
            tabPage5.TabIndex = 5;
            tabPage5.Text = "Words Statistics(UA/RU/BG)";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(678, 461);
            button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(119, 38);
            button5.TabIndex = 4;
            button5.Text = "Export Results";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(365, 472);
            button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(88, 26);
            button4.TabIndex = 3;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(343, 428);
            button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(139, 38);
            button2.TabIndex = 2;
            button2.Text = "Open txt file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new System.Drawing.Point(46, 15);
            dataGridView3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 82;
            dataGridView3.Size = new System.Drawing.Size(752, 392);
            dataGridView3.TabIndex = 1;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(button9);
            tabPage6.Controls.Add(button8);
            tabPage6.Controls.Add(button7);
            tabPage6.Controls.Add(dataGridView4);
            tabPage6.Location = new System.Drawing.Point(4, 24);
            tabPage6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new System.Drawing.Size(843, 584);
            tabPage6.TabIndex = 6;
            tabPage6.Text = "Words Statistics(PL)";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(678, 461);
            button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(119, 38);
            button9.TabIndex = 5;
            button9.Text = "Export Results";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(365, 472);
            button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(88, 26);
            button8.TabIndex = 5;
            button8.Text = "Clear";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(343, 428);
            button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(139, 38);
            button7.TabIndex = 5;
            button7.Text = "Open txt file";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new System.Drawing.Point(46, 15);
            dataGridView4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.RowHeadersWidth = 82;
            dataGridView4.Size = new System.Drawing.Size(752, 392);
            dataGridView4.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(927, 633);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Syllables Processor";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView6).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TestView testView1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charactersToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button5;
        public MainView mainView1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

