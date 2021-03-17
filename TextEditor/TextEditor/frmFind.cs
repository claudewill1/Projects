using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
/// <summary>
/// This class provides two methods used to:
/// Find(find the first instance of a search term)
/// Find Next(find other instances of the search term after the first one is found)
/// </summary>
namespace TextEditor
{
    public partial class frmFind : Form
    {
        // local member variable to hold main form
        frmMain mMain;
        public frmFind()
        {
            InitializeComponent();
        }
        public frmFind(frmMain f)
        {
            InitializeComponent();
            mMain = f;
        }

        

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int StartPosition;
                StringComparison SearchType;
                
                if(chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }
                
                StartPosition = mMain.Text.IndexOf(txtSearchTerm.Text, SearchType);

                if(StartPosition == 0)
                {
                    MessageBox.Show("String: " + txtSearchTerm.Text.ToString() + " not found",
                                    "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
               // mMain.Select(StartPosition, txtSearchTerm.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {

        }
        private void frmFind_Load(object sender, EventArgs e)
        {

        }
    }
}
