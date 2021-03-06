# SquirrelFinder
*The Sitefinity Gear UnDistractor* 

Squirrel Finder is a helper utility, originally designed to let you know when Sitefinity was done initializing, but has scaled a bit to help simplify some other stuff.  Basically, I don't want to stare at gears, but I also don't want to go off on too much of a tangent while I'm waiting for them to stop - welcome to Squirrel Finder, the app that doesn't mind watching for you, and will even call you back when it's ready if you want it to.

## Feature Overview
1. Site Warmer - keeing your sites warm (initialized) by pinging them periodically, ensuring they don't go to sleep.
2. IIS Tools - for stopping, starting, and recycling application pools of sites that are buried on your machine.
3. Quick File Access - to log path and site root for any local Sitefinity site.
4. Acorns - NuGet packages you can add to any Sitefinity instance which enables advanced logging, bringing error data back to Squirrel Finder so you don't have to go searching.
4. Site Watcher - allowing any number of sites to be observed, both locally and publicly.
5. Site Saver - keeps track of your sites for next time you launch Squirrel Finder.

## Installation
If you have installed squirrel finder before, you have to uninstall it first before intstalling the latest version.  Sorry, I have limited knowledge around authoring installers.

Once installed, create a shortcut to SquirrelFinder.Forms.exe and configure the shortcut to Run as Administrator.  This is required for the IIS tools to work.

## Usage
Squirrel Finder lives primarily in the taskbar in windows.  To open the main configuraition window, double-click the icon.

### Local sites
Local sites are sites that are found in your local IIS server and can be configured by selecting the site you want to watch, then selecting the binding you want to attach to, and then finally adding to watch.  

### Public sites
Public sites are configured through a URL alone, and can be configured on the Public sites tab.  Select a protocol (HTTP or HTTPS) and enter the URL.  If it is a Sitefinity site, mark it as such so that Squirrel Finder can look for additional stuff.

## Saving sites
sites are saved any time you close the configuration window or the application itself.  To recover your sites, simply open the configuration window next time your run the application and select File -> Load Previous Config.

## Acorns
With the additional NuGet Acorn, any Sitefinity site (public or private) that Squirrel Finder is watching can also bring error data back to your desktop for quick access.  Clicking the Error link will take you to an error page on the site and show recent error information.
