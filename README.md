# BattMon: An Add-In to Microsoft's Remote Desktop Client to Report Device Battery Life #

## What is this application? #

This is a Remote Desktop Add-in (for MSTSC.exe), that will allow you to report your laptop/tablet/device battery life to the terminal server.

## Why would I want this? ##

If you like to work full screen on a remote desktop connection, but you work from a laptop, you won't have to exit full screen every time you want to check your battery life.

## How do I install it? ##

In the future, I plan to make installation easier for less technical users.  For the time being, you need to install the following registry key:

	HKEY_CURRENT_USER\Software\Microsoft\Terminal Server Client\Default\AddIns\BattMon

Then, add a string value to the `BattMon` Key:

	"Name"="C:\\path\\to\\your\\folder\\RDS_Client_Addin_BattMon.dll"

Alternatively, you can create a Windows registry file:

	Windows Registry Editor Version 5.00

	[HKEY_CURRENT_USER\Software\Microsoft\Terminal Server Client\Default\AddIns\BattMon]
	"Name"="C:\\path\\to\\your\\folder\\RDS_Client_Addin_BattMon.dll"


## Roadmap ##

Here's my desired roadmap:

 1. Proof-of-concept (complete)
 2. Improve server-side battery reporting application
    a. Pass client name to server, so app can display the client's name
    b. Make the app display as a tray icon, instead of a Windows form, to display the battery level, just as the native battery icon would
 3. Allow multiple batteries to be reported upon
    a. Right now, it just reports on the first battery it finds.  I don't know how common multiple batteries are, though, so this is low priority unless otherwise determined.
 4. Create a client-side installer to automatically add the registry entry.

## :musical_note: "BattMon... da-na-na-na-na-na-na-na" ##

I know :wink:

## Credit ##
All credit for Remote Desktop Virtual Channels communication goes to:
https://www.codeproject.com/Articles/16374/How-to-Write-a-Terminal-Services-Add-in-in-Pure-C

