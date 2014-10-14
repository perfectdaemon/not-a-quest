using System;
using System.Collections.Generic;

namespace NotAQuest
{
    struct ScriptAction
    {
        public string Action;
        public string[] Params;
    }

    class Reply
    {
        public string ID;
        public string Text;
        public string[] TextParams = null;
        public Dialog NextDialog = null;
        public List<ScriptAction> Actions = new List<ScriptAction>();

        public Reply(string id, string text)
        {
            ID = id;
            Text = text;
        }

        public override string ToString()
        {
            return ID + " : " + Text.Substring(0, Math.Min(Text.Length, 60));
        }
    }

    class Dialog
    {
        public string ID;
        public string Text;
        public string[] TextParams = null;
        public List<Reply> Replies = new List<Reply>(4);

        public Dialog(string id, string text)
        {
            ID = id;
            Text = text;
        }

        public Reply GetReply(string id)
        {
            foreach (Reply r in Replies)
                if (r.ID == id)
                    return r;
            throw new Exception(string.Format("В диалоге `{0}` реплика `{1}` не найдена", this.ID, id));
        }

        public override string ToString()
        {
            return ID + " : " + Text.Substring(0, Math.Min(Text.Length, 60));
        }
    }

    class Episode
    {
        public List<Dialog> Dialogs = new List<Dialog>();
        public List<Reply> Replies = new List<Reply>();

        public Reply GetReply(string id)
        {
            foreach (Reply r in Replies)
                if (r.ID == id)
                    return r;
            throw new Exception(string.Format("Реплика с ID `{0}` не найдена", id));
        }

        public Dialog GetDialog(string id)
        {
            foreach (Dialog d in Dialogs)
                if (d.ID == id)
                    return d;
            throw new Exception(string.Format("Диалог с ID `{0}` не найден", id));
        }

        public Dialog CurrentDialog = null;

        public Episode(Dialog startDialog)
        {
            this.CurrentDialog = startDialog;
        }
    }
}
