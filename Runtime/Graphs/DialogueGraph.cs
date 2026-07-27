using System.Collections.Generic;
using System.Linq;
using LGF.DialogueSystem.Nodes;
using UnityEngine;
using XNode;

namespace LGF.DialogueSystem.Graphs
{
    [CreateAssetMenu(menuName = "LGF Dialogue System/Dialogue Graph")]
    public class DialogueGraph : NodeGraph
    {
        private IEnumerable<BaseDialogueNode> DialogNodes => nodes.OfType<BaseDialogueNode>();

        public DialogueStartNode StartNode => (DialogueStartNode)nodes.FirstOrDefault(node => node is DialogueStartNode);

        public BaseDialogueNode GetByGuid(string guid)
        {
            return DialogNodes.FirstOrDefault(node => node.NodeID == guid);
        }
    }
}