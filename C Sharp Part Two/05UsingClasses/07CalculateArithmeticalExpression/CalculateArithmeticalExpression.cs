//3+4*2/(1-5)
//=1
//* Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
//Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//Arithmetic operators: +, -, *, / (standard priorities)
//Mathematical functions: ln(x), sqrt(x), pow(x,y)
//Brackets (for changing the default priorities)

using System;
using System.Collections.Generic;
using System.Text;


class CalculateArithmeticalExpression
{
    static public int numb = 0, oper = 1, func = 2;

    public struct Token
    {
        public string str;
        public int type;
    }

    static void Main()
    {
        Console.Write("Enter arithmetical expression = ");
        string input = Console.ReadLine();
        Queue<Token> output = new Queue<Token>();
        Stack<string> stack = new Stack<string>();

        List<Token> tokens = new List<Token>();
        tokens = ReadTokens(input);
        output = SYA(tokens);

        foreach (var token in output)
        {
            Console.Write(token.str + "  ");
        }
        Console.WriteLine();

        decimal result = RPN(output);
        Console.WriteLine("Result = " + result);

    }

    private static decimal RPN(Queue<Token> queue)
    {
        decimal result = 0;
        decimal a, b;
        Token token = new Token();
        Stack<Token> stack = new Stack<Token>();

        while (queue.Count > 0)
        {
            token = queue.Dequeue();
            if (token.type == numb) stack.Push(token);
            else if (token.str == "+")
            {
                b = decimal.Parse(stack.Pop().str);
                a = decimal.Parse(stack.Pop().str);
                result = a + b;
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
            else if (token.str == "-")
            {
                b = decimal.Parse(stack.Pop().str);
                a = decimal.Parse(stack.Pop().str);
                result = a - b;
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
            else if (token.str == "*")
            {
                b = decimal.Parse(stack.Pop().str);
                a = decimal.Parse(stack.Pop().str);
                result = a * b;
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
            else if (token.str == "/")
            {
                b = decimal.Parse(stack.Pop().str);
                a = decimal.Parse(stack.Pop().str);
                result = a / b;
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
            else if (token.str == "ln")
            {
                a = decimal.Parse(stack.Pop().str);
                result = (decimal)Math.Log10((double)a);
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
            else if (token.str == "sqrt")
            {
                a = decimal.Parse(stack.Pop().str);
                result = (decimal)Math.Sqrt((double)a);
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
            else if (token.str == "pow")
            {
                b = decimal.Parse(stack.Pop().str);
                a = decimal.Parse(stack.Pop().str);
                result = (decimal)Math.Pow((double)a, (double)b);
                token.str = result.ToString();
                token.type = numb;
                stack.Push(token);
            }
        }

        return decimal.Parse(stack.Pop().str);
    }

    private static Queue<Token> SYA(List<Token> tokens)
    {
        Queue<Token> queue = new Queue<Token>();
        Token token = new Token();
        //            Token tokenTmp = new Token();
        Stack<Token> stack = new Stack<Token>();

        while (tokens.Count != 0)
        {
            token = tokens[0];
            tokens.RemoveAt(0);
            if (token.type == numb) queue.Enqueue(token);
            else if (token.type == func) stack.Push(token);
            else if (token.str == "(") stack.Push(token);
            else if (token.str == ")")
            {
                while (token.str != "(")
                {
                    token = stack.Pop();
                    if (token.str != "(") queue.Enqueue(token);
                }
                if (stack.Count > 0)
                {
                    token = stack.Peek();
                    if (token.type == func)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
            }
            else if (token.str == ",")
            {

                do
                {
                    token = stack.Peek();
                    if (token.str != "(") queue.Enqueue(stack.Pop());
                } while (token.str != "(");
            }
            else if (token.type == oper)
            {
                while (stack.Count > 0)
                {
                    if (stack.Peek().type != oper || stack.Peek().str == "(") break;
                    if ((stack.Peek().str == "+" || stack.Peek().str == "-") &&
                     (token.str == "*" || token.str == "/"))
                    {
                        break;
                    }
                    else queue.Enqueue(stack.Pop());
                }
                stack.Push(token);
            }
        }
        while (stack.Count != 0)
        {
            queue.Enqueue(stack.Pop());

        }

        return queue;
    }

    private static List<Token> ReadTokens(string input)
    {
        List<Token> tokens = new List<Token>();
        Token token;
        token.str = "";
        token.type = 0;


        for (int i = 0; i < input.Length; i++)
        {
            if ((input[i] >= '0' && input[i] <= '9') || input[i] == '.')
            {
                token.str += input[i];
                token.type = numb;
            }
            else if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
            {
                token.str += input[i];
                token.type = func;
            }
            else
            {
                if (token.str == "")
                {
                    token.type = oper;
                    token.str = input[i].ToString();
                    if (input[i] != ' ') tokens.Add(token);
                    token.str = "";
                }
                else
                {
                    if (tokens.Count > 0 && tokens[tokens.Count - 1].str == "-")
                    {
                        if (tokens.Count == 1 || tokens[tokens.Count - 2].str == "," || tokens[tokens.Count - 2].str == "(")
                        {
                            tokens.RemoveAt(tokens.Count - 1);
                            token.str = "-" + token.str;
                        }
                    }


                    tokens.Add(token);
                    token.type = oper;
                    token.str = input[i].ToString();
                    if (token.str != " ") tokens.Add(token);
                    token.str = "";
                }
            }
        }

        //        tokens.RemoveAll(IsSpace);

        return tokens;
    }

    //private static bool IsSpace(Token s)
    //{
    //    if (" ".CompareTo(s.str) == 0)
    //        return true;
    //    return false;
    //}
}

