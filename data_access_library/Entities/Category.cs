﻿namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Element> Elements { get; set; }
        }
    }
}
