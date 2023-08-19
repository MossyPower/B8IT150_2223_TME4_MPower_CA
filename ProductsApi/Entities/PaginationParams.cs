using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Entities
{
    public class PaginationParams
    {
        private const int _maxItemsPerPage = 50; //Restrict max number of Db items to 50 per page.
        private int itemsPerPage;
        
        public int Page {get; set;} = 1; // reperesents the page number. Set default page number to 1
        public int ItemsPerPage // represents the number of items from the Db displayed on each page of the browser
        {
            get => itemsPerPage; 
            set => itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value; //set the max value to the value entered by the user. Restrict this to 50 as above.
        
        }
    }
}