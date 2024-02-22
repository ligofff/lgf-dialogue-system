using System.Collections.Generic;
using LGF.DialogueSystem.Nodes;

namespace LGF.DialogueSystem.Interfaces
{
    public interface IDialogueAnswers
    {
        public IEnumerable<DialogueAnswer> Answers { get; }
    }
}