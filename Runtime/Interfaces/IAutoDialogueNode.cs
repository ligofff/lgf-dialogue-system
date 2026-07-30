namespace LGF.DialogueSystem.Nodes
{
    public interface IAutoDialogueNode
    {
        bool ShouldAutoPass(DialogueAgent agent);
    }
}
