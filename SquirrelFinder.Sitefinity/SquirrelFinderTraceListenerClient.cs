using System;
using System.Linq;
using System.Reflection;
using Telerik.Sitefinity.Services;

namespace SquirrelFinder.Sitefinity
{
    public class SquirrelFinderTraceListenerClient : ISquirrelFinderTraceListenerClient
    {
        public SquirrelFinderTraceListenerClient()
        {

        }

        public void LogMessage(string message)
        {
            Exception ex;
            if (SystemManager.CurrentHttpContext.Error != null)
            {
                ex = SystemManager.CurrentHttpContext.Error;
            }
            else
            {
                ex = new Exception(message);
            }
        }
    }
}