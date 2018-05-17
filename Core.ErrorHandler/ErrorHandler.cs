using System;
using Microsoft.AspNetCore.Identity;

namespace Core.ErrorHandler
{
    public class ErrorMessage : IErrorHandler
    {
        public string GetMessage(ErrorMessagesEnum message)
        {
            switch (message)
            {
                case ErrorMessagesEnum.EntityNull:
                    return "The entity passed is null {0}. Additional information: {1}";

                case ErrorMessagesEnum.ModelValidation:
                    return "The request data is not correct. Additional information: {0}";

                default:
                    throw new ArgumentOutOfRangeException(nameof(message), message, null);
            }

        }

        public string ErrorIdentityResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {

            }

            return string.Empty;
        }
    }
}
