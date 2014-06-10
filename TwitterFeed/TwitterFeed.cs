using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive;
using System.Reactive.Linq;
using RestSharp;
using TweetSharp;
using System.Reactive.Concurrency;
using System.Threading;
namespace TwitterFeed
{
    public partial class TwitterFeed : Form
    {

        private long? lastTweetId;
        private IDisposable subscription;
        private TwitterService service;
        public TwitterFeed()
        {
            InitializeComponent();
        }

        private void TwitterFeed_Load(object sender, EventArgs e)
        {
            service = TwitterServiceFactory.create();
            Observable.FromEventPattern(this.btnSearch, "Click")
                .Subscribe(
                   args =>
                   {
                       if (string.IsNullOrWhiteSpace(txtFind.Text)) return;
                       txtFeed.Text = "";
                       long retweetCount = getRetweetCount();
                       searchTweets(txtFind.Text, txtTag.Text, retweetCount);
                   }
                );
        }

        private long getRetweetCount()
        {
            long count = 0;
            long.TryParse(txtRetweetCount.Text, out count);
            return count;
        }

        private void searchTweets(string handle, string tag, long retweetCount = 0)
        {

            if (subscription != null)
            {
                subscription.Dispose();
            }
            SearchOptions options = new SearchOptions();
            options.Q = handle;
            options.Count = 10;
            options.Lang = "en";
            options.SinceId = lastTweetId;
            subscription =
            Observable.Interval(TimeSpan.FromSeconds(2))
                .Select(ticks => service.Search(options))
                .SelectMany(response => response.Statuses)
                .Where(x => x.HasHashTag(tag))
                .Where(x => x.RetweetCount > retweetCount)
                .Subscribe(
                    status =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            options.SinceId = status.Id;
                            txtFeed.Text =
                                string.Format("\r\nTweet:{0}\r\nRetweetCount:{1}\r\n\r\n{2}",
                                    status.Text, status.RetweetCount, txtFeed.Text);
                        });
                    },
                    ex =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            txtFeed.Text = ex.Message;
                        });
                    },
                    () =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            txtFeed.Text = "Done";
                        });
                    }
                );
        }
    }
}
