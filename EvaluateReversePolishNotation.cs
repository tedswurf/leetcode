/*
In reverse Polish notation, the operators follow their operands. For example, to add 3 and 4 together, the expression is 3 4 + rather than 3 + 4.
The conventional notation expression 3 − 4 + 5 becomes 3 4 − 5 + in reverse Polish notation: 4 is first subtracted from 3, then 5 is added to it.

tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]

[] 10
[10] 6
[10, 6] 9
[10, 6, 9] 3
[10, 6, 9, 3] +
pop()x2 => 3 + 9 = 12
[10, 6] -11
[10, 6, -11] *
pop()x1 => -11 * 12 = -132
[10, 6] /
pop()x1 => 6 / -132 = 0
[10] *
pop()x1 => 10 * 0 = 0
[] 17
[17] +
pop()x1 => 17 + 0 = 17
[] 5 
[5] +
pop()x1 => 5 + 17 = 22

I had the algorithm 99% down, but what I failed to realize was that the value of an operation is
pushed into the stack to act as an operand for the next operation.

Instead, I created a separate variable to hold the result of the operation, which led to incorrect behavior when it came to
division and subtraction.

*/


public class Solution {
    public int EvalRPN(string[] tokens) {
        if (tokens.Length == 1)
        {
            return Int32.Parse(tokens[0]);
        }

        var stack = new Stack<int>();

        var operators = new List<string> { "+", "/", "-", "*" };

        for (int i = 0; i < tokens.Length; i++)
        {
            // encountering an operator means performing a calculation.
            if (operators.Any(x => x == tokens[i]))
            {
                var value = stack.Pop();
                var operand = stack.Pop();

                switch (tokens[i])
                {
                    case "+":
                        value = operand + value;
                        break;
                    case "-":
                        value = operand - value;
                        break;
                    case "*":
                        value = operand * value;
                        break;
                    case "/":
                        value = (int)(operand / value);
                        break;
                    default:
                        throw new Exception($"Unexpected operand: {tokens[i]}");
                }

                // The result is push on top of the stack as a future operand.
                stack.Push(value);
            }
            else
            {
                // Regular numbers are pushed on top.
                stack.Push(Int32.Parse(tokens[i]));
            }
        }

        // The very last value is the final answer.
        return stack.Pop();
    }
}