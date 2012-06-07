namespace app.code_kata.ExpressionTree
{
    public interface IExpressionConverter
    {
        string ConvertToPostfix(string infix);
        BinaryNode ConstructBinaryTree<T>(string expression);
    }
}