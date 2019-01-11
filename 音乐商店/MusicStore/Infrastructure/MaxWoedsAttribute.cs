using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Infrastructure
{
    public class MaxWoedsAttribute : ValidationAttribute
    {
        readonly int _max;
        public MaxWoedsAttribute(int max) : base("{0}超出限制单词数")
        {
            _max = max;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueString = value.ToString();
                //Split()方法，以空格为分隔符进行输入值的分割
                if (valueString.Split(' ').Length > _max)//对输入字符创进行验证
                {
                    //FormatErrorMessage确保使用适合对错误提示信息
                    var errMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errMessage);
                }
            }
            return ValidationResult.Success;
        }

    }
}