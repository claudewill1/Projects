using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TextEditor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            currentFile = "";
            this.Text = "Editor: New Document";
        }

        private string currentFile;
        private int checkPrint;
        public void Find(RichTextBox rtb, String word, Color color)
        {
            if (word == "")
            {
                return;
            }
            
            int s_start = rtb.SelectionStart, startIndex = 0, index;
            lblFind.Visible = true;
            txtFind.Visible = true;
            while ((index =rtb.Text.IndexOf(word,startIndex)) != -1)
            {
                
                rtb.Select(index, word.Length);
                rtb.SelectionColor = color;
                startIndex = index + word.Length;
            }
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionColor = Color.Black;
        }
#region "Menu Methods"    
        private void mnuNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (rtbDoc.Modified)
                {
                    DialogResult answer;
                    answer = MessageBox.Show("The current document has not been saved, would you like to continue without saving?",
                                             "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.No)
                    {
                        currentFile = "";
                        this.Text = "Editor: New Document";
                        rtbDoc.Modified = false;
                        rtbDoc.Clear();
                        return;
                    }
                    else
                    {
                        mnuSave_Click(this, new EventArgs());
                        rtbDoc.Modified = false;
                        rtbDoc.Clear();
                        currentFile = "";
                        this.Text = "Editor: New Document";
                        return;
                    }
                }
                else
                {
                    currentFile = "";
                    this.Text = "Editor: New Document";
                    rtbDoc.Modified = false;
                    rtbDoc.Clear();
                    return;
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuOpen_Click(object sender, System.EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "RTE - Open File";
                openFileDialog1.DefaultExt = "rtf";
                openFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.ShowDialog();

                if (openFileDialog1.FileName == "") return;
                string strExt = "";
                strExt = Path.GetExtension(openFileDialog1.FileName);
                strExt = strExt.ToUpper();

                if (strExt == ".RTF")
                {
                    rtbDoc.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    StreamReader txtReader;
                    txtReader = new StreamReader(openFileDialog1.FileName);
                    rtbDoc.Text = txtReader.ReadToEnd();
                    txtReader.Close();
                    txtReader = null;
                    rtbDoc.SelectionStart = 0;
                    rtbDoc.SelectionLength = 0;
                }
                currentFile = openFileDialog1.FileName;
                rtbDoc.Modified = false;
                this.Text = "Editor: " + currentFile.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(currentFile == string.Empty)
                {
                    mnuSaveAs_Click(this, e);
                    return;
                }
                try
                {
                    string strExt;
                    strExt = Path.GetExtension(currentFile);
                    strExt = strExt.ToUpper();
                    if(strExt == ".RTF")
                    {
                        rtbDoc.SaveFile(currentFile);
                    }
                    else
                    {
                        StreamWriter txtWriter;
                        txtWriter = new StreamWriter(currentFile);
                        txtWriter.Write(rtbDoc.Text);
                        txtWriter.Close();
                        txtWriter = null;
                        rtbDoc.SelectionStart = 0;
                        rtbDoc.SelectionLength = 0;
                        
                    }
                    this.Text = "Editor: " + currentFile.ToString();
                    rtbDoc.Modified = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuSaveAs_Click(object sender, System.EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "RTE - Save File";
                saveFileDialog1.DefaultExt = "rtf";
                saveFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.ShowDialog();
                if(saveFileDialog1.FileName == "")
                {
                    return;
                }
                string strExt;
                strExt = Path.GetExtension(saveFileDialog1.FileName);
                strExt = strExt.ToUpper();
                if(strExt == ".RTF")
                {
                    rtbDoc.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    StreamWriter txtWriter;
                    txtWriter = new StreamWriter(saveFileDialog1.FileName);
                    txtWriter.Write(rtbDoc.Text);
                    txtWriter.Close();
                    txtWriter = null;
                    rtbDoc.SelectionStart = 0;
                    rtbDoc.SelectionLength = 0;
                }
                currentFile = saveFileDialog1.FileName;
                rtbDoc.Modified = false;
                this.Text = "Editor: " + currentFile.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuPrintPreview_Click(object sender, System.EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            if (rtbDoc.Modified)
            {
                DialogResult answer;
                answer = MessageBox.Show("Save this document before closing?", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(answer == DialogResult.No)
                {
                    return;
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
        private void mnuUndo_Click(object sender, System.EventArgs e)
        {
            if (rtbDoc.CanUndo) rtbDoc.Undo();
        }
        private void mnuRedo_Click(object sender, System.EventArgs e)
        {
            if (rtbDoc.CanRedo) rtbDoc.Redo();
        }
        private void mnuFind_Click(object sender, System.EventArgs e)
        {
            try
            {
                Find(rtbDoc, txtFind.Text, Color.Blue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuFindAndReplace_Click(object sender, System.EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuSelectAll_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnCopy_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuCut_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuPaste_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuInsertImage_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuSelectFont_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuBold_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuItalic_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuUnderline_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuNormal_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    fontDialog1.Font = rtbDoc.SelectionFont;
                }
                else
                {
                    fontDialog1.Font = null;
                }
                fontDialog1.ShowApply = true;
                if(fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtbDoc.SelectionFont = fontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }
        private void mnuPageColor_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void mnuNone_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionIndent = 0;
        }
        private void mnuFivePts_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionIndent = 5;
        }
        private void mnuTenPts_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionIndent = 10;
        }
        private void mnuFifteenPts_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionIndent = 15;
        }
        private void mnuTwentyPts_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionIndent = 20;
        }
        private void mnuLeft_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void mnuCenter_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void mnuRight_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void mnuAddBullets_Click(object sender, System.EventArgs e)
        {
            rtbDoc.BulletIndent = 10;
            rtbDoc.SelectionBullet = true;
        }
        private void mnuRemoveBullets_Click(object sender, System.EventArgs e)
        {
            rtbDoc.SelectionBullet = false;
        }
        #endregion

        #region "Toolbar Methods"
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrNew_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrOpen_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrSave_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrFont_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrCenter_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrRight_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrBold_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrItalic_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrUnderline_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void tbrFind_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
