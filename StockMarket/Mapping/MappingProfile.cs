﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using StockMarket.Model.DTO;
using StockMarket.Model.Base;
using StockMarket.Model;

namespace StockMarket.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RowHistoricalStockBase, RowHistoricalStockBaseDTO>();
            CreateMap<TimeSeriesIndex, TimeSeriesDTO>()
            .ForMember(v => v.Id, opt => opt.Ignore());
        }
    }
}
