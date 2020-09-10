using SchoolManagement.Repository.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DTO
{
    public class SinhVien : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public ICollection<DangKiMonHoc> DangKiMonHocs { get; set; }
    }
}
