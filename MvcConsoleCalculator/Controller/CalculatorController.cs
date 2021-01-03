using System;
using System.Net.Sockets;
using MvcConsoleCalculator.Model;
using MvcConsoleCalculator.View;

namespace MvcConsoleCalculator.Controller
{
    public class CalculatorController
    {
        private readonly Calculator _calculator;

        public CalculatorController(Calculator calculator)
        {
            _calculator = calculator;
        }

        public IView Action(string operation)
        {
            var op = operation.Split(";");

            return op[0] switch
            {
                "+" => OperationView(op, _calculator.Add),
                "-" => OperationView(op, _calculator.Subtract),
                "*"  => OperationView(op, _calculator.Multiply),
                "/" => OperationView(op, _calculator.Divide),
                "###" => new QuitView("Thank you for using this awesome calculator."),
                _ => MenuView()
            };
        }

        private IView MenuView()
        {
            return new MenuView(
                "Choose an operation", 
                new[] {
                    new Prompt("1", "Addition", "+"),
                    new Prompt("2", "Subtraction", "-"),
                    new Prompt("3", "Multiplication", "*"),
                    new Prompt("4", "Division", "/"),
                    new Prompt("5", "Exit", "###")
                });
        }

        private int CountOperands(string[] op) =>
            op.Length switch
            {
                1 => 0,
                2 => 1,
                3 => 2,
                _ => throw new InvalidOperationException("Not sure how that happened.")
            };

        private IView OperationView(string[] op, Func<int, int, int> resultFunction)
        {
            var operandCount = CountOperands(op);

            if (operandCount != 2)
            {
                return new PromptView(op);
            }

            var x = Convert.ToInt32(op[1]);
            var y = Convert.ToInt32(op[2]);

            var result = resultFunction(x, y);
            return new ResultView(result);
        }
    }
}