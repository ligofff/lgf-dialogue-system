namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(100), CreateNodeMenu("LGF Dialogue System/Start node")]
    public class DialogueStartNode : BaseDialogueNode
    {
        [Output]
        public int exit;
    }
}