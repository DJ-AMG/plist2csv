<b>Introduction</b>
A super simple console application that reads a playlist generated by the DJM-REC app, converting it to a Comma-separated values file whose contents can be cut and paste into a Mixcloud shows “Tracklist & Timestamp” section.

For more information on the DJM-REC app, see:
	https://www.pioneerdj.com/en-gb/product/software/djm-rec/dj-app/overview/

For more information on Mixcloud show see:
	https://help.mixcloud.com/hc/en-us/categories/9923253343900-Shows-and-tracks

<b>Background</b>
The DJM-REC application is available for either iPad or iPhone. Install DJM-REC on your iPhone or iPad, then simply plug your device into any DJM mixer featuring digital send/return using a single USB cable to live stream or record a mix. The app will generate an audio file and in additional a play list file. This play list file will record the tracks played in the mix, including a time stamp recording the point at which each track was introduced into the set. 
For the full playlist information to be recorded, you will need to be using CDJ-3000s with either the DJM-V10, DJM-V10-LF or DJM-A9 mixer. You'll need to connect all CDJs and the mixer via DJ Pro Link. To accomplish this, you’ll need a network switch to connect then all together. I’m using a NETGEAR 5 Port Gigabit Network Switch (GS305), but any good brand should work. You’ll need to install the Pioneer’s DJM-REC application on an iPad/iPhone. Connect the iPhone/iPad to the digital send/receive (USB) on the mixer. The tracks need to have been analysed and imported from Rekordbox. 
You should be now good to go to record your set/mix. All fine and dandy, but if you intended to upload your set to a Mixcloud show, unfortunately the play list file (.plist) generated cannot be used to populate the shows 'Tracklist and Timestamp' section. This is why I wrote this super simple console app. 
Typically, I will transfer the audio and playlist files from my iPad to my PC using a tool called 3uTools (https://www.3u.com/). Once on the PC, I'll use the console app to convert the .plist file to a .csv file. I can then cut and paste the contents of the CSV file into the Mixcloud shows 'Tracklist and Timestamp' section. Voila! 

<b>Building the source</b>
Visual Studio 2022 was used to build this repository running on a Windows 11 machine. You will also need to ensure that both the .NET Framework 4.8 and .NET Core 8.0 installed. 
Load the top level solution file ‘plist2csv.sln’ into Visual studio and build. Two versions of the console app are generated – one for the .NET Framework 4.8 and one for .NET Core 8.0. I typically use the .NET Framework 4.8 version as this will run on most machines.
Enjoy DJ AMG
