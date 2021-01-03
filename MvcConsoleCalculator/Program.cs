using System;
using MvcConsoleCalculator.Controller;
using MvcConsoleCalculator.Model;
using MvcConsoleCalculator.View;

namespace MvcConsoleCalculator
{
    internal static class Program
    {
        private static void Main(string[] _) => ApplicationLoop();

        private static void ApplicationLoop()
        {
            var calculator = new Calculator();
            var controller = new CalculatorController(calculator);
            var viewResult = "";
            while (viewResult != "###")
            {
                var view = controller.Action(viewResult);
                viewResult = RenderView(view);
            }
        }

        private static string RenderView(IView view)
        {
            Console.WriteLine(view.Header);

            switch (view)
            {
                case MenuView mv:
                {
                    foreach (var prompt in mv.Prompts)
                    {
                        Console.WriteLine($"\t[{prompt.Discriminator}]\t{prompt.Description}");
                    }
                
                    Console.Write("> ");
                    var choice = Console.ReadLine();
                    return mv.Choose(choice);
                }
                case QuitView _:
                    return "###";
                case ResultView rv:
                    Console.WriteLine($"\t{rv.Result}");
                    break;
                case PromptView pv:
                {
                    Console.Write("> ");
                    var choice = Console.ReadLine();
                    return pv.Choose(choice);
                }
            }

            return "";
        }
    }
}

