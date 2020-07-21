using CustomAPI.Data;
using CustomAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAPI.Services
{
    public class ShoppingRepository : IShopping
    {
        private ShoppingDBContext _dbContext;

        public ShoppingRepository(ShoppingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddItem(Shopping item)
        {
            _dbContext.Shopping.Add(item);
            SaveChanges();
        }

        public void DeleteItem(Shopping item)
        {
            _dbContext.Shopping.Remove(item);
            SaveChanges();
        }

        public IEnumerable<Shopping> GetPagingData(int? pageNumer, int? pageSize)
        {
            int currentPageNumb = pageNumer ?? 1;
            int currentPageSize = pageSize ?? 5;
            var items = _dbContext.Shopping.OrderBy(i => i.ShoppingId);
            var data = items.Skip((currentPageNumb - 1) * currentPageSize).Take(currentPageSize).ToList();
            return data;
        }

        public IEnumerable<Shopping> GetSearch(string search)
        {
            return _dbContext.Shopping.Where(i => i.ItemName.StartsWith(search));
        }

        public IEnumerable<Shopping> GetSortedItem(string sortPrice)
        {
            IQueryable<Shopping> shopping;
            switch (sortPrice)
            {
                case "desc":
                    shopping = _dbContext.Shopping.OrderByDescending(p => p.ShoppingId);
                    break;
                case "asc":
                    shopping = _dbContext.Shopping.OrderBy(p => p.ShoppingId);
                    break;
                default:
                    shopping = _dbContext.Shopping;
                    break;
            }
            return shopping;
        }

        public Shopping GetItem(int id)
        {
            return _dbContext.Shopping.SingleOrDefault(m => m.ShoppingId == id);
        }

        public void Update(Shopping item)
        {
            _dbContext.Shopping.Update(item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
