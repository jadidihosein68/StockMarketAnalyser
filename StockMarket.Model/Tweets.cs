﻿using StockMarket.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Model
{
    public class Tweet : BaseClass
    {
        public ulong TweetID { get; set;}
        public string Screen_Name { get; set; }
        public DateTime Date { get; set; }
        public string Tweets { get; set; }
    }
}
