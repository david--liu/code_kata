using System;
using System.Collections.Generic;
using System.Text;
using app.code_kata.ExpressionTree;

namespace code_kata.ExpressionTree
{
    public class ExpressionConverter : IExpressionConverter
    {
        private const char plus = '+';
        private const char minus = '-';
        private const char multi = '*';
        private const char divide = '/';
        private const char leftBracket = '(';
        private const char rightBraket = ')';
        private const char EOS = ';';

        private bool IsSecondOperatorPrecedenceHigherThanFirst(char left, char right)
        {
            if (left == plus || left == minus)
                return (right == multi || right == divide);
            else
            {
                return false;
            }
        }

        private bool IsAnOperator(char chr)
        {
            return chr == plus || chr == minus || chr == multi || chr == divide;
        }

        public string ConvertToPostfix(string infix)
        {
            var builder = new StringBuilder();
            var stack = new Stack<char>();
            stack.Push(EOS);
            foreach (var chr in infix.ToCharArray())
            {
                if(chr == ' ')
                    continue;

                if (IsAnOperator(chr))
                {
                    var peek = stack.Peek();
                    if(IsAnOperator(peek))
                    {
                        if (!IsSecondOperatorPrecedenceHigherThanFirst(peek, chr))
                        {
                            builder.Append(stack.Pop());
                        }
                    }
                    builder.Append(' ');
                    stack.Push(chr);
                }
                else if(chr == leftBracket)
                {
                    stack.Push(chr);
                }
                else if(chr == rightBraket)
                {
                    while (stack.Peek() != leftBracket)
                    {
                        builder.Append(stack.Pop());
                    }

                    stack.Pop();
                }
                else
                {
                    builder.Append(chr);
                }
                
            }

            while (stack.Peek() != EOS)
            {
                builder.Append(stack.Pop());
            }
            
            return builder.ToString();
        }

        private BinaryNode CreateOperatorBinaryNode(char chr)
        {
            if (chr == plus) return new AddBinaryNode();
            if (chr == minus) return new SubBinaryNode();
            if (chr == multi) return new MultiBinaryNode();
            if (chr == divide) return new DivBinaryNode();
            throw new NotSupportedException();
        }

        private bool IsReserved(char chr)
        {
            return IsAnOperator(chr) || chr == leftBracket || chr == rightBraket;
        }

        public BinaryNode ConstructBinaryTree<T>(string expression) 
        {
            var operandStack = new Stack<BinaryNode>();
            var operatorStack = new Stack<char>();
            var operandBuilder = new StringBuilder();
            operatorStack.Push(EOS);
            foreach (var chr in expression.ToCharArray())
            {
                if (chr == ' ')
                    continue;

                if(IsReserved(chr))
                    PushOperandIfThereIsAny(operandBuilder, operandStack);

                if (IsAnOperator(chr))
                {
                    var peek = operatorStack.Peek();
                    if (IsAnOperator(peek))
                    {
                        if (!IsSecondOperatorPrecedenceHigherThanFirst(peek, chr))
                        {
                            PopOperator(operandStack, operatorStack);
                        }
                    }
                    operatorStack.Push(chr);
                    
                }
                else if (chr == leftBracket)
                {
                    operatorStack.Push(chr);
                }
                else if (chr == rightBraket)
                {
                    while (operatorStack.Peek() != leftBracket)
                    {
                        PopOperator(operandStack, operatorStack);
                    }

                    operatorStack.Pop();
                }
                else
                {
                    operandBuilder.Append(chr);
                }
            }

            PushOperandIfThereIsAny(operandBuilder, operandStack);


            while (operatorStack.Peek() != EOS)
            {
                PopOperator(operandStack, operatorStack);
            }

            return operandStack.Pop();
        }

        private static void PushOperandIfThereIsAny(StringBuilder operandBuilder, Stack<BinaryNode> operandStack)
        {
            if(operandBuilder.Length > 0)
            {
                operandStack.Push(new BinaryNode(Convert.ToInt32(operandBuilder.ToString())));
                operandBuilder.Clear();
            }
        }


        void PopOperator(Stack<BinaryNode> operandStack, Stack<char> operatorStack)
        {
            var operatorBinaryNode = CreateOperatorBinaryNode(operatorStack.Pop());
            operatorBinaryNode.rightNode = operandStack.Pop();
            operatorBinaryNode.leftNode = operandStack.Pop();
            operandStack.Push(operatorBinaryNode);
        }
    }
}