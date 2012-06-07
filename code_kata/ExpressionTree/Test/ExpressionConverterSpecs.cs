using Machine.Specifications;
using app.code_kata.ExpressionTree;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ExpressionTree.Test
{  
    [Subject(typeof(ExpressionConverter))]  
    public class ExpressionConverterSpecs
    {
        public abstract class concern : Observes<IExpressionConverter,
                                            ExpressionConverter>
        {
        
        }

   
        public class when_converting_simple_addition: concern
        {

            Because b = () =>
                result = sut.ConvertToPostfix("1 + 1 + 56");

            It should_convert = () =>
                result.ShouldEqual(expected_string);
            static string result;
            static string expected_string = "1 1+ 56+";
        }
        
        public class when_converting_simple_subtraction: concern
        {

            Because b = () =>
                result = sut.ConvertToPostfix("100 - 1 - 56");

            It should_convert = () =>
                result.ShouldEqual(expected_string);
            static string result;
            static string expected_string = "100 1- 56-";
        }
        public class when_converting_simple_subtraction_and_addtion: concern
        {

            Because b = () =>
                result = sut.ConvertToPostfix("100 - 1 + 56");

            It should_convert = () =>
                result.ShouldEqual(expected_string);
            static string result;
            static string expected_string = "100 1- 56+";
        }
        public class when_converting_multiplication_and_addtion: concern
        {

            Because b = () =>
                result = sut.ConvertToPostfix("100 - 1 * 56");

            It should_convert = () =>
                result.ShouldEqual(expected_string);
            static string result;
            static string expected_string = "100 1 56*-";
        }

        public class when_converting_multiplication_and_adtion_with_parentheses : concern
        {
            Because b = () =>
                result = sut.ConvertToPostfix("3*(2+5)");

            It should_convert_and_ignore_parentheses = () =>
                result.ShouldEqual(expected_string);
            static string result;
            static string expected_string = "3 2 5+*";

                
        }

        public class when_construct_binary_tree_for_simple_addition :concern
        {
            Because b = () =>
                result = sut.ConstructBinaryTree<int>(" 1 + 1");

            It should_construct_addition_tree = () => 
                result.ShouldBeOfType<AddBinaryNode>();
            static BinaryNode result;
                
        }


        public class when_construct_binary_tree_for_simple_multification : concern
        {
            Because b = () =>
                result = sut.ConstructBinaryTree<int>(" 1 * 1");

            It should_construct_multification_tree = () =>
                result.ShouldBeOfType<MultiBinaryNode>();
            static BinaryNode result;

        }


        public class when_construct_binary_tree_for_addition_and_multification : concern
        {
            Because b = () =>
                result = sut.ConstructBinaryTree<int>(" (1+1) * 1");

            It should_construct_multification_tree = () =>
                result.ShouldBeOfType<MultiBinaryNode>();
            static BinaryNode result;

        }

        public class when_eval_binary_tree_for_addition_and_multification : concern
        {
            Because b = () =>
            {
                node = sut.ConstructBinaryTree<int>(" (1+1) * 5");
                result = node.Eval();
            };

            It should_return_correct_result = () =>
                result.ShouldEqual(10);
            static int result;
            static BinaryNode node;

        }
        
        public class when_eval_binary_tree_for_addition_with_multi_parenthese_and_multification : concern
        {
            Because b = () =>
            {
                node = sut.ConstructBinaryTree<int>(" ((1+1)) * 5");
                result = node.Eval();
            };

            It should_return_correct_result = () =>
                result.ShouldEqual(10);
            static int result;
            static BinaryNode node;

        }

        public class when_eval_addition_for_multi_digit_numbers : concern
        {
            private Because b = () => 
                            result = sut.ConstructBinaryTree<int>("10+20").Eval();

            It should_return_correct_result = () =>
                                                      result.ShouldEqual(30);

            static int result;
        }


        public class when_eval_complex_for_multi_digit_numbers : concern
        {
            private Because b = () => 
                            result = sut.ConstructBinaryTree<int>("(10+20) * 3 + 5").Eval();

            It should_return_correct_result = () =>
                                                      result.ShouldEqual(95);

            static int result;
        }


        public class when_eval_simple_for_multi_digit_numbers : concern
        {
            private Because b = () =>
                            result = sut.ConstructBinaryTree<int>("100").Eval();

            It should_return_correct_result = () =>
                                                      result.ShouldEqual(100);

            static int result;
        }


    }
}
