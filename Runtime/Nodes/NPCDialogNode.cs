using System;
using System.Collections.Generic;
using LGF.DialogueSystem.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Nodes
{
    [Serializable]
    public class PlayerAnswer
    {
        [SerializeField]
        private string line;

        [SerializeReference]
        public IDialogueAction action;
        
        public bool closeAfterAction;

        internal NPCDialogNode thisNode;
        
        public bool conditionalAnswer = false;

        [SerializeReference, ShowIf("@conditionalAnswer")]
        public IDialogueCondition condition;
    }
    
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Default dialog")]
    public class NPCDialogNode : BaseDialogNode
    {
        [Input]
        public int input;

        [Output]
        public int exit;
        
        [SerializeField]
        private string phrase;

        [TitleGroup("Next button")]
        public bool hasCustomNextPhrase;
        [ShowIf("@hasCustomNextPhrase"), SerializeField]
        private string customNextPhrase;

        public bool saveDialogState;
        [ShowIf("@saveDialogState")]
        public bool goToNextDialogNodeOnStateLoad;
        
        [TitleGroup("Answers")]
        public bool hasCustomPlayerAnswers;
        
        [ShowIf("@hasCustomPlayerAnswers")]
        public List<PlayerAnswer> answers;
        
        [TitleGroup("Actions")]
        public bool hasActions;

        [ShowIf("@hasActions")]
        public bool oneTimeInvokeActions = false;
        
        [ShowIf("@hasActions"), SerializeReference]
        public IDialogueAction action;
        
        /*[TitleGroup("Additional")]
        public bool hasAdditionalText;
        
        [ShowIf("@hasAdditionalText"), SerializeReference]
        public IngameLineMessageBuilder additionalLineBuilder;*/

        protected override void Init()
        {
            base.Init();

            foreach (var playerAnswer in answers)
            {
                playerAnswer.thisNode = this;
            }
        }
    }
}