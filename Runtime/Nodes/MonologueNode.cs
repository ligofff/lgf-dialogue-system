using LGF.DialogueSystem.Interfaces;
using UnityEngine;

namespace LGF.DialogueSystem.Nodes
{
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Monologue node")]
    public class MonologueNode : BaseDialogNode, IDialoguePhrase
    {
        [Input]
        public int input;

        [Output]
        public int exit;
        
        [SerializeField]
        private string phrase;
        
        public string Phrase => phrase;
    }
}