using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLMS.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên Category!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParrentCategoryId { get; set; }
        public Nullable<int> LibraryId { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên id người tạo!")]
        public long CreatedByUserId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<long> LastModifiedByUserId { get; set; }
        public Nullable<System.DateTime> LastModifiedDataTime { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên trạng thái!")]
        public bool IsActive { get; set; }
    }
}