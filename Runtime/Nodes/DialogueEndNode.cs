namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(100), CreateNodeMenu("LGF Dialogue System/End node")]
    public class DialogueEndNode : BaseDialogueNode
    {
        [Input]
        public int input;
    }
}