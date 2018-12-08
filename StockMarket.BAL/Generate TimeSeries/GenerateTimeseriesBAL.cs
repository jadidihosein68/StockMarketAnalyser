﻿
using StockMarket.BAL.Generate_TimeSeries.Interfaces;
using StockMarket.DAL.Interface.Persistance.Repositories;
using StockMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.BAL.Generate_TimeSeries
{
    public class GenerateTimeseriesBAL : IGenerateTimeseriesBAL
    {
        private readonly IRdotNetRepositories RdotNetRepositories;
        private readonly IQuamdlHisoricalStockRepository QuamdlHisoricalStockRepository;

        public GenerateTimeseriesBAL(IRdotNetRepositories _RdotNetRepositories,
                                    IQuamdlHisoricalStockRepository _QuamdlHisoricalStockRepository
            )
        {
            QuamdlHisoricalStockRepository = _QuamdlHisoricalStockRepository;
            RdotNetRepositories = _RdotNetRepositories;
        }


        public IEnumerable<MACDHistoricalStock> generateMacd(string StockIndex)
        {

            var RowData = QuamdlHisoricalStockRepository.GetQuandlData(new RequestHistoricalStockQuandl() { Index = StockIndex }).OrderBy(x => x.Date).ToList();
            var MACD = RdotNetRepositories.getMACD(RowData);
            return MACD;

        }

        public IEnumerable<StochasticOscillatorHistoricalStock> generateStochasticOscillator(string StockIndex)
        {

            var RowData = QuamdlHisoricalStockRepository.GetQuandlData(new RequestHistoricalStockQuandl() { Index = StockIndex }).OrderBy(x => x.Date).ToList();
            var StochasticOscillator = RdotNetRepositories.GetStochasticOscillator(RowData);
            return StochasticOscillator;

        }


        public IEnumerable<RSIHistoricalStock> generateRSI(string StockIndex)
        {

            var RowData = QuamdlHisoricalStockRepository.GetQuandlData(new RequestHistoricalStockQuandl() { Index = StockIndex }).OrderBy(x => x.Date).ToList();
            var RSI = RdotNetRepositories.GetRSI(RowData);
            return RSI;

        }

        public IEnumerable<GuppyHistoricalStock> generateGuppy(string StockIndex)
        {

            var RowData = QuamdlHisoricalStockRepository.GetQuandlData(new RequestHistoricalStockQuandl() { Index = StockIndex }).OrderBy(x => x.Date).ToList();
            var RSI = RdotNetRepositories.GetGuppy(RowData);
            return RSI;

        }
    }
}