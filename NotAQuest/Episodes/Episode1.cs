using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace NotAQuest.Episodes
{
    partial class EpisodeLoader
    {
        public const string FILE_EPISODE1 = "episode1.ep";

        private static Episode LoadFromFile(string fileName)
        {
            Episode e = new Episode(null);
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            foreach (XmlNode node in doc.SelectNodes("/Episode/Dialogs/Dialog"))
            {
                Dialog dialog = new Dialog(node.SelectSingleNode("Id").InnerText, node.SelectSingleNode("Text").InnerText);
                e.Dialogs.Add(dialog);
            }

            foreach (XmlNode node in doc.SelectNodes("/Episode/Replies/Reply"))
            {
                Reply reply = new Reply(node.SelectSingleNode("Id").InnerText, node.SelectSingleNode("Text").InnerText);
                string nextDialogId = node.SelectSingleNode("NextDialogId").InnerText;
                reply.NextDialog = nextDialogId.Equals("NULL", StringComparison.InvariantCultureIgnoreCase) ? null : e.GetDialog(nextDialogId);

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

                e.Replies.Add(reply);

            }

            // Еще раз, для реплик у каждого диалога
            foreach (XmlNode node in doc.SelectNodes("/Episode/Dialogs/Dialog"))
            {
                Dialog dialog = e.GetDialog(node.SelectSingleNode("Id").InnerText);
                foreach (XmlNode replyNode in node.SelectNodes("DialogReplies/ReplyId"))
                    dialog.Replies.Add(e.GetReply(replyNode.InnerText));
            }

            e.CurrentDialog = e.GetDialog("start");
            return e;
        }

        public static Episode Episode1()
        {
            return LoadFromFile(FILE_EPISODE1);
        }

        public static void ResetEpisode(Episode episode, string fileName)
        {            
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            foreach (XmlNode node in doc.SelectNodes("/Episode/Dialogs/Dialog"))
            {
                Dialog dialog = episode.GetDialog(node.SelectSingleNode("Id").InnerText);
                dialog.Text = node.SelectSingleNode("Text").InnerText;
            }

            foreach (XmlNode node in doc.SelectNodes("/Episode/Replies/Reply"))
            {
                Reply reply = episode.GetReply(node.SelectSingleNode("Id").InnerText);
                reply.Text = node.SelectSingleNode("Text").InnerText;
                string nextDialogId = node.SelectSingleNode("NextDialogId").InnerText;
                reply.NextDialog = nextDialogId.Equals("NULL", StringComparison.InvariantCultureIgnoreCase) ? null : episode.GetDialog(nextDialogId);

                reply.Actions.Clear();
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
            }

            // Еще раз, для реплик у каждого диалога
            foreach (XmlNode node in doc.SelectNodes("/Episode/Dialogs/Dialog"))
            {
                Dialog dialog = episode.GetDialog(node.SelectSingleNode("Id").InnerText);
                dialog.Replies.Clear();
                foreach (XmlNode replyNode in node.SelectNodes("DialogReplies/ReplyId"))
                    dialog.Replies.Add(episode.GetReply(replyNode.InnerText));
            }
        }
    }
}
