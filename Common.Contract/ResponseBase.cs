using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Common.Contract.Base
{
    public abstract class ResponseBase
    {
        public List<Exception> Exceptions;
        public ResponseHeader Header { get; set; }
        public string ErrorMessage { get; set; }

        public void AddMessagesFromResponse(ResponseBase copyFrom)
        {
            foreach (var msg in copyFrom.Header.Messages)
            {
                AddMessage(msg);
            }
        }

        public ResponseBase()
        {

            this.Header = new ResponseHeader();
            ErrorMessage = string.Empty;
            Exceptions = new List<Exception>();
        }

        public enum ErrorMessageTypes
        {
            RecordNotFound,
            NoPermission
        }

        public bool HasError()
        {
            return Header != null && Header.IsErrorOccured;
        }

        public bool HasErrorMessage
        {
            get
            {
                return HasError();
            }
        }

        public bool HasException => Exceptions.Count > 0;

        public void AddMessage(Message message)
        {
            if (Header == null)
            {
                Header = new ResponseHeader();
            }

            Header.Messages.Add(message);
        }

        public void AddMessage(List<Message> messages)
        {
            if (messages != null && messages.Count > 0)
            {
                Header.Messages.AddRange(messages);
            }
        }

        public void AddMessage(string messageText)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("errorMessageText");
            }

            AddMessage(messageText, MessageType.Error);
        }

        public void AddMessage(string messageText, MessageType messageType)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("errorMessageText");
            }

            var msg = new Message(messageText, messageType);
            AddMessage(msg);
        }

        public void AddMessage(string messageText, string errorCode)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("errorMessageText");
            }

            if (errorCode == null)
            {
                throw new ArgumentNullException("errorCode");
            }

            var msg = new Message(messageText, MessageType.Error);
            msg.Code = errorCode;
            AddMessage(msg);
        }

        public void AddMessage(ErrorMessageTypes messageType)
        {
            string messageText = string.Empty;
            switch (messageType)
            {
                case ErrorMessageTypes.RecordNotFound:
                    messageText = "Kayıt bulunamadı.";
                    break;
                case ErrorMessageTypes.NoPermission:
                    messageText = "Yetkiniz Yok.";
                    break;
                default:
                    throw new NotImplementedException();
            }

            AddMessage(messageText);
        }

        public void AddMessage(List<string> errorMessageTextList)
        {
            if (errorMessageTextList != null && errorMessageTextList.Count > 0)
            {
                var messages = errorMessageTextList.Select(x => new Message(x, MessageType.Error));
                Header.Messages.AddRange(messages);
            }
        }

        public void AddMessageWithParameter(string messageText, string parameter)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("errorMessageText");
            }

            var msg = new Message(messageText, MessageType.Error);
            msg.AddMessageParameter(parameter);
            AddMessage(msg);
        }

        public void AddMessageWithParameters(string messageText, params string[] parameters)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("errorMessageText");
            }

            var msg = new Message(messageText, MessageType.Error);
            msg.AddMessageParameters(parameters);
            AddMessage(msg);
        }
    }
}
