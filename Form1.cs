using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notatnik
{
    public partial class Notatnik : Form
    {
        public Notatnik()
        {
            InitializeComponent();
        }
        SaveFileDialog save = new SaveFileDialog();
        OpenFileDialog open = new OpenFileDialog();
        public void NewFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox.Text))
                {
                    MessageBox.Show("Musisz najpierw zapisać");
                }
                else
                {
                    this.richTextBox.Text = string.Empty;
                    this.Text = "untitled";
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
        public void Save()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox.Text))
                {
                    save.Filter = "Text File (*.txt) | *.txt";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, this.richTextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("File is empty!");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        public void SaveFileAs()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox.Text))
                {
                    save.Filter = "Text File (*.txt) | *.txt! | All Files (*.*)| *.*";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, this.richTextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("File is empty!");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Save();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string text = this.richTextBox.SelectedText;
            if (!string.IsNullOrEmpty(text)) //copy selected text if richTextBox is not empty
            {
                Clipboard.SetText(text);
            }
            else //if user did not select text, copy everything from richTextBox
            {
                text = this.richTextBox.Text;
                Clipboard.SetText(text);

            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)   
        {
            richTextBox.Undo();
           
        }

        private void selectAllWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();   //closing app
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();  //cut selected text
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
            {
                cutToolStripMenuItem.Enabled = true;    //if text is selected enable cut tool strip
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;   //if text is not selected disable cut tool strip
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox.Text = File.ReadAllText(open.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd przy otwieraniu pliku");
            }
            finally
            {
                open = null;
            }
        }
    }
}
