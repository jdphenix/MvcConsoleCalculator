using System.Linq;

namespace MvcConsoleCalculator.View
{
    public class MenuView : IView
    {
        public MenuView(string header, Prompt[] prompts)
        {
            Header = header;
            Prompts = prompts;
        }
        
        public string Header { get; }
        public Prompt[] Prompts { get; }

        public string Choose(string choice)
        {
            return Prompts.FirstOrDefault(p => p.Discriminator == choice)?.Op ?? "";
        }
    }
}