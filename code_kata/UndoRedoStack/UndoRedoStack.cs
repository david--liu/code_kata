using System.Collections.Generic;

namespace code_kata.UndoRedoStack
{
    public class UndoRedoStack
    {
        readonly Stack<ICommand> undoStack = new Stack<ICommand>();
        readonly Stack<ICommand> redoStack = new Stack<ICommand>();
        public void Do(ICommand command)
        {
            command.Do();
            undoStack.Push(command);

        }

        public bool CanUndo(ICommand command)
        {
            return undoStack.Count > 0 && undoStack.Peek() == command;
        }

        public bool CanRedo(ICommand command)
        {
            return redoStack.Count > 0 && redoStack.Peek() == command;
        }

        public void Undo(ICommand command)
        {
            if (CanUndo(command))
            {
                undoStack.Pop();

                command.Undo();

                redoStack.Push(command);
            }
        }
    }
}