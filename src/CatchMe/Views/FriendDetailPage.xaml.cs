using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatchMe.Models;
using CatchMe.ViewModels;
using Naxam.Mapbox;
using Naxam.Controls.Forms;
using System.Collections.Generic;
using GeoJSON.Net.Feature;
using Naxam.Mapbox.Sources;
using Naxam.Mapbox.Layers;
using Naxam.Mapbox.Expressions;
using Naxam.Mapbox.Annotations;

namespace CatchMe.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class FriendDetailPage : ContentPage
    {
        FriendDetailViewModel viewModel;
        const string MAKI_ICON_HARBOR = "harbor-15";

        public FriendDetailPage(FriendDetailViewModel viewModel)
        {
            InitializeComponent();

            map.Center = new LatLng(viewModel.Friend.LastLocation.Latitude, viewModel.Friend.LastLocation.Longitude);
            map.ZoomLevel = 16;
            map.MapStyle = MapStyle.STREETS; //new MapStyle("mapbox://styles/mapbox/cjf4m44iw0uza2spb3q0a7s41");
            map.ZoomEnabled = true;

            BindingContext = this.viewModel = viewModel;
            map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyleLoaded);            
        }

        void HandleStyleLoaded(MapStyle obj)
        {           
            IconImageSource iconImageSource = (ImageSource)"red_marker.png";
            var symbol = new SymbolAnnotation
            {
                Coordinates = new LatLng(viewModel.Friend.LastLocation.Latitude, viewModel.Friend.LastLocation.Longitude),
                IconImage = MAKI_ICON_HARBOR,
                IconSize = 2.0f,
                IsDraggable = true,
                Id = Guid.NewGuid().ToString()
            };

            map.Annotations = new[] { symbol };
        }
    }
}