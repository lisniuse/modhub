namespace modhub
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.switchModButton = new System.Windows.Forms.Button();
            this.viewSavesButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.modComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.steamIdTextBox = new System.Windows.Forms.TextBox();
            this.disableModButton = new System.Windows.Forms.Button();
            this.launchGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // switchModButton
            // 
            this.switchModButton.Location = new System.Drawing.Point(25, 92);
            this.switchModButton.Name = "switchModButton";
            this.switchModButton.Size = new System.Drawing.Size(100, 22);
            this.switchModButton.TabIndex = 0;
            this.switchModButton.Text = "切换MOD";
            this.switchModButton.UseVisualStyleBackColor = true;
            this.switchModButton.Click += new System.EventHandler(this.switchModButton_Click);
            // 
            // viewSavesButton
            // 
            this.viewSavesButton.Location = new System.Drawing.Point(145, 92);
            this.viewSavesButton.Name = "viewSavesButton";
            this.viewSavesButton.Size = new System.Drawing.Size(90, 22);
            this.viewSavesButton.TabIndex = 1;
            this.viewSavesButton.Text = "查看存档";
            this.viewSavesButton.UseVisualStyleBackColor = true;
            this.viewSavesButton.Click += new System.EventHandler(this.viewSavesButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(145, 121);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(90, 22);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "使用帮助";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择MOD：";
            // 
            // modComboBox
            // 
            this.modComboBox.FormattingEnabled = true;
            this.modComboBox.Location = new System.Drawing.Point(81, 16);
            this.modComboBox.Name = "modComboBox";
            this.modComboBox.Size = new System.Drawing.Size(266, 20);
            this.modComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "SteamID：";
            // 
            // steamIdTextBox
            // 
            this.steamIdTextBox.Location = new System.Drawing.Point(81, 53);
            this.steamIdTextBox.Name = "steamIdTextBox";
            this.steamIdTextBox.Size = new System.Drawing.Size(266, 21);
            this.steamIdTextBox.TabIndex = 7;
            // 
            // disableModButton
            // 
            this.disableModButton.Location = new System.Drawing.Point(25, 120);
            this.disableModButton.Name = "disableModButton";
            this.disableModButton.Size = new System.Drawing.Size(100, 23);
            this.disableModButton.TabIndex = 8;
            this.disableModButton.Text = "禁用MOD";
            this.disableModButton.UseVisualStyleBackColor = true;
            this.disableModButton.Click += new System.EventHandler(this.disableModButton_Click);
            // 
            // launchGameButton
            // 
            this.launchGameButton.Location = new System.Drawing.Point(251, 92);
            this.launchGameButton.Name = "launchGameButton";
            this.launchGameButton.Size = new System.Drawing.Size(96, 22);
            this.launchGameButton.TabIndex = 9;
            this.launchGameButton.Text = "启动游戏";
            this.launchGameButton.UseVisualStyleBackColor = true;
            this.launchGameButton.Click += new System.EventHandler(this.launchGameButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(371, 163);
            this.Controls.Add(this.launchGameButton);
            this.Controls.Add(this.disableModButton);
            this.Controls.Add(this.steamIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.viewSavesButton);
            this.Controls.Add(this.switchModButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "【艾尔登法环】Mod切换工具 v1.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button switchModButton;
        private System.Windows.Forms.Button viewSavesButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox steamIdTextBox;
        private System.Windows.Forms.Button disableModButton;
        private System.Windows.Forms.Button launchGameButton;
    }
}

