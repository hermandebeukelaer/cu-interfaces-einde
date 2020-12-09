﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Pra.Interfaces.CORE.Classes;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Television tvLivingRoom;
        Radio radioKitchen;
        SmartLamp lampHallway;
        List<ElectricalAppliance> electricalAppliances;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PowerOn(IPowerable item)
        {
            string text = item.PowerOn();
            UpdatePowerLabel(item, text, Brushes.LightGreen);
        }

        private void PowerOff(IPowerable item)
        {
            string text = item.PowerOff();
            UpdatePowerLabel(item, text, Brushes.Red);
        }

        private void UpdatePowerLabel(IPowerable item, string text, Brush color)
        {
            Label label = lblSmartLampHallway;
            if (item is Television) label = lblTVLivingRoom;
            if (item is Radio) label = lblRadioKitchen;

            label.Content = text;
            label.Background = color;
        }

        private void UpdateVolumeLabel(IVolumeChangeable item)
        {
            Label volumeLabel = item is Television ? lblTVLivingRoomVolume : lblRadioKitchenVolume;
            volumeLabel.Content = item.CurrentVolume;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tvLivingRoom = new Television("leefkamer");
            radioKitchen = new Radio("keuken");
            lampHallway = new SmartLamp("gang");

            electricalAppliances = new List<ElectricalAppliance>
            {
                tvLivingRoom,
                radioKitchen,
                lampHallway
            };

            lblTVLivingRoomVolume.Content = tvLivingRoom.CurrentVolume;
            lblRadioKitchenVolume.Content = radioKitchen.CurrentVolume;
            
        }

        private void BtnTVLivingRoomPower_Click(object sender, RoutedEventArgs e)
        {
            if (tvLivingRoom.IsOn)
            {
                PowerOff(tvLivingRoom);
            }
            else
            {
                PowerOn(tvLivingRoom);
            }
        }

        private void BtnSmartLampHallwayPower_Click(object sender, RoutedEventArgs e)
        {
            if (lampHallway.IsOn)
            {
                PowerOff(lampHallway);
            }
            else
            {
                PowerOn(lampHallway);
            }
        }

        private void BtnRadioKitchenPower_Click(object sender, RoutedEventArgs e)
        {
            if (radioKitchen.IsOn)
            {
                PowerOff(radioKitchen);
            }
            else
            {
                PowerOn(radioKitchen);
            }
        }

        private void BtnTVLivingRoomVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            if (tvLivingRoom.IsOn)
            {
                tvLivingRoom.VolumeDown();
                lblTVLivingRoomVolume.Content = tvLivingRoom.CurrentVolume;
            }
        }

        private void BtnTVLivingRoomVolumeUp_Click(object sender, RoutedEventArgs e)
        {
            if (tvLivingRoom.IsOn)
            {
                tvLivingRoom.VolumeUp();
                lblTVLivingRoomVolume.Content = tvLivingRoom.CurrentVolume;
            }
        }

        private void BtnRadioKitchenVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            if (radioKitchen.IsOn)
            {
                radioKitchen.VolumeDown();
                lblRadioKitchenVolume.Content = radioKitchen.CurrentVolume;
            }
        }

        private void BtnRadioKitchenVolumeUp_Click(object sender, RoutedEventArgs e)
        {
            if (radioKitchen.IsOn)
            {
                radioKitchen.VolumeUp();
                lblRadioKitchenVolume.Content = radioKitchen.CurrentVolume;
            }
        }


        private void BtnStartAll_Click(object sender, RoutedEventArgs e)
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IPowerable powerableItem in electricalAppliances)
            {
                if (powerableItem.IsOn)
                {
                    stringBuilder.Append($"{powerableItem} lag al aan en blijft aan\n");
                }
                else
                {
                    PowerOn(powerableItem);
                    stringBuilder.Append($"{powerableItem} werd ingeschakeld\n");
                }
            }

            tbkFeedback.Text = stringBuilder.ToString();
        }

        private void BtnStopAll_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (IPowerable powerableItem in electricalAppliances)
            {
                if (!powerableItem.IsOn)
                    stringBuilder.Append($"{powerableItem} was reeds uitgeschakeld\n");
                else
                {
                    PowerOff(powerableItem);
                    stringBuilder.Append($"{powerableItem} werd uitgeschakeld\n");
                }
            }

            tbkFeedback.Text = stringBuilder.ToString();
        }

        private void BtnAllVolumeUpn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (IPowerable powerableItem in electricalAppliances)
            {
                if (powerableItem is IVolumeChangeable volumeChangeable)
                {
                    if (!powerableItem.IsOn)
                    {
                        stringBuilder.AppendLine($"{powerableItem} is uitgeschakeld en wordt niet gewijzigd");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"{volumeChangeable}: ");
                        stringBuilder.Append($"\tVolume was: {volumeChangeable.CurrentVolume}");
                        volumeChangeable.VolumeUp();
                        stringBuilder.AppendLine($"\tVolume is verhoogd tot: {volumeChangeable.CurrentVolume}");

                        UpdateVolumeLabel(volumeChangeable);
                    }
                }

            }

            tbkFeedback.Text = stringBuilder.ToString();
        }

        private void BtnAllVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (IPowerable powerableItem in electricalAppliances)
            {
                if(powerableItem is IVolumeChangeable volumeChangeable)
                {
                    if (!powerableItem.IsOn)
                    {
                        stringBuilder.AppendLine($"{powerableItem} is uitgeschakeld en wordt niet gewijzigd");
                    }
                    else 
                    {
                        stringBuilder.AppendLine($"{volumeChangeable}: ");
                        stringBuilder.Append($"\tVolume was: {volumeChangeable.CurrentVolume}");
                        volumeChangeable.VolumeDown();
                        stringBuilder.AppendLine($"\tVolume is verlaagd tot: {volumeChangeable.CurrentVolume}");

                        UpdateVolumeLabel(volumeChangeable);
                    }
                }

            }

            tbkFeedback.Text = stringBuilder.ToString();
        }

        private void BtnCheckConnections_Click(object sender, RoutedEventArgs e)
        {
            List<IConnectionCheckable> connectionChecks = new List<IConnectionCheckable>
            {
                new Radio("keuken"),
                new Television("keuken"),
                new Radio("badkamer"),
                new Radio("living"),
                new Television("living"),
                new Television("slaapkamer"),
                new Radio("wc")
            };

            tbkFeedback.Text = "";
            foreach (IConnectionCheckable check in connectionChecks)
            {
                tbkFeedback.Text += check.CheckBroadcastConnection();
            }
        }

    }
}
