﻿using System.ComponentModel.DataAnnotations;

namespace La_Mia_Pizzeria_1.CustomValidation {
    public class PriceValidation : ValidationAttribute {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            string FieldValue = (string)value;
            try {
                double x = double.Parse(FieldValue);
                if(x < 0) {
                    return new ValidationResult("Hai inserito un prezzo non possibile");
                }
                return ValidationResult.Success;
            }
            catch(Exception ex) {
                return new ValidationResult("Non hai inserito dei numeri");
            }   

        }
    }
}
