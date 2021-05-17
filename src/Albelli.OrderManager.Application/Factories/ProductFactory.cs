using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Domain.Enums;
using Albelli.OrderManager.Domain.Products;
using System;
using System.Collections.Generic;

namespace Albelli.OrderManager.Application.Factories
{
    public class ProductFactory
    {
        private static readonly Dictionary<ProductType, Type> factories = new Dictionary<ProductType, Type>()
        {
            { ProductType.PhotoBook, typeof(PhotoBookFactory) },
            { ProductType.Calendar, typeof(CalendarFactory) },
            { ProductType.Canvas , typeof(CanvasFactory) },
            { ProductType.Cards, typeof(CardsFactory) },
            { ProductType.Mug, typeof(MugFactory) }
        };

        public static Product Create(ProductType type)
        {
            IProductFactory factory = (IProductFactory)Activator.CreateInstance(factories[type]);
            return factory.Create();
        }
    }
}
