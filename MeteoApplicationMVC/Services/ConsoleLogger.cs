using MeteoApplicationMVC.Services.Interfaces;

namespace MeteoApplicationMVC.Services
{
    public class ConsoleLogger : ILog
    {
        public void Info(string textToLog)
        {
            Console.WriteLine(textToLog);
        }
    }
}
