using System;
using System.Linq;
using UnityEngine;
using XNode;

namespace Nodes
{
    public class BaseDialogNode : Node
    {
        [SerializeField, HideInInspector]
        private string nodeGuid;

        [SerializeField, HideInInspector]
        private bool initialized = false;

        public string NodeID => nodeGuid + "_" + (graph != null ? graph.name : "NULL_GRAPH");

        public DialogueGraph DialogueGraph => (DialogueGraph)graph;
        
        protected override void Init()
        {
            base.Init();

            if (graph != null && initialized && graph.nodes
                    .OfType<BaseDialogNode>()
                    .Where(node => node != this)
                    .Any(node => node.nodeGuid == nodeGuid))
            {
                initialized = false;
                Debug.Log($"Reinitialize node {name}!");
            }
            
            if (!initialized)
            {
                nodeGuid = Guid.NewGuid().ToString();
                initialized = true;   
            }
        }

        public override object GetValue(NodePort port)
        {
            return 0;
        }
    }
}