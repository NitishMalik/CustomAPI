using CustomAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAPI.Services
{
    public interface IShopping
    {
        IEnumerable<Shopping> GetSearch(string search);
        IEnumerable<Shopping> GetPagingData(int? pageNumer, int? pageSize);
        IEnumerable<Shopping> GetSortedItem(string sortPrice);
        Shopping GetItem(int id);
        void AddItem(Shopping item);
        void Update(Shopping item);
        void DeleteItem(Shopping item);

        void SaveChanges();
    }
}
