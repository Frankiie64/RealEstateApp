using RealEstateApp.Core.Application.ViewModels.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Helper
{
    public sealed class SingletonRepository
    {
        public static SingletonRepository Instance { get; } = new SingletonRepository();

        public SavePropertyViewModel property = new();

        private SingletonRepository()
        {

        }
    }
}
