using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MROpenBCI.Model.OpenBCI.Wifi;
using MROpenBCI.Services;
using Xamarin.Forms;
using XamarinUniversity.Infrastructure;

namespace MROpenBCI.ViewModels
{
    public class FeedViewModel : SimpleViewModel
    {
        private IDependencyService serviceLocator;
        private ICommand connectToDeviceCommand;

        private string lastConnectivityDisplay;
        private string isBoardConnected;
        private string deviceIpAddress;
        private string connectedBoardType;
        private int connectedBoardChannelCount;
        private string connectedBoardGains;


        public FeedViewModel()
        {
            //this.serviceLocator = Settings.Current.ServiceLocater;
            LastConnectivityDisplay = "Enter IP of WiFi to Connect";

            this.connectToDeviceCommand = new Command(() => this.ExecuteConnectToDeviceCommandAsync());
        }



        public async Task ExecuteConnectToDeviceCommandAsync()
        {
            try
            {
                await this.ExecuteGetDeviceInfo();
            }
            catch (Exception ex)
            {
                ex.Data["method"] = "ExecuteConnectToDeviceCommand";

                //Logger.Report(ex);
            }
        }

        public async Task ExecuteGetDeviceInfo()
        {
            try
            {
                //TODO: clean up after working test
                RestClientService restClientService = new RestClientService();
                

                Board BoardInfo = await restClientService.GetBoardInfo(DeviceIpAddress.Trim());

                if (BoardInfo == null)
                {
                    IsBoardConnected = "Error";
                    ConnectedBoardType = "Unable to detect";
                    ConnectedBoardChannelCount = 0;
                    //ConnectedBoardGains;
                }

                if (!BoardInfo.board_connected)
                {
                    LastConnectivityDisplay = "Error connecting to Board. Check Pins and EXTPWRSwitch and Try Again";
                    IsBoardConnected = "No";
                }
                else
                {
                    LastConnectivityDisplay = "Connected to WiFi Shield & Board";
                    IsBoardConnected = "Yes";
                    ConnectedBoardType = BoardInfo.board_type;
                    ConnectedBoardChannelCount = BoardInfo.num_channels;

                    StringBuilder builder = new StringBuilder();
                    foreach (int gain in BoardInfo.gains) // Loop through all strings
                    {
                        builder.Append(gain).Append(", "); // Append string to StringBuilder
                    }
                    ConnectedBoardGains = builder.ToString(); // Get string from StringBuilder

                    //ConnectedBoardGains = BoardInfo.gains.ToString();
                }
                
            }
            catch(Exception ex)
            {
                //this.PageLoadStatus = PageLoadStatus.Exception;

                ex.Data["method"] = "ExecuteGetDeviceInfo";
            }

        }


        public ICommand ConnectToDeviceCommand => this.connectToDeviceCommand;


        public string LastConnectivityDisplay
        {
            get { return lastConnectivityDisplay; }
            set
            {
                if (lastConnectivityDisplay != value)
                {
                    lastConnectivityDisplay = value;
                    RaisePropertyChanged(nameof(LastConnectivityDisplay));
                }
            }
        }

        public string IsBoardConnected
        {
            get { return IsBoardConnected; }
            set
            {
                if (isBoardConnected != value)
                {
                    isBoardConnected = value;
                    RaisePropertyChanged(nameof(LastConnectivityDisplay));
                }
            }
        }

        public string DeviceIpAddress
        {
            get { return deviceIpAddress; }
            set
            {
                if (deviceIpAddress != value)
                {
                    deviceIpAddress = value;
                    RaisePropertyChanged(nameof(DeviceIpAddress));
                }
            }
        }

        public string ConnectedBoardType
        {
            get { return connectedBoardType; }
            set
            {
                if (connectedBoardType != value)
                {
                    connectedBoardType = value;
                    RaisePropertyChanged(nameof(ConnectedBoardType));
                }
            }
        }

        public int ConnectedBoardChannelCount
        {
            get { return connectedBoardChannelCount; }
            set
            {
                if (connectedBoardChannelCount != value)
                {
                    connectedBoardChannelCount = value;
                    RaisePropertyChanged(nameof(ConnectedBoardChannelCount));
                }
            }
        }

        public string ConnectedBoardGains
        {
            get { return connectedBoardGains; }
            set
            {
                if (connectedBoardGains != value)
                {
                    connectedBoardGains = value;
                    RaisePropertyChanged(nameof(ConnectedBoardGains));
                }
            }
        }

    }
}
