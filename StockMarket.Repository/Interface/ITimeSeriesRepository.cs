﻿using StockMarket.Model;
using StockMarket.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Repository.Interface
{
    public interface ITimeSeriesRepository
    {
        IEnumerable<TimeSeriesIndex> GetQuandlDataIndex(RequestHistoricalStockQuandl RequestHistoricalStockQuandl);
        IEnumerable<RowHistoricalStockBase> GetQuandlData(RequestHistoricalStockQuandl RequestHistoricalStockQuandl);
        string getStringFromQuandl(RequestHistoricalStockQuandl RequestHistoricalStockQuandl);
        IEnumerable<RowHistoricalStockBase> getTimeSeriesFromDB(string StockIndex);
        void AddRangeToDB(IEnumerable<RowHistoricalStockBase> RowHistoricalStockBase);
        void AddRangeIndexToDB(IEnumerable<TimeSeriesIndex> RowHistoricalStockBase);

    }
}
