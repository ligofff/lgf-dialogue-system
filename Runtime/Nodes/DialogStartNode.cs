namespace Nodes
{
    [NodeWidth(70), CreateNodeMenu("LGF Dialogue System/Start node")]
    public class DialogStartNode : BaseDialogNode
    {
        [Output]
        public int exit;
    }
}