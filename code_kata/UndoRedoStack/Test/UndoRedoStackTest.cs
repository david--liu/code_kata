using NUnit.Framework;
using Rhino.Mocks;

namespace code_kata.UndoRedoStack.Test
{
    [TestFixture]
    public class UndoRedoStackTest
    {
        //http://sites.google.com/site/tddproblems/all-problems-1/undo-redo-stack
        [Test]
        public void ShouldTrackUndoAndRedos()
        {
            var stack = new UndoRedoStack();
            var command = MockRepository.GenerateMock<ICommand>();
            stack.Do(command);
            Assert.IsTrue(stack.CanUndo(command));
            stack.Undo(command);
            Assert.IsFalse(stack.CanUndo(command));
            Assert.IsTrue(stack.CanRedo(command));
        }

        [Test]
        public void WhenDoTwoCommands()
        {
            var stack = new UndoRedoStack();
            var command1 = MockRepository.GenerateMock<ICommand>();
            var command2 = MockRepository.GenerateMock<ICommand>();
            stack.Do(command1);
            stack.Do(command2);
            Assert.IsTrue(stack.CanUndo(command2));
            Assert.IsFalse(stack.CanUndo(command1));

            stack.Undo(command2);
            Assert.IsTrue(stack.CanRedo(command2));
            Assert.IsTrue(stack.CanUndo(command1));

            stack.Undo(command1);

            Assert.IsTrue(stack.CanRedo(command1));
            Assert.IsFalse(stack.CanRedo(command2));
        }

        [Test]
        public void WhenDoThreeCommands()
        {
            var stack = new UndoRedoStack();
            var command1 = MockRepository.GenerateMock<ICommand>();
            var command2 = MockRepository.GenerateMock<ICommand>();
            var command3 = MockRepository.GenerateMock<ICommand>();
            stack.Do(command1);
            stack.Do(command2);
            stack.Do(command3);
            Assert.IsTrue(stack.CanUndo(command3));
            Assert.IsFalse(stack.CanUndo(command2));
            Assert.IsFalse(stack.CanUndo(command1));

            stack.Undo(command3);
            Assert.IsTrue(stack.CanRedo(command3));
            Assert.IsTrue(stack.CanUndo(command2));
            Assert.IsFalse(stack.CanUndo(command1));

            stack.Undo(command2);
            Assert.IsFalse(stack.CanRedo(command3));
            Assert.IsFalse(stack.CanUndo(command2));
            Assert.IsTrue(stack.CanRedo(command2));
            Assert.IsTrue(stack.CanUndo(command1));

            stack.Undo(command1);

            Assert.IsTrue(stack.CanRedo(command1));
            Assert.IsFalse(stack.CanRedo(command2));
        }


    }
}