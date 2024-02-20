using UnityEngine;

namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Monologue node")]
    public class MonologueNode : BaseDialogNode
    {
        [Input]
        public int input;

        [Output]
        public int exit;
        
        [SerializeField]
        private string phrase;
    }
}