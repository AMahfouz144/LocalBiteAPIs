using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Common
{
    public abstract class BaseModel
    {
        protected bool _isValid = false;
        protected List<ValidationItem> _errors;
        protected List<ValidationResult> result;

        protected virtual void Validate()
        {
            result = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            _isValid = Validator.TryValidateObject(this, context, result, true);
            if (!_isValid)
                _errors = result.Select(prop => new ValidationItem()
                {
                    Key = prop.MemberNames.FirstOrDefault(),
                    Error = prop.ErrorMessage,
                }).ToList();
        }

        public virtual bool IsValid()
        {
            Validate();
            return _isValid;
        }

        public void AddError(string key, string message)
        {
            AddError(new ValidationItem(key, message));
        }

        public void AddError(ValidationItem item)
        {
            if (_errors == null)
                _errors = new List<ValidationItem>();

            _errors.Add(item);
        }
        public void AddErrors(List<ValidationItem> items)
        {
            items.ForEach(item => AddError(item));
        }

        public void TrimAllStringProperties()
        {
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(this) as string;
                    if (value != null)
                    {
                        property.SetValue(this, value.Trim());
                    }
                }
            }
        }

        [JsonIgnore]
        public bool NotValid => !IsValid();

        [JsonIgnore]
        public virtual List<ValidationItem> Errors => _errors;
    }

    public class ValidationItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Error { get; set; }

        public ValidationItem(){ }

        public ValidationItem(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public ValidationItem(string key, string value, string error)
            : this(key, value)
        {
            Error = error;
        }

        public override string ToString()
        {
            return "Key: " + Key + ", Value:" + Value + ", Error :" + Error;
        }
    }
}