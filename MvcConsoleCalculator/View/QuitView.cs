namespace MvcConsoleCalculator.View
{
    public class QuitView : IView
    {
        public QuitView(string header)
        {
            Header = header;
        }
        
        public string Header { get; } 
    }
}