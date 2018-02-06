using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Middleware.Options.Service
{
    public enum MessageFormat { None, Upper, Lower }
    public class MessageService : IMessageService
    {
        private readonly MessageOptions option;
        public MessageService(MessageOptions _option)
        {
            option = _option;
        }
        public string FormatMessage(string message)
        {
            return this.option.format == MessageFormat.None ? message : this.option.format == MessageFormat.Upper ? message.ToUpper() : message.ToLower();
        }
    }
}
