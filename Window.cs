using System;
using System.IO;
using System.Windows.Forms;

namespace Regalia_Obfuscator
{
    // Author: Marwix (https://github.com/Marwix)
    // Re-creation of my old Regalia obfuscator from 2015.
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.GetItemText(comboBox1.SelectedItem).Equals(string.Empty))
                {
                    MessageBox.Show("Please select chartype and try again. ", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string filename = string.Empty;
                var fd = new OpenFileDialog
                {
                    Multiselect = false,
                    Title = "Select your executable file",
                    Filter = "Executable Files | *.exe",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    CheckFileExists = true,
                    CheckPathExists = true,
                };

                using (fd)
                {
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        filename = fd.FileName;
                    }
                }

                bool result;
                ObfuscationProcess obf = new ObfuscationProcess();
                if (comboBox1.GetItemText(comboBox1.SelectedItem).Equals("Arabic")) 
                {
                    result = obf.Obfuscate(filename, Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".exe", 0, (int)numericUpDown1.Value);
                }
                else if (comboBox1.GetItemText(comboBox1.SelectedItem).Equals("Brille"))
                {
                    result = obf.Obfuscate(filename, Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".exe", 1, (int)numericUpDown1.Value);
                }
                else if (comboBox1.GetItemText(comboBox1.SelectedItem).Equals("Japanese"))
                {
                    result = obf.Obfuscate(filename, Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".exe", 2, (int)numericUpDown1.Value);
                }
                else
                {
                    result = false;
                }

                if (result)
                {
                    MessageBox.Show("Successfully obfuscated file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Something went wrong, could not obfuscate. Try again with another file!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Something went wrong, could not obfuscate. ", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
