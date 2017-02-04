namespace EvolutionSoundConvertor_Recoded
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gameSelector = new System.Windows.Forms.ComboBox();
            this.H_dir = new System.Windows.Forms.TextBox();
            this.B_dir = new System.Windows.Forms.TextBox();
            this.F_dir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.H_dirSelector = new System.Windows.Forms.Button();
            this.B_dirSelector = new System.Windows.Forms.Button();
            this.F_dirSelector = new System.Windows.Forms.Button();
            this.outputDir = new System.Windows.Forms.TextBox();
            this.OutputSelector = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Convert = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameSelector
            // 
            this.gameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameSelector.FormattingEnabled = true;
            this.gameSelector.Items.AddRange(new object[] {
            "Dark Sector",
            "Darkness II",
            "Star Trek",
            "Warframe"});
            this.gameSelector.Location = new System.Drawing.Point(12, 12);
            this.gameSelector.Name = "gameSelector";
            this.gameSelector.Size = new System.Drawing.Size(121, 20);
            this.gameSelector.TabIndex = 0;
            // 
            // H_dir
            // 
            this.H_dir.Location = new System.Drawing.Point(12, 73);
            this.H_dir.Name = "H_dir";
            this.H_dir.Size = new System.Drawing.Size(452, 21);
            this.H_dir.TabIndex = 1;
            // 
            // B_dir
            // 
            this.B_dir.Location = new System.Drawing.Point(12, 112);
            this.B_dir.Name = "B_dir";
            this.B_dir.Size = new System.Drawing.Size(452, 21);
            this.B_dir.TabIndex = 2;
            // 
            // F_dir
            // 
            this.F_dir.Location = new System.Drawing.Point(12, 151);
            this.F_dir.Name = "F_dir";
            this.F_dir.Size = new System.Drawing.Size(452, 21);
            this.F_dir.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "H Files Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "B Files Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "F Files Folder";
            // 
            // H_dirSelector
            // 
            this.H_dirSelector.Location = new System.Drawing.Point(470, 71);
            this.H_dirSelector.Name = "H_dirSelector";
            this.H_dirSelector.Size = new System.Drawing.Size(75, 23);
            this.H_dirSelector.TabIndex = 7;
            this.H_dirSelector.Text = "...";
            this.H_dirSelector.UseVisualStyleBackColor = true;
            this.H_dirSelector.Click += new System.EventHandler(this.H_dirSelector_Click);
            // 
            // B_dirSelector
            // 
            this.B_dirSelector.Location = new System.Drawing.Point(470, 110);
            this.B_dirSelector.Name = "B_dirSelector";
            this.B_dirSelector.Size = new System.Drawing.Size(75, 23);
            this.B_dirSelector.TabIndex = 8;
            this.B_dirSelector.Text = "...";
            this.B_dirSelector.UseVisualStyleBackColor = true;
            this.B_dirSelector.Click += new System.EventHandler(this.B_dirSelector_Click);
            // 
            // F_dirSelector
            // 
            this.F_dirSelector.Location = new System.Drawing.Point(470, 149);
            this.F_dirSelector.Name = "F_dirSelector";
            this.F_dirSelector.Size = new System.Drawing.Size(75, 23);
            this.F_dirSelector.TabIndex = 9;
            this.F_dirSelector.Text = "...";
            this.F_dirSelector.UseVisualStyleBackColor = true;
            this.F_dirSelector.Click += new System.EventHandler(this.F_dirSelector_Click);
            // 
            // outputDir
            // 
            this.outputDir.Location = new System.Drawing.Point(12, 190);
            this.outputDir.Name = "outputDir";
            this.outputDir.Size = new System.Drawing.Size(452, 21);
            this.outputDir.TabIndex = 10;
            // 
            // OutputSelector
            // 
            this.OutputSelector.Location = new System.Drawing.Point(470, 190);
            this.OutputSelector.Name = "OutputSelector";
            this.OutputSelector.Size = new System.Drawing.Size(75, 23);
            this.OutputSelector.TabIndex = 11;
            this.OutputSelector.Text = "...";
            this.OutputSelector.UseVisualStyleBackColor = true;
            this.OutputSelector.Click += new System.EventHandler(this.OutputSelector_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Output Folder";
            // 
            // Convert
            // 
            this.Convert.Location = new System.Drawing.Point(470, 242);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(75, 23);
            this.Convert.TabIndex = 13;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 242);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(452, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "DigAtMoon Recoded.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 289);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OutputSelector);
            this.Controls.Add(this.outputDir);
            this.Controls.Add(this.F_dirSelector);
            this.Controls.Add(this.B_dirSelector);
            this.Controls.Add(this.H_dirSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.F_dir);
            this.Controls.Add(this.B_dir);
            this.Controls.Add(this.H_dir);
            this.Controls.Add(this.gameSelector);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Evolution Engine Sound Convertor Recoded";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox gameSelector;
        private System.Windows.Forms.TextBox H_dir;
        private System.Windows.Forms.TextBox B_dir;
        private System.Windows.Forms.TextBox F_dir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button H_dirSelector;
        private System.Windows.Forms.Button B_dirSelector;
        private System.Windows.Forms.Button F_dirSelector;
        private System.Windows.Forms.TextBox outputDir;
        private System.Windows.Forms.Button OutputSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
    }
}

