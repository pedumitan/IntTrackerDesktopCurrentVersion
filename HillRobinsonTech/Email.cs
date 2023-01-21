using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using Outlook = Microsoft.Office.Interop.Outlook;
using Redemption;
//using EASendMail; //add EASendMail namespace

namespace HillRobinsonTech
{
    public partial class Email : Form
    {
        List<string> attachmentList = new List<string>();

        //RDOSession session = new RDOSession();

        public Email()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tBoxSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {       
            try
            {    
                //Using COM to send email
                Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                int i = 0;
                if(attachmentList.Count > 0)
                    foreach(var item in attachmentList)
                    {
                        mail.Attachments.Add(attachmentList[i]);
                        i++;
                    }
                //mail.From = tBoxFrom.Text;
                mail.To = tBoxTo.Text;
                mail.Subject = tBoxSubject.Text;
                mail.CC = tBoxCc.Text;
                mail.Body = tBoxBody.Text;
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clear();
            this.Dispose();
        }

        public void clear()
        {
            tBoxFrom.Text ="";
            tBoxTo.Text = "";
            tBoxCc.Text = "";
            tBoxSubject.Text = "";
            tBoxBody.Text = "";
            tBoxAttachments.Text = "";

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog attachement = new OpenFileDialog()
            {
                Filter = "All files|*.pdf",
                ValidateNames = true,
                Multiselect = true
        })
            {
                if (attachement.ShowDialog() == DialogResult.OK)
                {
                    int i = 0;
                    if (attachement.SafeFileNames.Length > 0)
                        foreach (var item in attachement.SafeFileNames)
                        {
                            attachmentList.Add(attachement.FileNames[i]);
                            tBoxAttachments.Text += attachement.SafeFileNames[i] + Environment.NewLine;
                            i++;
                        }
                }
            }
        }

        private void btnClearAttachment_Click(object sender, EventArgs e)
        {
            tBoxAttachments.Text = "";
        }
    }
}
