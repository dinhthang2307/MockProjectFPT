using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VLMS.Database;

namespace VLMS.Web.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Yêu cầu nhập tên item!")]
        public string Name { get; set; }        
        public string AdditionalName { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }

        public Nullable<int> ManufactoryId { get; set; }
        public Nullable<int> MadeInCountryId { get; set; }
        public Nullable<long> ManagedByLibrarianId { get; set; }
        public int LibraryId { get; set; }
        public Nullable<long> ContributorId { get; set; }

        public Nullable<System.DateTime> ContributionDate { get; set; }
        public Nullable<decimal> OriginalPrice { get; set; }
        public Nullable<decimal> PresentValue { get; set; }
        public Nullable<decimal> Rating { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mã trạng thái!")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập id người nhập!")]
        public long CreatedByUserId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<long> LastModifiedByUserId { get; set; }
        public Nullable<System.DateTime> LastModifiedDataTime { get; set; }
        [Required(ErrorMessage = "Yêu cầu trạng thái!")]
        public bool IsActive { get; set; }
      
    }
}