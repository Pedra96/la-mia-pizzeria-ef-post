using System.ComponentModel.DataAnnotations;
using System.Net;

namespace La_Mia_Pizzeria_1.CustomValidation {
    public class ImageUrlValidation:ValidationAttribute {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null) {
                return new ValidationResult("campo obbligatorio");
            }

            string FieldValue = (string)value;

            WebRequest webRequest;
            try {
                webRequest = WebRequest.Create(FieldValue);
                var x = webRequest.ContentType();
            }catch(Exception e) {
                return new ValidationResult("il link inserito non è valido");
            }
            WebResponse webResponse;
            try {
                webResponse = webRequest.GetResponse();
                return ValidationResult.Success;
            }catch(Exception ex) {
                return new ValidationResult("il link inserito non è valido");
            }

        }
    }
}
