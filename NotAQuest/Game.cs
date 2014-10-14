using System;
using System.Collections.Generic;
using NotAQuest.Episodes;
using System.Reflection;

namespace NotAQuest
{
    enum ExitState { FromMenu, };

    class Game
    {   
        public ExitState state;
        public Player player = null;
        List<Episode> Episodes = new List<Episode>(10);
        Episode currentEpisode = null;

        public Game()
        {           
            Episodes.Add(EpisodeLoader.Episode1());
            IO.Game = this;            
        }                    

        public void Start()
        {
            IO.WriteTitle();
            IO.WriteMenu();

            int answer = IO.ReadInt(1, 2);
            switch (answer)
            {
                case 1: break;
                case 2: 
                    state = ExitState.FromMenu; 
                    return;                
            }

            //Start a game
            foreach (Episode e in Episodes)
            {
                currentEpisode = e;
                while (e.CurrentDialog != null)
                {
                    Reply r = IO.ExecuteDialog(e.CurrentDialog);
                    foreach (ScriptAction a in r.Actions)
                    {
                        Type type = typeof(Game);
                        MethodInfo mInfo = type.GetMethod(a.Action);
                        mInfo.Invoke(this, a.Params);
                    }
                    e.CurrentDialog = r.NextDialog;
                }
            }
        }


        // Script methods - can be accessed from reply scripts

        public void AddReplyToDialog(string dialogId, string replyId)
        {
            IO.WriteDebug(string.Format("Добавляем реплику `{0}` в диалог `{1}`", replyId, dialogId));
            Dialog d = currentEpisode.GetDialog(dialogId);
            d.Replies.Add(currentEpisode.GetReply(replyId));
        }

        public void RemoveReplyFromDialog(string dialogId, string replyId)
        {
            IO.WriteDebug(string.Format("Удаляем реплику `{0}` из диалога `{1}`", replyId, dialogId));
            Dialog d = currentEpisode.GetDialog(dialogId);
            d.Replies.Remove(d.GetReply(replyId));
        }        
    }
}
