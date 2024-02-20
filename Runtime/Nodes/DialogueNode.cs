using System;
using System.Collections.Generic;
using LGF.DialogueSystem.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LGF.DialogueSystem.Nodes
{
    [Serializable]
    public class PlayerAnswer
    {
        [SerializeField]
        private string phrase;

        [SerializeReference]
        public IDialogueAction action;
        
        public bool closeAfterAction;

        internal DialogueNode thisNode;
        
        public bool conditionalAnswer = false;

        [SerializeReference, ShowIf("@conditionalAnswer")]
        public IDialogueCondition condition;
    }
    
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Dialogue node")]
    public class DialogueNode : BaseDialogNode
    {
        [Input]
        public int input;

        [Output]
        public int exit;
        
        [SerializeField]
        private string phrase;

        public List<PlayerAnswer> answers = new List<PlayerAnswer>();

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