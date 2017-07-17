using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VLMS.Database;
using VLMS.Web.Models;

namespace VLMS.Web.Infracstructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateItem(this Item item, ItemViewModel itemVm)
        {
            item.Id = itemVm.Id;
            item.Name = itemVm.Name;
            item.Description = itemVm.Description;
            item.SerialNumber = itemVm.SerialNumber;
            item.AdditionalName = itemVm.AdditionalName;

            item.ManufactoryId = itemVm.ManufactoryId;
            item.MadeInCountryId = itemVm.MadeInCountryId;
            item.ManagedByLibrarianId = itemVm.ManagedByLibrarianId;
            item.LibraryId = itemVm.LibraryId;
            item.ContributorId = itemVm.ContributorId;

            item.ContributionDate = itemVm.ContributionDate;
            item.OriginalPrice = itemVm.OriginalPrice;
            item.PresentValue = itemVm.PresentValue;
            item.Rating = itemVm.Rating;
            item.StatusId = itemVm.StatusId;

            item.CreatedByUserId = itemVm.CreatedByUserId;
            item.CreatedDateTime = itemVm.CreatedDateTime;
            item.LastModifiedByUserId = itemVm.LastModifiedByUserId;
            item.LastModifiedDataTime = itemVm.LastModifiedDataTime;
            item.IsActive = itemVm.IsActive;
         
        }

        public static void UpdateCategory(this Category category, CategoryViewModel categoryVm)
        {
            category.Id = categoryVm.Id;
            category.Name = categoryVm.Name;
            category.Description = categoryVm.Description;
            category.ParrentCategoryId = categoryVm.ParrentCategoryId;
            category.LibraryId = categoryVm.LibraryId;
            category.CreatedByUserId = categoryVm.CreatedByUserId;
            category.CreatedDateTime = categoryVm.CreatedDateTime;
            category.LastModifiedByUserId = categoryVm.LastModifiedByUserId;
            category.LastModifiedDataTime = categoryVm.LastModifiedDataTime;
            category.IsActive = categoryVm.IsActive;
        }
    }
}