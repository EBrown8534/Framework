# Evbpc.Framework

This repository is a bulk repository for cloning many functions of `System.Drawing`, `System.Windows` and `System.Windows.Forms` in an XNA-compatible form, as well as other various utilities and objects for performing various tasks.

It also includes utilities for integrating GitHub's Webhook API with your applications, and soon will feature Bitbucket integration.

This repository was originally created for another project of mine, hence the naming.

## Included projects

* `Evbpc.Framework`: contains the root utilities, classes and structures to replicate certain portions of the `System.Drawing` namespace, as well as limited support for certain physics operations, and a small list of additional utilities (for serialization, logging, etc.).
* `Evbpc.Framework.Windows`: contains the additional features required to create `Form` objects within XNA (or other graphics libraries, this project is library agnostic).
* `Evbpc.Framework.Xna`: contains the wrapping of the `Evbpc.Framework` and `Evbpc.Framework.Windows` projects to XNA-compatible formats, as well as other XNA-specific utilities.
* `Evbpc.Framework.Test`: contains the unit tests requried for verifying that any code changes have the desired effects. Some tests may seem unnecessary, but all of them are used to verify that changes to specific classes and structures do not cause undesired consequences.

## What can you do with it

Anyone is free to use this to their own purposes, I only request that if you make substantial changes or improvements you create a pull-request to include them in this repository. (Though you are not required to, this project is under an [MIT License](https://github.com/EBrown8534/Framework/blob/master/LICENSE).)

## How do I use it

This solution requires Visual Studio 2015, XNA 4.0, and .NET 4.5. Detailed setup instructions are below.

## Setting up XNA 4.0

To setup XNA 4.0 with Visual Studio 2015 you should follow the guidelines [in this article](http://rbwhitaker.wikidot.com/setting-up-xna) with the exception of using the [XnaFor2017.ps1](https://github.com/EBrown8534/Framework/blob/master/XnaFor2017.ps1) script provided in this project instead.

If you do not wish to download the script from this repository directly, you may download the script from that article and make the following modification:

Add: 

    $appName = "Visual Studio 2015 Enterprise";
	$pathToExe = "${Env:VS140COMNTOOLS}..\IDE\devenv.exe";
	$installLocation = "${Env:VS140COMNTOOLS}..\IDE\Extensions\Microsoft"
	$extensionCacheLocation = "$home\AppData\Local\Microsoft\VisualStudio\14.0\Extensions";
	$version = "14.0";
	InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

Before:

	Write-Host "Step 4/4: Cleanup";
	Write-Host "  Deleting extracted temporary files.";
	RemoveIfExists("$currentLocation\XNA");
	RemoveIfExists("C:\XNA-temp\");
	RemoveIfExists("C:\xnags_visualstudio.msi");
	
	Write-Host "`r`nInstallation Complete.";

This is confirmed working with Visual Studio 2015 Enterprise, and Visual Studio 2015 Enterprise RC. (To be tested with Visual Studio 2015 Community)

Note: this process also works with Visual Studio 2012 (all versions) and Visual Studio 2013 (all versions). This repository, however, uses features available **only** in C#6.0, which mandates the use of Visual Studio 2015.

In order to install in Visual Studio 2017 Community, one should run the new XnaFor2017.ps1 script, or make the following modification in the same place as the previous:

	$appName = "Visual Studio 2017";
	$pathToExe = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe";
	$installLocation = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\Microsoft"
	$extensionCacheLocation = "$home\AppData\Local\Microsoft\VisualStudio\15.0_55c916b4\Extensions";
	$version = "14.0";
	InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

And then copy `C:\Program Files (x86)\MSBuild\Microsoft\XNA Game Studio` to `C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\Microsoft\XNA Game Studio`.