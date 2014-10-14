using NotAQuest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace NotAQuestEditor
{
    public partial class MainForm : Form
    {
        private List<Dialog> Dialogs = new List<Dialog>();
        private List<Reply> Replies = new List<Reply>();
        private object dragged = null;
        private Dialog currentDialog = null;
        private Reply currentReply = null;

        private bool replyModified = false, dialogModified = false, saved = true;

        public MainForm()
        {
            InitializeComponent();
            fdOpen.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            fdSave.InitialDirectory = fdOpen.InitialDirectory;
            ClearAll();
        }

        private void btnRemoveReply_Click(object sender, EventArgs e)
        {
            if (lbReplies.SelectedItem != null)
            {
                Replies.Remove(lbReplies.SelectedItem as Reply);
                lbReplies.Items.Remove(lbReplies.SelectedItem);
                foreach (Dialog d in Dialogs)
                    d.Replies.Remove(lbReplies.SelectedItem as Reply);
                currentReply = null;
                saved = false;
            }
        }

        private void btnAddReply_Click(object sender, EventArgs e)
        {
            Reply reply = new Reply("reply" + Replies.Count.ToString(), "");
            Replies.Add(reply);
            lbReplies.Items.Add(reply);
            lbReplies.SelectedItem = reply;
            saved = false;
        }

        private void lbDialogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoSaveOnSwitchToolStripMenuItem.Checked)
                btnDialogApply_Click(null, null);

            if (lbDialogs.SelectedItem != null)
            {
                currentDialog = lbDialogs.SelectedItem as Dialog;
                tbDialogId.Text = currentDialog.ID;
                tbDialogText.Text = currentDialog.Text;
                lbDialogReplies.Items.Clear();
                lbDialogReplies.Items.AddRange(currentDialog.Replies.ToArray());               

                dialogModified = false;
            }            
        }

        private void lbReplies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoSaveOnSwitchToolStripMenuItem.Checked)
                btnReplyApply_Click(null, null);

            if (lbReplies.SelectedItem != null)
            {
                currentReply = lbReplies.SelectedItem as Reply;
                tbReplyId.Text = currentReply.ID;
                tbReplyText.Text = currentReply.Text;
                if (currentReply.NextDialog == null)
                    cbNextDialog.SelectedIndex = 0;
                else
                    cbNextDialog.SelectedItem = currentReply.NextDialog;

                tbReplyActions.Clear();
                foreach (ScriptAction a in currentReply.Actions)
                    tbReplyActions.Text += a.Action + " " + string.Join(" ", a.Params) + Environment.NewLine;

                replyModified = false;
            }            
        }

        private void btnReplyApply_Click(object sender, EventArgs e)
        {
            if (currentReply != null && replyModified)
            {                
                foreach (Reply r in Replies)
                    if (r != currentReply && r.ID == tbReplyId.Text.Trim())
                    {
                        MessageBox.Show("ID реплики не уникален");
                        return;
                    }
                currentReply.ID = tbReplyId.Text.Trim();
                currentReply.Text = tbReplyText.Text;
                if (cbNextDialog.SelectedText.Equals("null", StringComparison.InvariantCultureIgnoreCase) || cbNextDialog.SelectedItem == null)
                    currentReply.NextDialog = null;
                else
                    currentReply.NextDialog = cbNextDialog.SelectedItem as Dialog;

                // Parse actions
                currentReply.Actions.Clear();
                string[] lines = tbReplyActions.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] spl = line.Split(' ');
                    ScriptAction a = new ScriptAction();
                    a.Action = spl[0];
                    a.Params = new string[spl.Length - 1];
                    for (int i = 1; i < spl.Length; i++)
                        a.Params[i - 1] = spl[i];
                    currentReply.Actions.Add(a);
                }
                replyModified = false;
                saved = false;

                UpdateAll();
            }
        }

        private void btnAddDialog_Click(object sender, EventArgs e)
        {
            Dialog dialog = new Dialog("dialog" + Dialogs.Count.ToString(), "");
            Dialogs.Add(dialog);
            lbDialogs.Items.Add(dialog);
            lbDialogs.SelectedItem = dialog;
            cbNextDialog.Items.Add(dialog);
            saved = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbDialogs.SelectedItem != null)
            {
                Dialog dialog = lbDialogs.SelectedItem as Dialog; 
                Dialogs.Remove(dialog);
                lbDialogs.Items.Remove(dialog);
                
                foreach (Reply r in Replies)
                    if (r.NextDialog == dialog)
                        r.NextDialog = null;

                cbNextDialog.Items.Remove(dialog);
                currentDialog = null;
                saved = false;
            }
        }

        private void btnDialogApply_Click(object sender, EventArgs e)
        {
            if (currentDialog != null && dialogModified)
            {                
                foreach (Dialog d in Dialogs)
                    if (d != currentDialog && d.ID == tbDialogId.Text.Trim())
                    {
                        MessageBox.Show("ID диалога не уникален");
                        return;
                    }
                currentDialog.ID = tbDialogId.Text.Trim();
                currentDialog.Text = tbDialogText.Text;
                currentDialog.Replies.Clear();
                currentDialog.Replies.AddRange(lbDialogReplies.Items.Cast<Reply>());

                dialogModified = false;
                saved = false;
                
                UpdateAll();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdSave.ShowDialog() == DialogResult.OK)
            {
                // Apply all
                btnReplyApply_Click(null, null);
                btnDialogApply_Click(null, null);

                XmlTextWriter wr = new XmlTextWriter(fdSave.FileName, Encoding.Default);
                wr.WriteStartDocument();
                wr.WriteStartElement("Episode");
                
                wr.WriteStartElement("Dialogs");
                foreach (Dialog d in Dialogs)
                {
                    wr.WriteStartElement("Dialog");
                    wr.WriteElementString("Id", d.ID);
                    wr.WriteElementString("Text", d.Text);
                    
                    wr.WriteStartElement("DialogReplies");
                    foreach (Reply r in d.Replies)
                        wr.WriteElementString("ReplyId", r.ID);
                    wr.WriteEndElement();

                    wr.WriteEndElement(); // Dialog
                }
                wr.WriteEndElement(); // Dialogs

                wr.WriteStartElement("Replies");
                foreach (Reply r in Replies)
                {
                    wr.WriteStartElement("Reply");
                    wr.WriteElementString("Id", r.ID);
                    wr.WriteElementString("Text", r.Text);
                    wr.WriteElementString("NextDialogId", r.NextDialog == null ? "NULL" : r.NextDialog.ID);
                    
                    wr.WriteStartElement("Actions");
                    foreach (ScriptAction a in r.Actions)
                    {
                        wr.WriteStartElement("Action");
                        wr.WriteElementString("Command", a.Action);
                        
                        wr.WriteStartElement("Params");
                        foreach (string param in a.Params)
                        {
                            wr.WriteElementString("Param", param);
                        }
                        wr.WriteEndElement();
                        
                        wr.WriteEndElement();
                    }
                    wr.WriteEndElement();
                    
                    wr.WriteEndElement(); // Reply
                }
                wr.WriteEndElement();

                wr.WriteEndElement(); // Episode
                wr.WriteEndDocument();                
                wr.Close();

                saved = true;
            }
        }

        private void ClearAll()
        {
            tbDialogId.Clear();
            tbDialogText.Clear();
            tbReplyId.Clear();
            tbReplyText.Clear();
            tbReplyActions.Clear();
            cbNextDialog.Items.Clear();
            cbNextDialog.Items.Add("null");
            cbNextDialog.SelectedIndex = 0;
            lbDialogReplies.Items.Clear();
            lbReplies.Items.Clear();
            lbDialogs.Items.Clear();

            Dialogs.Clear();
            Replies.Clear();

            dialogModified = false;
            replyModified = false;

            currentDialog = null;
            currentReply = null;
        }

        private void UpdateAll()
        {
            int s = cbNextDialog.SelectedIndex;
            bool oldReplyModified = replyModified;
            cbNextDialog.Items.Clear();
            cbNextDialog.Items.Add("null");
            cbNextDialog.Items.AddRange(Dialogs.ToArray());
            if (s >= 0)
                cbNextDialog.SelectedIndex = s;
            replyModified = oldReplyModified;
            

            s = lbReplies.SelectedIndex;
            lbReplies.Items.Clear();
            lbReplies.Items.AddRange(Replies.ToArray());
            if (s >= 0)
                lbReplies.SelectedIndex = s;

            s = lbDialogs.SelectedIndex;
            lbDialogs.Items.Clear();
            lbDialogs.Items.AddRange(Dialogs.ToArray());
            if (s >= 0)
                lbDialogs.SelectedIndex = s;
            
            lbDialogReplies.Items.Clear();
            if (lbDialogs.SelectedItem != null)            
                lbDialogReplies.Items.AddRange((lbDialogs.SelectedItem as Dialog).Replies.ToArray());            
        }

        private Reply GetReply(string id)
        {
            foreach (Reply r in Replies)
                if (r.ID == id)
                    return r;
            throw new Exception(string.Format("Реплика с ID `{0}` не найдена", id));
        }

        private Dialog GetDialog(string id)
        {
            foreach (Dialog d in Dialogs)
                if (d.ID == id)
                    return d;
            throw new Exception(string.Format("Диалог с ID `{0}` не найден", id));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdOpen.ShowDialog() == DialogResult.OK)
            {
                ClearAll();

                XmlDocument doc = new XmlDocument();
                doc.Load(fdOpen.FileName);
                foreach (XmlNode node in doc.SelectNodes("/Episode/Dialogs/Dialog"))
                {
                    Dialog dialog = new Dialog(node.SelectSingleNode("Id").InnerText, node.SelectSingleNode("Text").InnerText);                    
                    Dialogs.Add(dialog);
                    lbDialogs.Items.Add(dialog);
                    cbNextDialog.Items.Add(dialog);
                }

                foreach (XmlNode node in doc.SelectNodes("/Episode/Replies/Reply"))
                {
                    Reply reply = new Reply(node.SelectSingleNode("Id").InnerText, node.SelectSingleNode("Text").InnerText);
                    string nextDialogId = node.SelectSingleNode("NextDialogId").InnerText;
                    reply.NextDialog = nextDialogId.Equals("NULL", StringComparison.InvariantCultureIgnoreCase) ? null : GetDialog(nextDialogId);

                    foreach (XmlNode actionNode in node.SelectNodes("Actions/Action"))
                    {
                        ScriptAction a = new ScriptAction();
                        a.Action = actionNode.SelectSingleNode("Command").InnerText;
                        XmlNodeList paramNodes = actionNode.SelectNodes("Params/Param");                        
                        a.Params = new string[paramNodes.Count];
                        for (int i = 0; i < paramNodes.Count; i++)
                            a.Params[i] = paramNodes[i].InnerText;
                        reply.Actions.Add(a);
                    }

                    Replies.Add(reply);
                    lbReplies.Items.Add(reply);

                }

                // Еще раз, для реплик у каждого диалога
                foreach (XmlNode node in doc.SelectNodes("/Episode/Dialogs/Dialog"))
                {
                    Dialog dialog = GetDialog(node.SelectSingleNode("Id").InnerText);
                    foreach (XmlNode replyNode in node.SelectNodes("DialogReplies/ReplyId"))                    
                        dialog.Replies.Add(GetReply(replyNode.InnerText));                    
                }
                
            }
        }  

        private void lbReplies_MouseDown(object sender, MouseEventArgs e)
        {
            dragged = null;        
            int index = lbReplies.IndexFromPoint(e.X, e.Y);
            if (index < 0)
                return;
            dragged = lbReplies.Items[index];            
            lbReplies.DoDragDrop(dragged.ToString(), DragDropEffects.All);
            lbReplies_SelectedIndexChanged(null, null);
        }        

        private void lbDialogReplies_DragDrop(object sender, DragEventArgs e)
        {
            if (lbDialogReplies.Items.IndexOf(dragged) < 0)
            {
                lbDialogReplies.Items.Add(dragged);
                dialogModified = true;
            }
            dragged = null;
        }

        private void lbDialogReplies_DragEnter(object sender, DragEventArgs e)
        {            
            e.Effect = DragDropEffects.Copy;         
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void lbDialogReplies_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbDialogReplies.SelectedItem != null)
            {
                lbDialogReplies.Items.Remove(lbDialogReplies.SelectedItem);
                dialogModified = true;
            }
        }

        private void tbDialogId_TextChanged(object sender, EventArgs e)
        {
            dialogModified = true;
        }

        private void tbReplyId_TextChanged(object sender, EventArgs e)
        {
            replyModified = true;
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "NotAQuest.exe";
            process.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved || replyModified || dialogModified)
                switch (MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                { 
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);                        
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }

        }

    }
}