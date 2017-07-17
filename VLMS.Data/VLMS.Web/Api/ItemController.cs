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
    [RoutePrefix("api/item")]
    public class ItemController : ApiControllerBase
    {
        private IItemService _itemService;

        public ItemController(IErrorService errorService, IItemService itemService) :
            base(errorService)
        {
            this._itemService = itemService;

        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetItemById(HttpRequestMessage request, int id)
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
                    var ItemDb = _itemService.GetById(id);
                    var responseData = Mapper.Map<Item, ItemViewModel>(ItemDb);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });


        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyWord, int page, int pageSize = 6)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _itemService.GetAll(keyWord);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDateTime)
                    .Skip(page * pageSize).Take(pageSize);

              
                var responseData = Mapper.Map<IEnumerable<Item>,
                    IEnumerable<ItemViewModel>>(query);
                var paginationSet = new PaginationSet<ItemViewModel>()
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

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage CreateItem(HttpRequestMessage request, ItemViewModel itemVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
                }
                else
                {
                    var newItem = new Item();
                    newItem.UpdateItem(itemVm);

                    _itemService.Add(newItem);
                    _itemService.save();

                    var responseData = Mapper.Map<Item, ItemViewModel>(newItem);
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
                    _itemService.Delete(id);
                    _itemService.save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage UpdateItem(HttpRequestMessage request, ItemViewModel itemVm)
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
                    var ItemDb = _itemService.GetById(itemVm.Id);
                    ItemDb.UpdateItem(itemVm);
                    _itemService.Update(ItemDb);
                    _itemService.save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

    
        }
    }
}