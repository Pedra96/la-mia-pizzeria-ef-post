﻿using System.ComponentModel.DataAnnotations;
using System.Net;

namespace La_Mia_Pizzeria_1.CustomValidation {
    public class ImageUrlValidation : ValidationAttribute {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            string ErrorMessage = "il link inserito non è valido";
            if (value == null) {
                return new ValidationResult("campo obbligatorio");
            }

            string FieldValue = (string)value;
            WebRequest webRequest;
            try {
                webRequest = WebRequest.Create(FieldValue);
            }
            catch (Exception e) {
                return new ValidationResult(ErrorMessage);
            }
            WebResponse webResponse;
            try {
                webResponse = webRequest.GetResponse();
                string UrlType = webResponse.ContentType;
                if(UrlType.StartsWith("image/")) {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
            catch (Exception ex) {
                return new ValidationResult(ErrorMessage);
            }

        }
    }
}
