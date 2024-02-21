using LGF.DialogueSystem.Interfaces;
using Sirenix.OdinInspector;
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
        
        [SerializeField, MultiLineProperty(7)]
        private string phrase;
        
        public string Phrase => phrase;
    }
}