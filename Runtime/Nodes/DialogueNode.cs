using System;
using System.Collections.Generic;
using System.Linq;
using LGF.DialogueSystem.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;

namespace LGF.DialogueSystem.Nodes
{
    [Serializable]
    public class DialogueAnswer : IDialoguePhrase
    {
        [SerializeField]
        private string phrase;


        [SerializeField]
        private bool hasAction;
        
        [SerializeReference, Sirenix.OdinInspector.ShowIf("@hasAction")]
        public IDialogueAction action;
        
        public bool closeAfterAction;

        internal DialogueNode thisNode;
        internal int id;
        
        public bool conditionalAnswer = false;

        [SerializeReference, ShowIf("@conditionalAnswer")]
        public IDialogueCondition condition;

        public string Phrase => phrase;
        public int Id => id;
    }
    
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Dialogue node")]
    public class DialogueNode : BaseDialogNode, IDialoguePhrase, IDialogueAnswers
    {
        [SerializeField, MultiLineProperty(7)]
        private string phrase;
        
        [Input]
        public int input;

        [Output(dynamicPortList = true)]
        public int[] outputs;
        
        public List<DialogueAnswer> answers = new List<DialogueAnswer>();
        
        public string Phrase => phrase;
        public IEnumerable<DialogueAnswer> Answers => answers;

        protected override void Init()
        {
            base.Init();

            for (int i = 0; i < answers.Count; i++)
            {
                var answer = answers[i];
                answer.thisNode = this;
                answer.id = i;
            }
        }

        public override BaseDialogNode GetNextNode(int answerId)
        {
            NodePort nextPort = null;
                
            nextPort = Outputs.FirstOrDefault(port => port.fieldName == $"outputs {answerId}");
            
            if (nextPort == null)
                throw new NullReferenceException($"Answer {answerId} is not defined in {name}!");

            var nextNode = (BaseDialogNode) nextPort?.Connection?.node;
            
            return nextNode;
        }

    }
}