using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common
{
    public class AppValidationException : AppException
    {
        public List<ValidationItem> ValidationResult { private set; get; }
        public string EntityName { private set; get; }

        public AppValidationException()
            : base(ExceptionType.Validation)
        {
            base.StatusCode = 405;
        }

        public AppValidationException(string clientMessage)
            : this()
        {
            this.ClientMessage = clientMessage;
        }

        public AppValidationException(string entityName, List<ValidationItem> validationResult)
            : this("[" + entityName + "] Entity contains invalid information.")
        {
            ValidationResult = validationResult;
            EntityName = entityName;
        }

        public AppValidationException(string entityName, ValidationItem unvalidItem)
            : this(entityName, new List<ValidationItem>
            {
                unvalidItem
            })
        {
        }

        public AppValidationException(string entityName, List<ValidationItem> validationResult, string clientMessage)
            : this(clientMessage)
        {
            EntityName = entityName;
            ValidationResult = validationResult;
        }

        public AppValidationException(string entityName, ValidationItem unvalidItem, string clientMessage)
            : this(entityName, unvalidItem)
        {
            base.ClientMessage = clientMessage;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            SerializationInfo info2 = info;
            base.GetObjectData(info2, context);
            info2.AddValue("EntityName", EntityName);
            ValidationResult?.ForEach(delegate (ValidationItem obj)
            {
                info2.AddValue(obj.Key, obj.Value);
            });
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Message : " + Message);
            if (ValidationResult != null)
            {
                foreach (ValidationItem item in ValidationResult)
                {
                    stringBuilder.Append(Environment.NewLine + item.ToString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}