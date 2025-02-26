using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOPAnote
{
    public partial class ReplaceForm : Form
    {
        public static ReplaceForm instance;


        public ReplaceForm()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            string[] MyTextFind = txtboxfind.Text.Split(',');
            int StartIndex = 0;
            foreach (string textfind in MyTextFind)
            {
                while (StartIndex < dopatxt.instance.rtb1.TextLength)
                {
                    int wordstartindex = dopatxt.instance.rtb1.Find(textfind, StartIndex, RichTextBoxFinds.None);
                    if (wordstartindex != -1)
                    {
                        dopatxt.instance.rtb1.SelectionStart = wordstartindex;
                        dopatxt.instance.rtb1.SelectionLength = textfind.Length;
                        dopatxt.instance.rtb1.SelectionBackColor = Color.Yellow;

                    }
                    else
                    {
                      //  MessageBox.Show("We didn't find it, try again another words", "UnSuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                        StartIndex++;
                     //   StartIndex = wordstartindex + textfind.Length;
                    





                }

            }
            if (dopatxt.instance.rtb1.SelectionBackColor == Color.Yellow)
            {
                MessageBox.Show("We did find it", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtboxfind.Clear();
            txtboxreplace.Clear();
        }

        private void ReplaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            dopatxt.instance.rtb1.SelectAll();
            dopatxt.instance.rtb1.SelectionBackColor = Color.WhiteSmoke;
            dopatxt.instance.rtb1.DeselectAll();
        }

        private void btnreplace_Click(object sender, EventArgs e)
        {
            string[] MyTextFind = txtboxfind.Text.Split(',');
            int StartIndex = 0;
            bool isreplaced = true;
            foreach (string textfind in MyTextFind)
            {
                while (StartIndex < dopatxt.instance.rtb1.TextLength)
                {
                    int wordstartindex = dopatxt.instance.rtb1.Find(textfind, StartIndex, RichTextBoxFinds.None);
                    if (wordstartindex != -1)
                    {
                        dopatxt.instance.rtb1.SelectionStart = wordstartindex;
                        dopatxt.instance.rtb1.SelectionLength = textfind.Length;
                        dopatxt.instance.rtb1.SelectionBackColor = Color.Yellow;
                        dopatxt.instance.rtb1.SelectedText = txtboxreplace.Text;
                        isreplaced = true;

                    }
                    else
                    {
                        isreplaced = false;
                          MessageBox.Show("We didn't find it, try again another words", "UnSuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                    StartIndex++;
                   // StartIndex+= wordstartindex + textfind.Length;
                    break;





                }

            }
            if (isreplaced == true)
            {
                MessageBox.Show("Congratulation,is replaced!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnreplaceall_Click(object sender, EventArgs e)
        {
            
            string[] MyTextFind = txtboxfind.Text.Split(',');
            int StartIndex = 0;
            bool isreplaced = true;
            foreach (string textfind in MyTextFind)
            {
                
                while (StartIndex < dopatxt.instance.rtb1.TextLength)
                {
                    int wordstartindex = dopatxt.instance.rtb1.Find(textfind, StartIndex, RichTextBoxFinds.None);
                    if (wordstartindex != -1 )
                    {
                        dopatxt.instance.rtb1.SelectionStart = wordstartindex;
                        dopatxt.instance.rtb1.SelectionLength = textfind.Length;
                        dopatxt.instance.rtb1.SelectionBackColor = Color.Yellow;
                        dopatxt.instance.rtb1.SelectedText = txtboxreplace.Text;
                        isreplaced = true;

                    }
                    else
                    {
                        isreplaced = false;
                         // MessageBox.Show("We didn't find it, try again another words", "UnSuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                  
                    StartIndex++;
                    





                }
               

            }
            if (isreplaced==true)
            {
                MessageBox.Show("Congratulation,is replaced!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {
            if (dopatxt.instance.TranslateReplaceForm == "Arabic")
            {
                this.Text = "بحث و تبديل";
                lbfind.Text = "بحث : ";
                lbreplace.Text = " تبديل بـ: ";
                btnfind.Text = "بحث";
                btnreplace.Text = "تبديل";
                btnreplaceall.Text = "تبديل الكل";
                btnclear.Text = "تنظيف";
            }
            else if (dopatxt.instance.TranslateReplaceForm == "Russian")
            {
                this.Text = "Заменить И Искать";
                lbfind.Text = "Искать: ";
                lbreplace.Text = " Заменить на: ";
                btnfind.Text = "Искать";
                btnreplace.Text = "Заменить";
                btnreplaceall.Text = "Заменить все";
                btnclear.Text = "Очистить";
            }
            else
            {

            }
        }
    }
}
