using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database;
using VLMS.Database.Infracstructure;
using VLMS.Database.Repository;

namespace VLMS.Service
{
    public interface IItemService
    {
        Item Add(Item item);
        void Update(Item item);
        Item Delete(int id);
        IEnumerable<Item> GetAll();
        //IEnumerable<Item> GetAllByParentId(int parentId);
        IEnumerable<Item> GetAll(string keyWord);
        Item GetById(int id);
        void save();
    }
    public class ItemService : IItemService
    {
        IItemRepository _itemRepository;
        IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this._itemRepository = itemRepository;
            this._unitOfWork = unitOfWork;
        }
        public Item Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public Item Delete(int id)
        {
            return _itemRepository.Delete(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public IEnumerable<Item> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))

                return _itemRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            else
            {
                return _itemRepository.GetAll();
            }
        }
        //public IEnumerable<Item> GetAllByParentId(int parentId)
        //{
        //    return _itemRepository.GetMulti(x=>x.StatusId && x.Pa)
        //}

        public Item GetById(int id)
        {
            return _itemRepository.GetSingleById(id);
        }

        public void save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Item item)
        {
            _itemRepository.Update(item);
        }
    }
}
