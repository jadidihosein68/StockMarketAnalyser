﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LinqToTwitter;
using Microsoft.Extensions.Options;
using StockMarket.Adapter.Interface;
using StockMarket.Model;
using StockMarket.Model.Configuration;

namespace StockMarket.Adapter {
    public class TwitterAdapter : ITwitterAdapter {
        private readonly AppConfiguration AppConfiguration;
        private readonly SingleUserAuthorizer Athorization;

        public TwitterAdapter (IOptions<AppConfiguration> _AppConfiguration) {
            AppConfiguration = _AppConfiguration.Value;
            Athorization = new SingleUserAuthorizer {
                CredentialStore = new InMemoryCredentialStore {
                ConsumerKey = AppConfiguration.TwitterCrodential.consumerKey,
                ConsumerSecret = AppConfiguration.TwitterCrodential.consumerSecret,
                OAuthToken = AppConfiguration.TwitterCrodential.accessToken,
                OAuthTokenSecret = AppConfiguration.TwitterCrodential.accessTokenSecret
                }
            };

        }

        public LinqToTwitterResponces GetTweettsFromTwitterByNameAndDate (TwitterFilter Filter) {

            if (string.IsNullOrEmpty (Filter.screenName))
                return null;

            var twitterContext = new TwitterContext (Athorization);

            var statusTweets = twitterContext.Status.Where (
                c => c.Type == StatusType.User &&
                c.ScreenName == Filter.screenName &&
                c.IncludeContributorDetails == true &&
                c.Count == 200 &&
                c.IncludeEntities == true &&
                c.CreatedAt > Filter.LatestTweets
            );

            List<Tweet> mystorage = SendRequestToGetTweets (statusTweets, twitterContext, Filter.screenName);

            if (mystorage == null) {
                mystorage = new List<Tweet> ();
            }

            LinqToTwitterResponces response = new LinqToTwitterResponces () {
                ScreenName = Filter.screenName,
                TotalNoOfTweets = mystorage.Count,
                Tweets = mystorage
            };
            return response;

        }

        public LinqToTwitterResponces GetTweetsFromTwitter (string ScreenName) {

            if (string.IsNullOrEmpty (ScreenName))
                return null;

            var twitterContext = new TwitterContext (Athorization);

            var statusTweets = twitterContext.Status.Where (
                c => c.Type == StatusType.User &&
                c.ScreenName == ScreenName &&
                c.IncludeContributorDetails == true &&
                c.Count == 200 &&
                c.IncludeEntities == true);

            List<Tweet> mystorage = SendRequestToGetTweets (statusTweets, twitterContext, ScreenName);

            if (mystorage == null) {
                mystorage = new List<Tweet> ();
            }

            LinqToTwitterResponces response = new LinqToTwitterResponces () {
                ScreenName = ScreenName,
                TotalNoOfTweets = mystorage.Count,
                Tweets = mystorage
            };
            return response;

        }

        private List<Tweet> SendRequestToGetTweets (IQueryable<Status> statusTweets, TwitterContext twitterContext, string ScreenName) {
            ulong temp = 0;
            int i = 0;
            List<Tweet> mystorage = new List<Tweet> ();

            try {

                foreach (var statusTweet in statusTweets) {
                    i++;
                    DateTime dt = Convert.ToDateTime (statusTweet.CreatedAt);
                    mystorage.Add (new Tweet () {
                        Date = dt,
                            Screen_Name = statusTweet.ScreenName.ToString (),
                            TweetID = statusTweet.StatusID,
                            Tweets = statusTweet.Text.ToString ()
                    });

                    if (i == 200) {
                        temp = statusTweet.StatusID;
                    }
                }

                while (i != 0) {

                    var statusTweets2 =
                        twitterContext.Status.Where (
                            c => c.Type == StatusType.User &&
                            c.ScreenName == ScreenName &&
                            c.IncludeContributorDetails == true &&
                            c.Count == 200 &&
                            c.IncludeEntities == true &&
                            c.MaxID == temp - 1
                        );

                    i = 0;
                    foreach (var statusTweet in statusTweets2) {
                        i++;
                        DateTime dt = Convert.ToDateTime (statusTweet.CreatedAt);
                        mystorage.Add (new Tweet () {
                            Date = dt,
                                Screen_Name = statusTweet.ScreenName.ToString (),
                                TweetID = statusTweet.StatusID,
                                Tweets = statusTweet.Text.ToString ()
                        });
                    }
                    temp = mystorage[mystorage.Count - 1].TweetID;
                }

                return mystorage;
            } catch { return null; }
        }

    }

}