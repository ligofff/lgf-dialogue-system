using System;
using System.Collections.Generic;
using System.Linq;
using LGF.DialogueSystem.Graphs;
using LGF.DialogueSystem.Interfaces;
using LGF.DialogueSystem.Nodes;

namespace LGF.DialogueSystem
{
    public class DialogueAgent
    {
        public DialogueGraph Graph;
        public object User;
        public object[] Characters;

        private BaseDialogNode _currentDialogueNode;
        
        public BaseDialogNode CurrentNode => _currentDialogueNode;
        
        public DialogueAgent(DialogueGraph graph, object user, object[] characters)
        {
            Graph = graph;
            User = user;
            Characters = characters;
        }

        public void StartDialogue()
        {
            _currentDialogueNode = Graph.StartNode;
            
            if (_currentDialogueNode == null)
                throw new NullReferenceException($"Start node is not defined in {Graph}!");
            
            _currentDialogueNode.Enter();
        }

        public BaseDialogNode Next(int answerId)
        {
            _currentDialogueNode = _currentDialogueNode.GetNextNode(answerId);
            if (_currentDialogueNode != null)
            {
                _currentDialogueNode.Enter();
            }

            return _currentDialogueNode;
        }
        
        public bool IsEndOfDialogue(int answerId)
        {
            return _currentDialogueNode.GetNextNode(answerId).GetType() == typeof(DialogEndNode);
        }

        public bool IsNeedToAnswer()
        {
            return _currentDialogueNode is IDialogueAnswers;
        }

        public IEnumerable<DialogueAnswer> GetAnswerVariants()
        {
            return ((IDialogueAnswers)_currentDialogueNode).Answers;
        }

        public bool HasPhrase()
        {
            return _currentDialogueNode is IDialoguePhrase;
        }

        public string GetPhrase()
        {
            return ((IDialoguePhrase)_currentDialogueNode).Phrase;
        }
    }
}