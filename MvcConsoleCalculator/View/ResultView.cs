namespace MvcConsoleCalculator.View
{
    public class ResultView : IView
    {
        public ResultView(object result)
        {
            Result = result;
        }
        
        public object Result { get; }
        public string Header { get; } = "Operation result";
        
    }
}