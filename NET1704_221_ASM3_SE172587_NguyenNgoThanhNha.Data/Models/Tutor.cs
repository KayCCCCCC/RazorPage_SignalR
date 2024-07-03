using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Enums;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models
{
    public class Tutor
    {
        [Key] public int Id { get; set; }

        public Guid TutorId { get; set; }

        [Required]
        [DisplayName("Tên giảng viên")]
        [MaxLength(100, ErrorMessage = "Tên giảng viên tối đa 100 kí tự.")]
        public string Fullname { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email tối đa 100 kí tự.")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(\+84|0)[1-9]\d{8}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [DisplayName("Số điện thoại")]
        [MaxLength(12, ErrorMessage = "Số điện thoại tối đa 100 kí tự.")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [DisplayName("Địa chỉ")]
        [MaxLength(300, ErrorMessage = "Địa chỉ tối đa 300 kí tự.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        [DisplayName("Giới tính")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Giới tính không hợp lệ")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }


        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
