using SchoolManagement.Repository.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DTO
{
    public class MonHoc:IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Subject { get; set; }
        public int Credits { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public ICollection<DangKiMonHoc> DangKiMonHocs { get; set; }
    }
}
