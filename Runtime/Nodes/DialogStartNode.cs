namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(100), CreateNodeMenu("LGF Dialogue System/Start node")]
    public class DialogStartNode : BaseDialogNode
    {
        [Output]
        public int exit;
    }
}