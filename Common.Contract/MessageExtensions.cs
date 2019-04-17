using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contract.Base
{
    public static class MessageExtensions
    {
        public static void AddMessageParameter(this Message message, string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                message.Parameters.Add(parameter);
            }
        }

        public static void AddMessageParameters(this Message message, params string[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                message.Parameters.AddRange(parameters);
            }
        }


        public static void AddMessageToList(this List<Message> errorMessages, string messsageText, params string[] parameters)
        {
            var msg = new Message(messsageText);
            if (parameters.Length > 0)
            {
                msg.AddMessageParameters(parameters);
                errorMessages.Add(msg);
            }
        }
    }
}
