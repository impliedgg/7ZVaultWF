using System.CodeDom;
using System.Diagnostics;
using System.Resources;
using System.Xml;
using System.Xml.Linq;

namespace _7zVaultWF
{
    public partial class WindowVault7z : Form
    {
        private bool locked = true;
        private readonly string vaultpath = $"{Path.GetTempPath()}7zvault-open\\";
        public WindowVault7z()
        {
            InitializeComponent();
        }
        private string Invoke7zip(string args)
        {
            byte[] bytes = (byte[])((new ResourceManager("_7zVaultWF.WindowVault7z", GetType().Assembly)).GetObject("7z.exe"));
            string path = Path.Combine(Path.GetTempPath(), "7zvault-bundled7z.exe");
            File.WriteAllBytes(path, bytes);

            // thanks https://stackoverflow.com/a/206347
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = args;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                p.Start();
                string output = "";
                p.WaitForExit();
                output += p.StandardError.ReadToEnd();
                output += p.StandardOutput.ReadToEnd();
                return output;
            }
            catch (Exception ex)
            {
                lockStatus.Text = "unknown error";
                this.resetText();
                return "OTHERERROR";
            }
        }
        private void LoadForm(object sender, EventArgs e)
        {
            if (Directory.Exists(vaultpath))
            {
                locked = false;
                lockStatus.Text = "Vault is unlocked.";
                openButton.Enabled = true;
                lockButton.Enabled = true;
                unlockButton.Enabled = false;
                string password = File.ReadAllText(vaultpath + ".password");
                passwordText.Text = password;
                passwordText.Enabled = false;
            }
        }
        private void resetText()
        {
            var t = Task.Run(async () =>
            {
                await Task.Delay(5000);
                lockStatus.Invoke( // https://stackoverflow.com/a/52472985
                    (MethodInvoker)delegate
                    {
                        lockStatus.Text = locked ? "Vault is locked." : "Vault is unlocked.";
                    }
                );
            });
        }
        private void OpenVaultFolder(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = $"\"{vaultpath}\"";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            lockStatus.Text = "Opened folder.";
            this.resetText();
        }

        private void UnlockVaultFolder(object sender, EventArgs e)
        {
            string path = filenameText.Text;
            string password = passwordText.Text;
            string args = $"x -o\"{vaultpath}\" -p\"{password}\" \"{path}\"";
            string fail_text_file_doesnt_exist = "The system cannot find the file specified.";
            string fail_text_wrong_pw = "Cannot open encrypted archive. Wrong password?";
            string success_text = "Everything is Ok";

            string output = Invoke7zip(args);

            if (output.Contains(fail_text_file_doesnt_exist))
            {
                lockStatus.Text = "File doesn't exist";
                this.resetText();
            }
            else if (output.Contains(fail_text_wrong_pw))
            {
                lockStatus.Text = "Wrong password";
                this.resetText();
            }
            else if (output.Contains(success_text))
            {
                lockStatus.Text = "Vault unlocked.";
                locked = false;
                openButton.Enabled = true;
                unlockButton.Enabled = false;
                lockButton.Enabled = true;
                passwordText.Enabled = false;
                File.WriteAllText(vaultpath + ".password", passwordText.Text);
                File.SetAttributes(vaultpath + ".password", FileAttributes.Hidden | FileAttributes.ReadOnly);

                this.resetText();
            }
            else if (output == "OTHERERROR")
            {
                // do nothing
            }
        }
        private void LockVaultFolder(object sender, EventArgs e)
        {
            string path = filenameText.Text;
            string password = passwordText.Text;
            string args = $"u \"{path}\" -up1q0r2x2y2z2w2 -xw-!.password -p\"{password}\" -r \"{vaultpath}*\"";
            string fail_text_file_doesnt_exist = "The system cannot find the file specified.";
            string fail_text_wrong_pw = "Cannot open encrypted archive. Wrong password?";
            string success_text = "Everything is Ok";
            string output = Invoke7zip(args);

            if (output.Contains(fail_text_wrong_pw))
            {
                lockStatus.Text = "File updated externally";
                this.resetText();
            }
            else if (output.Contains(success_text))
            {
                lockStatus.Text = "Vault locked.";
                locked = true;
                openButton.Enabled = false;
                unlockButton.Enabled = true;
                lockButton.Enabled = false;
                passwordText.Enabled = true;
                File.SetAttributes(vaultpath + ".password", FileAttributes.Hidden);
                Directory.Delete(vaultpath, true);
                this.resetText();
            }

        }
    }
}
