using System;
using System.Collections.Generic;
using System.Linq;
using LGF.DialogueSystem.Nodes;
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

        private BaseDialogueNode _currentDialogueNode;
        
        public BaseDialogueNode CurrentNode => _currentDialogueNode;
        
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
            
            _currentDialogueNode.Enter(this);
            AdvanceAutoNodes();
        }

        public BaseDialogueNode Next(int answerId)
        {
            var nextNode = _currentDialogueNode.GetNextNode(answerId, this);

            while (nextNode is DialogueBranchNode)
            {
                nextNode = nextNode.GetNextNode(answerId, this);
            }
            
            _currentDialogueNode = nextNode;
            
            if (_currentDialogueNode != null)
            {
                _currentDialogueNode.Enter(this);
                AdvanceAutoNodes();
            }

            return _currentDialogueNode;
        }
        
        public bool IsEndOfDialogue(int answerId)
        {
            return _currentDialogueNode.GetNextNode(answerId, this).GetType() == typeof(DialogueEndNode);
        }

        private void AdvanceAutoNodes()
        {
            while (_currentDialogueNode is IAutoDialogueNode autoNode &&
                   autoNode.ShouldAutoPass(this))
            {
                _currentDialogueNode = _currentDialogueNode.GetNextNode(0, this);
                if (_currentDialogueNode == null) return;
                _currentDialogueNode.Enter(this);
            }
        }

        public bool IsNeedToAnswer()
        {
            return _currentDialogueNode is IDialogueAnswers &&
                   (!(_currentDialogueNode is IAutoDialogueNode autoNode) || !autoNode.ShouldAutoPass(this));
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