# Evbpc.Framework

This repository is a bulk repository for cloning many functions of `System.Drawing`, `System.Windows` and `System.Windows.Forms` in an XNA-compatible form, as well as other various utilities and objects for performing various tasks.

This repository was originally created for another project of mine, hence the naming.

## Included projects

* `Evbpc.Framework`: contains the root utilities, classes and structures to replicate certain portions of the `System.Drawing` namespace, as well as limited support for certain physics operations, and a small list of additional utilities (for serialization, logging, etc.).
* `Evbpc.Framework.Windows`: contains the additional features required to create `Form` objects within XNA (or other graphics libraries, this project is library agnostic).
* `Evbpc.Framework.Xna`: contains the wrapping of the `Evbpc.Framework` and `Evbpc.Framework.Windows` projects to XNA-compatible formats, as well as other XNA-specific utilities.

## What can you do with it

Anyone is free to use this to their own purposes, I only request that if you make substantial changes you create a pull-request to include them in this repository.

## How do I use it

This solution requires Visual Studio 2015, XNA 4.0, and .NET 4.5. Detailed setup instructions are below.

## Setting up XNA 4.0

To setup XNA 4.0 with Visual Studio 2015 you should follow the guidelines [in this article](http://rbwhitaker.wikidot.com/setting-up-xna) with the exception of using the [XnaFor2015.ps1](https://github.com/EBrown8534/Framework/blob/master/XnaFor2015.ps1) script provided in this project instead.

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

This is confirmed working with Visual Studio 2015 Enterprise RC.