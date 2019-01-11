using MusicStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    // GET: Order
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }//自动属性
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("账号")]
        public string Username { get; set; }
        [Required(ErrorMessage ="非空字段！")]
        [StringLength(160)]
        //[MaxWords(10)]
        [DisplayName("姓")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [StringLength(160)]
        [DisplayName("名")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [StringLength(70)]
        [DisplayName("地址")]
        public string Address { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [StringLength(40)]
        [DisplayName("市")]
        public string City { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [StringLength(40)]
        [DisplayName("区")]
        public string State { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [StringLength(6)]
        [DisplayName("邮政编码")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [StringLength(40)]
        [DisplayName("国籍")]
        public string Country { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(24)]
        [DisplayName("电话")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "非空字段！")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email地址")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email验证不通过")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("总金额")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [ReadOnly(true)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Order()

        {

            this.OrderDate = DateTime.Now;

        }

    }
}