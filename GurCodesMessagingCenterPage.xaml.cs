using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GurCodesMessagingCenter
{
    public partial class GurCodesMessagingCenterPage : ContentPage
    {
        private string _tickContract = "tick";

        public ObservableCollection<string> Events { get; set; } = new ObservableCollection<string>();

        public GurCodesMessagingCenterPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        void HandleFire_Clicked(object sender, System.EventArgs e)
        {
            // Send a message
            MessagingCenter.Send(this, _tickContract, DateTime.Now);
        }

        void HandleSubscribe_Clicked(object sender, EventArgs args)
        {
            MessagingCenter.Subscribe<GurCodesMessagingCenterPage, DateTime>(this, _tickContract, (s,a) => {
                Events.Add($"Received message at {a.ToString()}");
            });
        }

        void HandleClear_Clicked(object sender, EventArgs args)
        {
            Events.Clear();
        }
    }
}