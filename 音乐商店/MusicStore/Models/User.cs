using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class User
    {
        public int UserId { get; set; }//自动属性
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名不能为空")]//非空字段
        [StringLength(10)]
        public string UserName { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空")]//非空字段
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
        [DisplayName("确认密码")]
        [Required(ErrorMessage = "确认密码不能为空")]//非空字段
        [Compare("Password")]//必须和密码匹配
        [StringLength(10, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
    }
}