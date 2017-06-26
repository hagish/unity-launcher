# unity-launcher

A Tool to make it easy to open different Unity projects with the corresponding Unity version. 

## Screenshot
![Screenshot](https://raw.githubusercontent.com/hagish/unity-launcher/master/screenshot.png)

## Install
* Download the most recent version from: https://github.com/hagish/unity-launcher/raw/master/release/unity-launcher.exe
* Place this config file on your Desktop: https://raw.githubusercontent.com/hagish/unity-launcher/master/release/unity-launcher.txt
* Open the config and adjust the Unity paths and add folders where the launcher searches for projects
* Drag it into your taskbar or whereever

## Usage
* Start it to show a menu window near your mouse cursor with a list of your Unity versions and projects
    * Clicking on a button will open the corresponding Unity version
    * or project using the fitting Unity version
* ESC closes the popup window

## Command line arguments
* If you don't want to use the unity-launcher.txt config on your desktop you can the absolute path to another file as the first argument.
    * e.g. unity-launcher.exe c:\projects\my-unity-launcher.cfg

## Config
* The config file consists of 2 parts splitted by ```---```
* Empty lines and lines starting with ```#``` gets ignored
* First part (Unity versions) above the ```---```
    * Alternating lines between Version string and path to Unity.exe
    * The versions get matched by prefix
        * only use the version numbers or a prefix of them no ```unity 5.5``` or similar
        * 5.5 matches 5.5.1p4, 5.5.0l1
        * 5.5.1 matches 5.5.1p4 but not 5.5.0l1
* Second part (Project root folders) below the ```---```
    * Absolute paths where the tools should start searching for your Unity projects
```
5.5
C:\Program Files\Unity-5.5\Editor\Unity.exe

5.6
C:\Program Files\Unity-5.6\Editor\Unity.exe

---

C:\Users\hagis\projects1
D:\projects2
```

## Disclaimer
* The code is ugly and will not win an engineering award :). I merely wrote a little tool to get the job done.
* If you have many many projects and deep subfolder structures in the second part of the config the tool can get slow. At the moment there is no caching or whatsoever.
