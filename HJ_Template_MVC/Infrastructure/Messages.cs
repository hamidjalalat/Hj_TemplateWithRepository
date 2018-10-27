using System.Linq;
//using System.Data.Entity;

namespace Infrastructure
{
    public class PageMessages : object
    {
        public PageMessages(Types type,string message) : base()
        {
            Type = type;
            Message = message;

        }

        public enum Types:int
        {
            Error,
            Info,
            warning,
        };


        public string Message { get; set; }

        public Types Type { get; set; }

    }
}