using System.Collections.Generic;
using LGF.DialogueSystem.Interfaces;
using UnityEngine;

namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Action node")]
    public class DialogueActionNode : BaseDialogueNode
    {
        [Input]
        public int input;
        
        [Output]
        public int defaultOutput;

        [SerializeReference]
        public List<IDialogueAction> actions = new List<IDialogueAction>();

        public override void Enter(DialogueAgent agent)
        {
            foreach (var dialogueAction in actions)
            {
                dialogueAction.Invoke(agent);
            }
        }
    }
}