﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.FavoriteProperty
{
    public class FavoritePropertyViewModel
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int PropertyId { get; set; }
    }
}
