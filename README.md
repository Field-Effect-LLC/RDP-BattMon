# BattMon: An Add-In to Microsoft's Remote Desktop Client to Report Device Battery Life #

## What is this application? #

This is a Remote Desktop Add-in (for MSTSC.exe), that will allow you to report your laptop/tablet/device battery life to the terminal server.

## Why would I want this? ##

If you like to work full screen on a remote desktop connection, but you work from a laptop or other battery powered device, you won't have to exit full screen every time you want to check your battery life.

## How do I install it? ##

Please check the [Releases](https://github.com/Field-Effect-LLC/RDP-BattMon/releases/latest) page for binary files, or build from source using Visual Studio 2017.

### On the Remote Desktop Client Side ###

In the future, I plan to make installation easier for less technical users.  For the time being, you need to install the following registry key:

	HKEY_CURRENT_USER\Software\Microsoft\Terminal Server Client\Default\AddIns\BattMon

Then, add a string value to the `BattMon` Key:

	"Name"="C:\\path\\to\\your\\folder\\RDS_Client_Addin_BattMon.dll"

Alternatively, you can create a Windows registry file:

	Windows Registry Editor Version 5.00

	[HKEY_CURRENT_USER\Software\Microsoft\Terminal Server Client\Default\AddIns\BattMon]
	"Name"="C:\\path\\to\\your\\folder\\RDS_Client_Addin_BattMon.dll"

### On the Remote Desktop Server Side ###

You need to run the `RDS_Server_TrayApp_BattMon.exe` application on the Remote Desktop side.  When it's running, you should see a battery icon on your Remote Desktop's taskbar:

![taskbar_screenshot](https://raw.githubusercontent.com/Field-Effect-LLC/RDP-BattMon/master/taskbar-screenshot.png)

## Screenshot ##

![server_battery](https://raw.githubusercontent.com/Field-Effect-LLC/RDP-BattMon/master/37193691-ff51fee2-2338-11e8-8492-477d6f39c868.png)

## Troubleshooting ##

By default, logs are stored in `%APPDATA%\BattMon\Log.txt`, but they need to be enabled before starting.

### Enable Logging on the Client Side ###

The client won't begin logging until there is a file called `log4net.config` in the same folder as your client-side DLL.  Create a new text file with that name, and paste [this](https://github.com/Field-Effect-LLC/RDP-BattMon/blob/master/Client%20MSTSC%20Add-in/log4net.config) code into it.

Then, change this line:
```
    <level value="INFO" />
```
to this:
```
    <level value="DEBUG" />
```

Once that's done, you can connect to the server using your Remote Desktop client.

### Enable Logging on the Server Side ###

On the server side, you need a configuration file that has the same name as your EXE, with the file extension `.config`.  So, if you're EXE's name is `RDS_Server_TrayApp_BattMon.exe`, create a new text file called `RDS_Server_TrayApp_BattMon.exe.config`, and paste [this](https://github.com/Field-Effect-LLC/RDP-BattMon/blob/master/Tray%20App%20For%20RDP-BattMon/App.config) code in it.

Then, change this line:
```
    <level value="INFO" />
```
to this:
```
    <level value="DEBUG" />
```

Once that's done, you can start the EXE.

## Roadmap ##

Here's my desired roadmap:

 1. Proof-of-concept (complete)
 1. Improve server-side battery reporting application (complete)
    1. Pass client name to server, so app can display the client's name (complete)
    1. Make the app display as a tray icon, instead of a Windows form, to display the battery level, just as the native battery icon would (complete)
 1. Allow multiple batteries to be reported upon (complete)
    1. Right now, it just reports on the first battery it finds.  I don't know how common multiple batteries are, though, so this is low priority unless otherwise determined. (complete)
 1. Create a client-side installer to automatically add the registry entry.

## :musical_note: "BattMon... da-na-na-na-na-na-na-na" ##

I know :wink:

## Credit ##
All credit for Remote Desktop Virtual Channels communication goes to:
https://www.codeproject.com/Articles/16374/How-to-Write-a-Terminal-Services-Add-in-in-Pure-C

