namespace app.code_kata.ExpressionTree
{
    public class BinaryNode
    {
        protected int value;

        public BinaryNode()
        {
        }

        public BinaryNode(int value)
        {
            this.value = value;
        }

        public BinaryNode leftNode { get; set; }
        public BinaryNode rightNode { get; set; }
         public virtual int Eval()
         {
             return value;
         }

        
    }

    public class AddBinaryNode : BinaryNode
    {
        public override int Eval()
        {
            return leftNode.Eval() + rightNode.Eval();
        }
    }

    public class SubBinaryNode : BinaryNode
    {
        public override int Eval()
        {
            return leftNode.Eval() - rightNode.Eval();
        }
    }

    public class MultiBinaryNode : BinaryNode
    {
        public override int Eval()
        {
            return leftNode.Eval() * rightNode.Eval();
        }
    }

    public class DivBinaryNode : BinaryNode
    {
        public override int Eval()
        {
            return leftNode.Eval() / rightNode.Eval();
        }
    }

}