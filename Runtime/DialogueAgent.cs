﻿using System;
using LGF.DialogueSystem.Graphs;
using LGF.DialogueSystem.Nodes;

namespace LGF.DialogueSystem
{
    public class DialogueAgent
    {
        public DialogueGraph Graph;
        public object User;
        public object Character;

        private BaseDialogNode _currentDialogueNode;
        
        public DialogueAgent(DialogueGraph graph, object user, object character)
        {
            Graph = graph;
            User = user;
            Character = character;
        }

        public void StartDialogue()
        {
            _currentDialogueNode = Graph.StartNode;
            
            if (_currentDialogueNode == null)
                throw new NullReferenceException($"Start node is not defined in {Graph}!");
            
            _currentDialogueNode.Enter();
        }

        public BaseDialogNode Next()
        {
            _currentDialogueNode = _currentDialogueNode.GetNextNode();
            if (_currentDialogueNode != null)
            {
                _currentDialogueNode.Enter();
            }

            return _currentDialogueNode;
        }
        
        public bool IsEndOfDialogue()
        {
            return _currentDialogueNode.GetNextNode().GetType() == typeof(DialogEndNode);
        }

        public bool IsNeedToAnswer()
        {
            return _currentDialogueNode.GetType() == typeof(DialogueNode);
        }
    }
}