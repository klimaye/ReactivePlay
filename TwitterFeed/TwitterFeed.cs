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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFind.Text)) return;
            if (subscription != null)
                subscription.Dispose();
            txtFeed.Text = "";
            searchTweets(txtFind.Text);
        }

        private void searchTweets(string searchTerm)
        {
            SearchOptions options = new SearchOptions();
            options.Q = searchTerm;
            options.Count = 3;
            options.Lang = "en";
            options.SinceId = lastTweetId;
            service.Search(options);

            subscription =
            Observable.Interval(TimeSpan.FromSeconds(5))
                .Select(ticks => service.Search(options))
                .Select(response => response.Statuses)
                .Subscribe(
                    statuses =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (statuses.Count() == 0) return;
                            options.SinceId = statuses.Last().Id;
                            foreach (var status in statuses)
                            {
                                txtFeed.Text =
                                    string.Format("\n{0}\n\n{1}",
                                        status.Text, txtFeed.Text);
                            }
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
