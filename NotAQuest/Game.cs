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
        List<Episode> Episodes = new List<Episode>(1);        
        Episode currentEpisode = null;

        enum Steps { Girl, BossCall, MashaCall, CaseSituation, MashaParty };

        Dictionary<Steps, bool> solutions = new Dictionary<Steps, bool>();

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
            //foreach (Episode e in Episodes)
            //{
                currentEpisode = Episodes[0];
                while (currentEpisode.CurrentDialog != null)
                {
                    Reply r = IO.ExecuteDialog(currentEpisode.CurrentDialog);
                    for (int i = 0; i < r.Actions.Count; i++ )
                    {
                        ScriptAction a = r.Actions[i];
                        Type type = typeof(Game);
                        MethodInfo mInfo = type.GetMethod(a.Action);
                        mInfo.Invoke(this, a.Params);
                    }
                    currentEpisode.CurrentDialog = r.NextDialog;
                }
            //}
        }


        // Script methods - can be accessed from reply scripts

        public void AddReplyToDialog(string dialogId, string replyId)
        {
            IO.WriteDebug(string.Format("Добавляем реплику `{0}` в диалог `{1}`", replyId, dialogId));
            Dialog d = currentEpisode.GetDialog(dialogId);
            d.Replies.Add(currentEpisode.GetReply(replyId));
            IO.WriteDebug("Успешно!");
        }

        public void RemoveReplyFromDialog(string dialogId, string replyId)
        {
            IO.WriteDebug(string.Format("Удаляем реплику `{0}` из диалога `{1}`", replyId, dialogId));
            Dialog d = currentEpisode.GetDialog(dialogId);
            d.Replies.Remove(d.GetReply(replyId));
            IO.WriteDebug("Успешно!");
        }

        public void SetSolution(string step, string solution)
        {
            IO.WriteDebug(string.Format("Устанавливаем решение для {0} в положение {1}", step, solution));

            Steps parsedStep = (Steps) Enum.Parse(typeof(Steps), step);
            if (!Enum.IsDefined(typeof(Steps), parsedStep))
                throw new Exception(string.Format("Не найдено шага `{0}`", step));

            bool parsedSolution;
            if (!Boolean.TryParse(solution, out parsedSolution))
                throw new Exception(string.Format("Невозможно распознать решение {1} для шага {0}", step, solution));

            solutions[parsedStep] = parsedSolution;
            IO.WriteDebug("Успешно!");
        }

        public void ResetAll()
        {
            IO.WriteDebug("Возвращаем все в изначальное положение!");
            // Solutions Clear
            solutions.Clear();

            // Dialogs removes/adds clear
            // Such a hack
            EpisodeLoader.ResetEpisode(Episodes[0], EpisodeLoader.FILE_EPISODE1);
            IO.WriteDebug("Успешно!");
        }

        public void OnLeninaScript()
        {
            Reply reply = currentEpisode.GetReply("getCaught_1");
            if (solutions[Steps.CaseSituation])
                reply.NextDialog = currentEpisode.GetDialog("jailedNoDrugs");
        }

        public void VasiliyScript()
        { 
            if (!solutions[Steps.CaseSituation])
                foreach (Reply r in currentEpisode.GetDialog("workmateDissapeared").Replies)
                    r.NextDialog = currentEpisode.GetDialog("vasiliyWins");
        }        
    }
}
