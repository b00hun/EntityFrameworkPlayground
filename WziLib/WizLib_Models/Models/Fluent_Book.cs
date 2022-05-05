using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Models.Models
{
    public class Fluent_Book
    {
        
        public int Book_Id { get; set; }
        
        public string Title { get; set; }
        
       
        public string ISBN { get; set; }
       
        public double Price { get; set; }

       
        public int BookDetail_Id { get; set; }

        public BookDetail BookDetail { get; set; }
        

        public int Publisher_Id { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
