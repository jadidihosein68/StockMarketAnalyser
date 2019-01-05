﻿using CsvHelper;
using Microsoft.Extensions.Options;
using StockMarket.Adapter.Interface;
using StockMarket.Adapter.Utilities;
using StockMarket.Model;
using StockMarket.Model.Base;
using StockMarket.Model.Configuration;
using StockMarket.Model.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Adapter
{
    public class QuandlHistoricalStockAdapter : IQuandlHistoricalStockAdapter
    {
        private readonly AppConfiguration AppConfiguration;

        public QuandlHistoricalStockAdapter(IHttpClientFactory _httpClientFactory , IOptions<AppConfiguration> _AppConfiguration)
        {
            AppConfiguration = _AppConfiguration.Value;
        }

        public IEnumerable<RowHistoricalStockBase> getCSVFromQuandl(RequestHistoricalStockQuandl RequestHistoricalStock)
        {
            var index = string.IsNullOrEmpty(RequestHistoricalStock.Index) ? QuandlStockIndex.DefaltIndex : RequestHistoricalStock.Index;
            var URL = $"{AppConfiguration.Endpoints.QuadlPoint}{index}/data.{RequestHistoricalStock.DataType}?api_key={AppConfiguration.QuandlAPIKey}";
            var client = new System.Net.WebClient();
            var result = client.DownloadString(URL);
            return (new CSVDeserializer().Decerialize<RowHistoricalStockBase>(result));
        }

        public IEnumerable<TimeSeries> getCSVFromQuandlIndex(RequestHistoricalStockQuandl RequestHistoricalStock)
        {
            var index = string.IsNullOrEmpty(RequestHistoricalStock.Index) ? QuandlStockIndex.DefaltIndex : RequestHistoricalStock.Index;
            var URL = $"{AppConfiguration.Endpoints.QuadlPoint}{index}/data.{RequestHistoricalStock.DataType}?api_key={AppConfiguration.QuandlAPIKey}";
            var client = new System.Net.WebClient();
            var result = client.DownloadString(URL);
            return (new CSVDeserializer().Decerialize<TimeSeries>(result));
        }





        public string getStringFromQuandl(RequestHistoricalStockQuandl RequestHistoricalStock)
        {
            var index = string.IsNullOrEmpty(RequestHistoricalStock.Index) ? QuandlStockIndex.DefaltIndex : RequestHistoricalStock.Index;
            var URL = $"{AppConfiguration.Endpoints.QuadlPoint}{index}/data.{RequestHistoricalStock.DataType}?api_key={AppConfiguration.QuandlAPIKey}";
            var client = new System.Net.WebClient();
            var result = client.DownloadString(URL);
            return (result);
        }
    }

}
