﻿using SpotzerProject.Interfaces;
using SpotzerProject.Models;
using System;

namespace SpotzerProject.HelperFunctions
{
    public class ObjectFactoryDynamic : IFactory
    {
        private IConverterSp _converter;

        /// <summary>
        /// DI with Simple Injector of Converters object
        /// </summary>
        /// <param name="converter"></param>
        public ObjectFactoryDynamic(IConverterSp converter)
        {
            _converter = converter;
        }

        /// <summary>
        /// Get the Json Data and dynamically convert the objects
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductJson DynamicObjectAllocatorFactory(ProductJson data)
        {
            if (data.LineItems == null)
                throw new Exception("Products require Line Items. Invalid json");

            foreach (var line in data.LineItems)
            {
                line.Website = _converter.CastDynamicly(line.Website, line.ProductType);                
            }

            return data;
        }
    }
}
