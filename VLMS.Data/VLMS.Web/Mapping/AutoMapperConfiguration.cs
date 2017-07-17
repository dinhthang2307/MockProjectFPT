using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VLMS.Database;
using VLMS.Web.Models;

namespace VLMS.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Item, ItemViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
            });
        }
    }
}