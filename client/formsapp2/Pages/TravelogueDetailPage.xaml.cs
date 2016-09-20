using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace formsapp2
{
	public partial class TravelogueDetailPage : ContentPage
	{
        Travelogue log;
        HybridWebView webView;

        public TravelogueDetailPage(Travelogue travelogue)
        {
            log = travelogue;
            Title = travelogue.getTitle();
            InitializeComponent();

            webView = new XLabs.Forms.Controls.HybridWebView(new JsonSerializer())
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            makePage();
            Button btn_add = new Button
            {
                Text = "Add new entry"
            };
            Button btn_remove = new Button
            {
                Text = "Remove entry"
            };
            btn_remove.Clicked += Btn_remove_Clicked;
            btn_add.Clicked += Btn_add_Clicked;
            Content = new StackLayout
            {
                Children = { webView,
                btn_add,
                btn_remove
                }
            };
        }

        private void Btn_add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEntryPage(log));
        }

        private async void Btn_remove_Clicked(object sender, EventArgs e)
        {
            if (log != null)
            {
                List<string> items = new List<string>();
                foreach (LogEntry entry in log.getEntries())
                {
                    items.Add(entry.ToString());
                }
                var action = await DisplayActionSheet("Remove:", "Cancel", null, items.ToArray());
                foreach (LogEntry entry in log.getEntries().ToArray())
                {
                    if (action == entry.ToString())
                    {
                        log.removeEntry(entry);
                        makePage();
                    }
                }
            }
        }
        protected override void OnAppearing()
        {
            makePage();
        }
        public void makePage() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<body>");
            //for each entry?
            if (log.getEntries().Count != 0)
            {
                int count = 0;
                foreach (LogEntry entry in log.getEntries())
                {
                    count++;
                    sb.Append("Entry " + count + ": " + entry.getTitle() + "<br/>");
                    sb.Append(entry.getContent());
                    sb.Append("<br/><br/><br/> ");
                }
            }
            else
            {
                sb.Append("No entries yet :(");
            }

            sb.Append("</body>");
            sb.Append("</html>");
            webView.Source = new HtmlWebViewSource { Html = sb.ToString() };
        }
    }
}

