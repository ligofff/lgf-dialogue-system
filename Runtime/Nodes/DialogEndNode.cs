namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(100), CreateNodeMenu("LGF Dialogue System/End node")]
    public class DialogEndNode : BaseDialogNode
    {
        [Input]
        public int input;
    }
}