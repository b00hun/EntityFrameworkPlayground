﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Models.Models
{
    public class Fluent_BookAuthor
    {
        
        public int Book_Id { get; set; }
        
        public int Author_Id { get; set; }

        
    }
}
