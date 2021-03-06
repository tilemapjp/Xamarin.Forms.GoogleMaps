﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XFGoogleMapSample
{
    public partial class PinsPage : ContentPage
    {
        public PinsPage()
        {
            InitializeComponent();

            Pin pinTokyo = null;
            Pin pinNewYork = null;

            // Tokyo pin
            buttonAddPinTokyo.Clicked += (sender, e) => 
            {
                pinTokyo = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Tokyo SKYTREE",
                    Address = "Sumida-ku, Tokyo, Japan",
                    Position = new Position(35.71d, 139.81d)
                };
                pinTokyo.Clicked += Pin_Clicked;

                map.Pins.Add(pinTokyo);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(pinTokyo.Position, Distance.FromMeters(5000)));

                ((Button)sender).IsEnabled = false;
                buttonRemovePinTokyo.IsEnabled = true;
            };

            buttonRemovePinTokyo.Clicked += (sender, e) => 
            {
                map.Pins.Remove(pinTokyo);
                pinTokyo.Clicked -= Pin_Clicked;
                pinTokyo = null;
                ((Button)sender).IsEnabled = false;
                buttonAddPinTokyo.IsEnabled = true;
            };
            buttonRemovePinTokyo.IsEnabled = false;

            // New York pin
            buttonAddPinNewYork.Clicked += (sender, e) =>
            {
                pinNewYork = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Central Park NYC",
                    Address = "New York City, NY 10022",
                    Position = new Position(40.78d, -73.96d)
                };
                pinNewYork.Clicked += Pin_Clicked;

                map.Pins.Add(pinNewYork);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(pinNewYork.Position, Distance.FromMeters(5000)));

                ((Button)sender).IsEnabled = false;
                buttonRemovePinNewYork.IsEnabled = true;
            };

            buttonRemovePinNewYork.Clicked += (sender, e) =>
            {
                map.Pins.Remove(pinNewYork);
                pinNewYork.Clicked -= Pin_Clicked;
                pinNewYork = null;
                ((Button)sender).IsEnabled = false;
                buttonAddPinNewYork.IsEnabled = true;
            };
            buttonRemovePinNewYork.IsEnabled = false;

            // Clear Pins
            buttonClearPins.Clicked += (sender, e) => 
            {
                map.Pins.Clear();

                if (pinTokyo != null) pinTokyo.Clicked -= Pin_Clicked;
                if (pinNewYork != null) pinNewYork.Clicked -= Pin_Clicked;
                pinTokyo = null;
                pinNewYork = null;
                buttonAddPinTokyo.IsEnabled = true;
                buttonAddPinNewYork.IsEnabled = true;
                buttonRemovePinTokyo.IsEnabled = false;
                buttonRemovePinNewYork.IsEnabled = false;
            };

            // Select New York Pin
            buttonSelectPinNewYork.Clicked += (sender, e) => 
            {
                if (pinNewYork == null)
                {
                    DisplayAlert("Error", "New York is not added.", "Close");
                    return;
                }

                map.SelectedPin = pinNewYork;
            };

            // Clear Pin Selection
            buttonClearSelection.Clicked += (sender, e) => 
            {
                if (map.SelectedPin == null)
                {
                    DisplayAlert("Error", "Pin is not selected.", "Close");
                    return;
                }

                map.SelectedPin = null;
            };
        }

        void Pin_Clicked(object sender, EventArgs e)
        {
            var pin = (Pin)sender;

            DisplayAlert("Pin Clicked", $"{pin.Label} Clicked.", "Close");
        }
    }
}

