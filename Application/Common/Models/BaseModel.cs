using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public abstract class BaseModel
    {
        public virtual IEnumerable<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            Validator.TryValidateObject(this, context, results, validateAllProperties: true);
            return results;
        }

        public virtual bool IsValid(out IEnumerable<ValidationResult> results)
        {
            results = Validate();
            return results == null || !results.Any();
        }
    }
}
