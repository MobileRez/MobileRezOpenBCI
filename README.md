# MobileRezOpenBCI
App that works with the OpenBCI Wifi Shield by PushTheWorld and read data sent from the Cyton &amp; Ganglion boards.

this app is something i am working on as a proof of concept and is avilable as a gudeline for others looking to get started with their own boards. 

## Preview Compiled app links
Android: 
[Android Beta Download](https://install.appcenter.ms/users/mitch.muenster/apps/openbci-wifi-android/distribution_groups/public%20beta) 

UWP: 
[UWP(Windows 10) Beta Download](https://install.appcenter.ms/users/mitch.muenster/apps/openbci-wifi-uwp/distribution_groups/public%20beta)

## Getting Started with the code
More detailed description to come. for now here is some bassic stuff. 

1. Assumes basic Knowledge of setting up mobile enviroments with Visual Studio for testing with Xamarin. 
1. Compiled app not available via github. 
1. anyone looking to use iOS must follow the iOS developer process there is no free workaround for the expensive iPhone you have.

## TODO
- [ ] Add Session Section
  - [ ] Add ConectToBoard Section
    - [ ] Add Device Auto Discovery 
  - [ ] Add start Session Page
    - [ ] Change over from number display to chart showing each channel once conversion library is completed
	- [ ] Add option to save session reccording
	- [ ] Add option to turn on and off channel data from reporting 
	- [ ] Add option to turn on and off if BIAS and SRB1 and SRB2 from being used with signal.
- [ ] Add EEG Section
- [ ] Add WiFi Section for wifi sheild configuration
  - [X] Wire up UI for /board wifi shield call
  - [ ] Wire up UI for /all wifi shield call
- [ ] Add Settings Section
- [ ] Add Android Navigation section
- [ ] Create Conversion library from Microvolts to Brain waves to be run concurrently for up to 16 channles (or more)
- [ ] Add iOS Support
  - [x] Add Proper icons
  - [ ] Add Navigation section
- [ ] Add UWP Support
  - [x] Add Proper icons
  - [ ] Add Navigation section
- [x] Add Links for VS App Center UWP and Android Apps
- [x] Add Analitics and crash Reporting to VS App Center

More features to come!

