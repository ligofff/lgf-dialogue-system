using System;
using System.Collections.Generic;
using System.Linq;
using Nodes;
using XNode;

public class DialogueGraph : NodeGraph
{
    private IEnumerable<BaseDialogNode> DialogNodes => nodes.OfType<BaseDialogNode>();

    public DialogStartNode StartNode => (DialogStartNode)nodes.FirstOrDefault(node => node is DialogStartNode);

    public BaseDialogNode GetByGuid(string guid)
    {
        return DialogNodes.FirstOrDefault(node => node.NodeID == guid);
    }
        
    public BaseDialogNode GetNextNode(BaseDialogNode currentNode, object user)
    {
        var nextNode = (BaseDialogNode)currentNode.Outputs.FirstOrDefault()?.Connection?.node;

        if (nextNode is ConditionalDialogNode {} conditionalDialogNode)
        {
            NodePort nextPort = null;
                
            var trueIndex = conditionalDialogNode.conditions.FindIndex(cond => throw new NotImplementedException());

            if (trueIndex != -1)
            {
                nextPort = conditionalDialogNode.Outputs.First(port => port.fieldName == $"outputs {trueIndex}");
            }
            else
            {
                nextPort = conditionalDialogNode.Outputs.First(port => port.fieldName == "defaultOutput");
            }

            nextNode = (BaseDialogNode) nextPort?.Connection?.node;
        }

        return nextNode;
    }
        
    public BaseDialogNode GetNextNode(string currentNodeGuid, object user)
    {
        var currentNode = GetByGuid(currentNodeGuid);
        if (currentNode == null) return null;
        return GetNextNode(currentNode, user);
    }
}