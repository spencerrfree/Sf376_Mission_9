using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sf376_Mission_9.Models
{
    public class EFBookStoreRespository : IBookStoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookStoreRespository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
