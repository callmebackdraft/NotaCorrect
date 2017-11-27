using System;
using System.ComponentModel.DataAnnotations;

namespace NotaCorrect.Models
{
    internal class DateTimeRangeAttribute : ValidationAttribute
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (StartDate == null)
            {
                StartDate = DateTime.MinValue.ToString();
            }
            if (EndDate == null)
            {
                EndDate = DateTime.MaxValue.ToString();
            }
            if (Convert.ToDateTime(value) >= Convert.ToDateTime(StartDate) && Convert.ToDateTime(value) <= Convert.ToDateTime(EndDate))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not in given range.");
            }

        }
    }
}