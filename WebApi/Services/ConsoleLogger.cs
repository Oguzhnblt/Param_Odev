using System;

namespace WebApi_Param_Odev.Services
{ //Dependency Injection
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }

}