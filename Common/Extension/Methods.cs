
namespace Common.Extensions
{
    public static class Methods
    {
        public static void ValidateModel(this BaseModel model)
        {
            if (model == null)
                throw new AppValidationException("Business Model Error");

            if (model.NotValid)
                throw new AppValidationException(model.GetType()?.Name, model.Errors);

            model.TrimAllStringProperties();
        }

        
        //public static void ValidateModel(this BaseModel model,string errorMessage)
        //{
        //    if (model == null)
        //        throw new AppValidationException(errorMessage);
        //    if (model.NotValid)
        //        throw new AppValidationException(model.GetType()?.Name, model.Errors);
        //}

        //public static void ValidateModel(this BaseModel model, string errorMessage, params  bool[] validations)
        //{
        //    if (model == null || validations.Any(a => a))
        //        throw new AppValidationException(errorMessage);
        //    if (model.NotValid)
        //        throw new AppValidationException(model.GetType()?.Name, model.Errors);
        //}
    }
}