using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Contract.Base
{
    public class Message
    {
        public Message(string text) : this(text, MessageType.Error)
        {
            Text = text;
        }
        public Message(string text, MessageType type)
        {
            Text = text;
            Type = type;
            Parameters = new List<string>();
        }

        public string Text { get; set; }
        public string Code { get; set; }
        public MessageType Type { get; set; }
        public List<string> Parameters { get; set; }
    }

    public enum MessageType : int
    {
        Empty = 0,
        Error = 1,
        Success = 2,
        Warning = 3,
        Info = 4
    }
}
