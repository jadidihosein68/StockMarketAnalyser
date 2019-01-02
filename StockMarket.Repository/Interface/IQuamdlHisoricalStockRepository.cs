﻿using StockMarket.Model;
using StockMarket.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Repository.Interface
{
    public interface IQuamdlHisoricalStockRepository
    {
        IEnumerable<RowHistoricalStockBase> GetQuandlData(RequestHistoricalStockQuandl RequestHistoricalStockQuandl);
        string getStringFromQuandl(RequestHistoricalStockQuandl RequestHistoricalStockQuandl);

    }
}
