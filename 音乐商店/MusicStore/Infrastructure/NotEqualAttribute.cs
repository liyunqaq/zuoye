using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Infrastructure
{
    public class NotEqualAttribute : ValidationAttribute
    {
        public string _queryString { get; set; }
        public NotEqualAttribute(string queryString) : base("{0}字符串不匹配")
        {
            _queryString = queryString;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propery = validationContext.ObjectType.GetProperty(_queryString);
            if(propery==null)
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0}不存在", _queryString));
            }
            var otherValues = propery.GetValue(validationContext.ObjectInstance, null);
            if(object.Equals(value,otherValues))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        public System.Collections.Generic.IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,ControllerContext cont)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "NotEqual",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            rule.ValidationParameters["other"] = _queryString;
            yield return rule;
        }
    }
}