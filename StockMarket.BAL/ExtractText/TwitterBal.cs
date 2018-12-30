﻿using StockMarket.BAL.Generate_TimeSeries.Interfaces;
using StockMarket.Model;
using StockMarket.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BAL.ExtractText
{
    public class TwitterBal : ITwitterBal
    {

        private readonly ITwitterRepository TwitterRepository;
        public TwitterBal(ITwitterRepository _TwitterRepository)
        {
            TwitterRepository = _TwitterRepository;
        }

        public LinqToTwitterResponces GetTweettsFromTwitter(string ScreenName)
        {
            return TwitterRepository.GetTweettsFromTwitter(ScreenName);
        }

    }
}
