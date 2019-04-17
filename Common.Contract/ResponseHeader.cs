using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Contract.Base
{
    public sealed class ResponseHeader : Header
    {
        public ResponseHeader()
        {
            Messages = new List<Message>();
        }

        public bool IsErrorOccured
        {
            get
            {
                return Messages.Any(x => x.Type == MessageType.Error);
            }
        }

        public List<Message> Messages { get; set; }
    }
}
