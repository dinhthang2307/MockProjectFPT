using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VLMS.Database;
using VLMS.Service;
using VLMS.Web.Infracstructure.Core;
using VLMS.Web.Infracstructure.Extensions;
using VLMS.Web.Models;

namespace VLMS.Web.Api
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(IErrorService errorService, ICategoryService categoryService) : base(errorService)
        {
            this._categoryService = categoryService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyWord, int page, int pageSize = 6)
        {
             return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _categoryService.GetAll(keyWord);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDateTime)
                .Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(query);

                var paginationSet = new PaginationSet<CategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetCategoryById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var CategoryDb = _categoryService.GetById(id);
                    var responseData = Mapper.Map<Category, CategoryViewModel>(CategoryDb);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });


        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage CreateCategory(HttpRequestMessage request, CategoryViewModel categoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
                }
                else
                {
                    var newCategory = new Category();
                    newCategory.UpdateCategory(categoryVm);

                    _categoryService.Add(newCategory);
                    _categoryService.save();

                    var responseData = Mapper.Map<Category, CategoryViewModel>(newCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _categoryService.Delete(id);
                    _categoryService.save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage UpdateItem(HttpRequestMessage request, CategoryViewModel categoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var CategoryDb = _categoryService.GetById(categoryVm.Id);
                    CategoryDb.UpdateCategory(categoryVm);
                    _categoryService.Update(CategoryDb);
                    _categoryService.save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });


        }

    }
}
