﻿using System.Collections.Generic;

namespace ClientApp
{
    public partial class PasswordManagerDbContext
    {
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Item> Items { get; set; }
        }
    }
}
