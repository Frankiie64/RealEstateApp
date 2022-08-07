﻿using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.PropertyImprovement;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Service
{
    public interface IPropertyImprovementService : IGenericServices<SavePropertyImprovementViewModel, PropertyImprovementViewModel, PropertyImprovement>
    {
    }
}
