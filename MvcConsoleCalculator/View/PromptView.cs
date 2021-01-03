using System.Linq;

namespace MvcConsoleCalculator.View
{
    public class PromptView : IView
    {
        private readonly string[] _operands;

        public PromptView(string[] operands)
        {
            _operands = operands;
        }
        
        public string Header => "Enter operand";

        public string Choose(string choice)
        {
            var operands = _operands.Concat(new[] {choice});
            return string.Join(";", operands);
        }
    }
}