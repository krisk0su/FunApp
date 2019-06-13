using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace FunApp.Services.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
