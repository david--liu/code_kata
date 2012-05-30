namespace code_kata.UndoRedoStack
{
    public interface ICommand
    {
        void Undo();
        void Do();
    }
}