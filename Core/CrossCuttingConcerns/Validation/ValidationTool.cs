using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validation,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var validationResult = validation.Validate(context);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
