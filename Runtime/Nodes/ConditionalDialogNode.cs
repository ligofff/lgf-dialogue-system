using System;
using System.Collections.Generic;
using LGF.DialogueSystem.Interfaces;
using UnityEngine;

namespace Nodes
{
    [NodeWidth(600), CreateNodeMenu("LGF Dialogue System/Conditional node")]
    public class ConditionalDialogNode : BaseDialogNode
    {
        [Input]
        public int input;
        
        [Output]
        public int defaultOutput;

        [Output(dynamicPortList = true)]
        public int[] outputs;
        
        [SerializeReference]
        public List<IDialogueCondition> conditions;
    }
}