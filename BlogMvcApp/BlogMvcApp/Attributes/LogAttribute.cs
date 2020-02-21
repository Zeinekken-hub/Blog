using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

namespace BlogMvcApp.Attributes
{
    public class LogAttribute : ActionFilterAttribute
    {
        private readonly string _message;
        public LogAttribute(string message)
        {
            _message = message;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            SaveLogData();
        }
        private void SaveLogData()
        {
            File.AppendAllLines(@"C:\Users\Omen\Desktop\Blog2\BlogMvcApp\BlogMvcApp\Util\log.txt",
                new[] { $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - {_message}" });
        }
    }
}