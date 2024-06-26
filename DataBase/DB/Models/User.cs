﻿using System;
using System.Collections.Generic;

namespace DataBase.DB.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Age { get; set; }
    }
}
