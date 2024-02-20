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
        private IEnumerable<BaseDialogNode> DialogNodes => nodes.OfType<BaseDialogNode>();

        public DialogStartNode StartNode => (DialogStartNode)nodes.FirstOrDefault(node => node is DialogStartNode);

        public BaseDialogNode GetByGuid(string guid)
        {
            return DialogNodes.FirstOrDefault(node => node.NodeID == guid);
        }
    }
}