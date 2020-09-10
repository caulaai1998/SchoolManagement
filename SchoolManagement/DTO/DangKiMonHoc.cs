using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DTO
{
    public class DangKiMonHoc
    {
        [Key]
        public int ID { get; set; }
        public int MonHocID { get; set; }
        public int SinhVienID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public SinhVien SinhVien { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
