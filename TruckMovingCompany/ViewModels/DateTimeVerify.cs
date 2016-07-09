using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace TruckMovingCompany.ViewModels
{
    public class DateTimeVerify : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            string s = Convert.ToString(value);
            var isValid = DateTime.TryParse(s, out dateTime);

            return (isValid);
        }
    }

}