using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace App6
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //On<iOS>().SetUseSafeArea(true);
            var model = new MyViewModel();
            model.ListItems = new List<Item>();

            for (int i=0; i<10; i++)
            {
                model.ListItems.Add(new Item { ItemName = "item" + i, DateTimeSet = "dateTimeSet" });
            }
            BindingContext = model;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            //var page = new SecondPage();

            //OverviewPageModel model = BindingContext as OverviewPageModel;
            ////page.BindingContext = model.VehicleState.Tires;

            ////Navigation.PushAsync(page);
            //model.ImageSource = "Scenery.jpg";
            await CrossMediaManager.Current.PlaybackController.Play();
        }

        async private void PlayVideo(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.PlaybackController.Play();
        }

        private void llv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }

    public class OverviewPageModel : INotifyPropertyChanged
    {
        VehicleStatePageModel vehicleState;
        public VehicleStatePageModel VehicleState
        {
            get
            {
                return vehicleState;
            }
            set
            {
                vehicleState = value;
                OnPropertyChanged("VehicleState");
            }
        }

        private Command<Button> myCommamd;
        public Command<Button> MyCommand
        {
            set
            {
                myCommamd = value;
                OnPropertyChanged("MyCommand");
            }
            get
            {
                return myCommamd;
            }
        }

        string imageSource;
        public string ImageSource
        {
            set
            {
                imageSource = value;
                //OnPropertyChanged("ImageSource");
            }
            get
            {
                return imageSource;
            }
        }

        public OverviewPageModel()
        {
            VehicleState = new VehicleStatePageModel();
            ImageSource = "white.jpg";

            MyCommand = new Command<Button>((button) =>
            {
                var ss = button.BindingContext;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class VehicleStatePageModel : INotifyPropertyChanged
    {
        TiresPageModel tires;
        public TiresPageModel Tires
        {
            get
            {
                return tires;
            }
            set
            {
                tires = value;
                OnPropertyChanged("Tires");
            }
        }

        public VehicleStatePageModel()
        {
            Tires = new TiresPageModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TiresPageModel : INotifyPropertyChanged
    {
        int typeSelectedIndex;
        public int TypeSelectedIndex
        {
            get
            {
                return typeSelectedIndex;
            }
            set
            {
                if (typeSelectedIndex != value)
                {
                    typeSelectedIndex = value;
                    OnPropertyChanged("TypeSelectedIndex");
                }
            }
        }

        List<string> tiresTypeList;
        public List<string> TiresTypeList
        {
            set
            {
                tiresTypeList = value;
                OnPropertyChanged("TiresTypeList");
            }
            get
            {
                return tiresTypeList;
            }
        }

        public TiresPageModel()
        {
            TiresTypeList = new List<string>();
            for (int i=0; i <10; i++)
            {
                TiresTypeList.Add("item" + i);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
