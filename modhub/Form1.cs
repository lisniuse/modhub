using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace modhub
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // 设置窗口初始位置为屏幕中央
            SetFontForAllControls(this, new Font("Microsoft YaHei", this.Font.Size));
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // 禁止拉伸窗口
            this.MaximizeBox = false; // 禁止放大窗口
            this.modComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            // 加载mods
            LoadModsIntoComboBox();
            // 加载SteamId
            LoadSteamID();
        }

        static void CheckAndNotifyDirectory(string expectedDirectoryName)
        {
            // 获取当前可执行文件的完整路径
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            // 获取当前可执行文件所在的目录
            string exeDirectory = Path.GetDirectoryName(exePath);

            // 获取目录的名称
            string directoryName = Path.GetFileName(exeDirectory);

            // 检查目录名称是否与预期的目录名称相匹配
            if (directoryName != expectedDirectoryName)
            {
                MessageBox.Show("错误：当前可执行文件必须位于 '" + "ModHub" + "' 目录下。",
                                "目录错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void CheckForEldenRingExe()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string parentDirectory = Directory.GetParent(Path.GetDirectoryName(exePath)).FullName;

            if (!File.Exists(Path.Combine(parentDirectory, "eldenring.exe")))
            {
                MessageBox.Show("请将当前可执行文件放在游戏根目录下的 'ModHub' 文件夹中。",
                                "文件未找到",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForEldenRingExe();
            CheckAndNotifyDirectory("ModHub");
        }

        private void LoadModsIntoComboBox()
        {
            string[] mods = ModLoader.GetMods();

            if (mods.Length > 0)
            {
                modComboBox.Enabled = true; // 启用下拉框
                modComboBox.Items.Clear();  // 清除现有项
                modComboBox.Items.AddRange(mods); // 添加新项

                // 默认选中第一个选项
                modComboBox.SelectedIndex = 0;
            }
            else
            {
                modComboBox.Enabled = false; // 禁用下拉框
            }
        }

        private void LoadSteamID()
        {
            string steamSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\steam_settings\force_steamid.txt");

            if (File.Exists(steamSettingsPath))
            {
                try
                {
                    string steamId = File.ReadAllText(steamSettingsPath).Trim();
                    steamIdTextBox.Text = steamId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法读取 Steam ID 文件: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    steamIdTextBox.Text = ""; // 文件读取失败时填充空字符串
                }
            }
            else
            {
                steamIdTextBox.Text = ""; // 文件不存在时填充空字符串
            }
        }

        private void SetFontForAllControls(Control control, Font font)
        {
            control.Font = font;
            foreach (Control childControl in control.Controls)
            {
                SetFontForAllControls(childControl, font);
            }
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            // 确保目标目录存在
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            // 复制文件
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            // 递归复制子目录
            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectory(dir, destSubDir);
            }
        }

        private void switchModButton_Click(object sender, EventArgs e)
        {
            string selectedMod = "";
            // 替换字符串插值为字符串连接
            if (modComboBox.SelectedItem != null)
            {
                selectedMod = modComboBox.SelectedItem.ToString();

                // 获取当前可执行文件的完整路径
                string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                // 获取当前可执行文件所在的目录
                string exeDirectory = Path.GetDirectoryName(exePath);

                // 获取当前可执行文件所在目录的上一级目录
                DirectoryInfo parentDirectory = Directory.GetParent(exeDirectory);

                // 拼接sourceFolder路径
                string modsDirectory = Path.Combine(exeDirectory, "mods");
                string sourceFolder = Path.Combine(modsDirectory, selectedMod);
                sourceFolder = Path.Combine(sourceFolder, "mod");

                // 拼接targetFolder路径
                string targetFolder = Path.Combine(parentDirectory.FullName, "mod");

                try
                {
                    if (Directory.Exists(sourceFolder))
                    {
                        // 删除目标文件夹（如果存在）
                        if (Directory.Exists(targetFolder))
                        {
                            Directory.Delete(targetFolder, true);
                        }

                        // 复制源文件夹到目标文件夹
                        CopyDirectory(sourceFolder, targetFolder);
                        MessageBox.Show("已切换到【" + selectedMod + "】", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MessageBox.Show("MOD 切换成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("源MOD文件夹不存在", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法切换MOD: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个MOD", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string steamIdContent = steamIdTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(steamIdContent))
            {
                string steamSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\steam_settings\force_steamid.txt");

                try
                {
                    File.WriteAllText(steamSettingsPath, steamIdContent);
                    MessageBox.Show("Steam ID 已更新", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法更新 Steam ID 文件: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("你没有填写 Steam ID，本次操作只替换MOD不更新SteamID", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void viewSavesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前 Windows 用户名
                string userName = Environment.UserName;
                string savesPath = @"C:\Users\" + userName + @"\AppData\Roaming\EldenRing";
                
                // 打开指定的文件夹
                Process.Start("explorer.exe", savesPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开存档文件夹: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disableModButton_Click(object sender, EventArgs e)
        {
            try
            {
                string modsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\mod");

                if (Directory.Exists(modsFolderPath))
                {
                    // 删除文件夹及其所有内容
                    Directory.Delete(modsFolderPath, true);
                    MessageBox.Show("MOD 文件夹已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("MOD 文件夹不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法删除 MOD 文件夹: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void launchGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                string launcherPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\modengine2_launcher.exe");

                if (File.Exists(launcherPath))
                {
                    // 启动 modengine2_launcher.exe
                    System.Diagnostics.Process.Start(launcherPath);
                }
                else
                {
                    MessageBox.Show("启动器文件不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法启动游戏: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            string helpText =
                "由于有些MOD可能会导致坏档，使用之前请确保你已经备份存档或者已经准备好专门为这个MOD而使用的存档，你可以通过本工具提供的SteamID修改来切换你想使用的存档。\n\n" +
                "界面上的下拉选项会显示 ModHub\\mods\\ 文件夹中的所有文件夹，以供选择需要切换的MOD。\n\n" +
                "请确保你想要切换的MOD在 ModHub 文件夹中的 mods 文件夹中，软件只会拷贝 ModHub\\mods\\你的MOD名称\\mod 这个文件夹到游戏根目录，所以请提前准备好MOD文件并放入 ModHub\\mods 文件夹中。\n\n" +
                "请确保你已经安装好【学习补丁】和【ModEngine】，本工具只负责切换MOD。\n\n" +
                "请确保本工具的EXE本体在游戏根目录下的【ModHub】文件夹中，否则不会生效。\n\n" +
                "点击确定后会跳转到作者提供的B站的教程视频。";

            if (MessageBox.Show(helpText, "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Process.Start("https://www.bilibili.com/video/BV1fChseBEt8/?vd_source=7450636777ddd2bb167444a03008e16d");
            }
        }
    }
}
