using System;
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
                lblTVLivingRoom.Content = tvLivingRoom.PowerOff();
                lblTVLivingRoom.Background = Brushes.Red;
            }
            else
            {
                lblTVLivingRoom.Content = tvLivingRoom.PowerOn();
                lblTVLivingRoom.Background = Brushes.LightGreen;
            }
        }

        private void BtnSmartLampHallwayPower_Click(object sender, RoutedEventArgs e)
        {
            if (lampHallway.IsOn)
            {
                lblSmartLampHallway.Content = lampHallway.PowerOff();
                lblSmartLampHallway.Background = Brushes.Red;
            }
            else
            {
                lblSmartLampHallway.Content = lampHallway.PowerOn();
                lblSmartLampHallway.Background = Brushes.LightGreen;
            }
        }

        private void BtnRadioKitchenPower_Click(object sender, RoutedEventArgs e)
        {
            if (radioKitchen.IsOn)
            {
                lblRadioKitchen.Content = radioKitchen.PowerOff();
                lblRadioKitchen.Background = Brushes.Red;
            }
            else
            {
                lblRadioKitchen.Content = radioKitchen.PowerOn();
                lblRadioKitchen.Background = Brushes.LightGreen;
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
               
                if (powerableItem is Television)
                {
                    if (powerableItem.IsOn)
                        stringBuilder.Append($"TV leefkamer lag al aan en blijft aan\n");
                    else
                    {
                        powerableItem.PowerOn();
                        lblTVLivingRoom.Content = "AAN";
                        lblTVLivingRoom.Background = Brushes.LightGreen;
                        stringBuilder.Append($"TV leefkamer werd ingeschakeld\n");

                    }
                }
                if (powerableItem is Radio)
                {
                    if (powerableItem.IsOn)
                        stringBuilder.Append($"Radio keuken lag al aan en blijft aan\n");
                    else
                    {
                        powerableItem.PowerOn();
                        lblRadioKitchen.Content = "AAN";
                        lblRadioKitchen.Background = Brushes.LightGreen;
                        stringBuilder.Append($"Radio keuken werd ingeschakeld\n");

                    }
                }
                if (powerableItem is SmartLamp)
                {
                    if (powerableItem.IsOn)
                        stringBuilder.Append($"Lamp gang lag al aan en blijft aan\n");
                    else
                    {
                        powerableItem.PowerOn();
                        lblSmartLampHallway.Content = "AAN";
                        lblSmartLampHallway.Background = Brushes.LightGreen;
                        stringBuilder.Append($"Lamp gang werd ingeschakeld\n");

                    }
                }
            }

            tbkFeedback.Text = stringBuilder.ToString();
        }

        private void BtnStopAll_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (IPowerable powerableItem in electricalAppliances)
            {
                if (powerableItem is Television)
                {
                    if (!powerableItem.IsOn)
                        stringBuilder.Append($"TV living was reeds uitgeschakeld\n");
                    else
                    {
                        powerableItem.PowerOff();
                        lblTVLivingRoom.Content = "UIT";
                        lblTVLivingRoom.Background = Brushes.Red;
                        stringBuilder.Append($"TV living werd uitgeschakeld\n");

                    }
                }
                if (powerableItem is Radio)
                {
                    if (!powerableItem.IsOn)
                        stringBuilder.Append($"Radio keuken was reeds uitgeschakeld\n");
                    else
                    {
                        powerableItem.PowerOff();
                        lblRadioKitchen.Content = "UIT";
                        lblRadioKitchen.Background = Brushes.Red;
                        stringBuilder.Append($"Radio keuken werd uitgeschakeld\n");

                    }
                }
                if (powerableItem is SmartLamp)
                {
                    if (!powerableItem.IsOn)
                        stringBuilder.Append($"Lamp gang was reeds uitgeschakeld\n");
                    else
                    {
                        powerableItem.PowerOff();
                        lblSmartLampHallway.Content = "UIT";
                        lblSmartLampHallway.Background = Brushes.Red;
                        stringBuilder.Append($"Lamp gang werd uitgeschakeld\n");

                    }
                }
            }

            tbkFeedback.Text = stringBuilder.ToString();
        }

        private void BtnAllVolumeUpn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (IPowerable powerableItem in electricalAppliances)
            {
                ElectricalAppliance electricalAppliance = (ElectricalAppliance)powerableItem;

                if (!powerableItem.IsOn && electricalAppliance is IVolumeChangeable)
                {
                    if (electricalAppliance is Television)
                    {
                        stringBuilder.AppendLine($"TV {electricalAppliance.Room} is uitgeschakeld en wordt niet gewijzigd");
                    }
                    if (electricalAppliance is Radio)
                    {
                        stringBuilder.AppendLine($"Radio {electricalAppliance.Room} is uitgeschakeld en wordt niet gewijzigd");
                    }
                }
                if (powerableItem.IsOn && electricalAppliance is IVolumeChangeable)
                {
                    IVolumeChangeable volumeChangeableItem = (IVolumeChangeable)electricalAppliance;
                    if (electricalAppliance is Television)
                    {
                        stringBuilder.AppendLine($"TV {electricalAppliance.Room} : ");
                        stringBuilder.Append($"\tVolume was: {volumeChangeableItem.CurrentVolume}");
                        volumeChangeableItem.VolumeUp();
                        stringBuilder.AppendLine($"\tVolume is verhoogd tot : {volumeChangeableItem.CurrentVolume}");
                        lblTVLivingRoomVolume.Content = volumeChangeableItem.CurrentVolume;
                    }
                    if (electricalAppliance is Radio)
                    {
                        stringBuilder.AppendLine($"Radio {electricalAppliance.Room} : ");
                        stringBuilder.Append($"\tVolume was: {volumeChangeableItem.CurrentVolume}");
                        volumeChangeableItem.VolumeUp();
                        stringBuilder.AppendLine($"\tVolume is verhoogd tot: {volumeChangeableItem.CurrentVolume}");
                        lblRadioKitchenVolume.Content = volumeChangeableItem.CurrentVolume;
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
                ElectricalAppliance electricalAppliance = (ElectricalAppliance)powerableItem;

                if (!powerableItem.IsOn && electricalAppliance is IVolumeChangeable)
                {
                    if (electricalAppliance is Television)
                    {
                        stringBuilder.AppendLine($"TV {electricalAppliance.Room} is uitgeschakeld en wordt niet gewijzigd");
                    }
                    if (electricalAppliance is Radio)
                    {
                        stringBuilder.AppendLine($"Radio {electricalAppliance.Room} is uitgeschakeld en wordt niet gewijzigd");
                    }
                }
                if (powerableItem.IsOn && electricalAppliance is IVolumeChangeable)
                {
                    IVolumeChangeable volumeChangeableItem = (IVolumeChangeable)electricalAppliance;
                    if (electricalAppliance is Television)
                    {
                        stringBuilder.AppendLine($"TV {electricalAppliance.Room} : ");
                        stringBuilder.Append($"\tVolume was: {volumeChangeableItem.CurrentVolume}");
                        volumeChangeableItem.VolumeDown();
                        stringBuilder.AppendLine($"\tVolume is verlaagd tot : {volumeChangeableItem.CurrentVolume}");
                        lblTVLivingRoomVolume.Content = volumeChangeableItem.CurrentVolume;
                    }
                    if (electricalAppliance is Radio)
                    {
                        stringBuilder.AppendLine($"Radio {electricalAppliance.Room} : ");
                        stringBuilder.Append($"\tVolume was: {volumeChangeableItem.CurrentVolume}");
                        volumeChangeableItem.VolumeDown();
                        stringBuilder.AppendLine($"\tVolume is verlaagd tot: {volumeChangeableItem.CurrentVolume}");
                        lblRadioKitchenVolume.Content = volumeChangeableItem.CurrentVolume;
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
