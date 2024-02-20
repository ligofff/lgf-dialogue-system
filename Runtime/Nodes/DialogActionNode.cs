using System.Collections.Generic;
using LGF.DialogueSystem.Interfaces;
using UnityEngine;

namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Action node")]
    public class DialogActionNode : BaseDialogNode
    {
        [Input]
        public int input;
        
        [Output]
        public int defaultOutput;

        [SerializeReference]
        public List<IDialogueAction> actions;

        public override void Enter()
        {
            foreach (var dialogueAction in actions)
            {
                dialogueAction.Invoke();
            }
        }
    }
}