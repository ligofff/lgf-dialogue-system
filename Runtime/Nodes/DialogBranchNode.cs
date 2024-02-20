using System.Collections.Generic;
using System.Linq;
using LGF.DialogueSystem.Interfaces;
using UnityEngine;
using XNode;

namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Conditional node")]
    public class DialogBranchNode : BaseDialogNode
    {
        [Input]
        public int input;
        
        [Output]
        public int defaultOutput;

        [Output(dynamicPortList = true)]
        public int[] outputs;
        
        [SerializeReference]
        public List<IDialogueCondition> conditions;

        public override BaseDialogNode GetNextNode()
        {
            NodePort nextPort = null;
                
            var trueIndex = conditions.FindIndex(cond => cond.Check());

            if (trueIndex != -1)
            {
                nextPort = Outputs.First(port => port.fieldName == $"outputs {trueIndex}");
            }
            else
            {
                nextPort = Outputs.First(port => port.fieldName == "defaultOutput");
            }

            var nextNode = (BaseDialogNode) nextPort?.Connection?.node;

            return nextNode;
        }
    }
}