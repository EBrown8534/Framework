# This script is provided AS-IS with no warranty or guarantees for fitness for any particular use.
# Great care and effort has gone in to making this script work correctly, but it is not guaranteed to
# be without error or limitation. USE AT YOUR OWN RISK.
# Please report any problems you discover with this script.

Function RemoveIfExists($path) {
    if((Test-Path $path) -eq $True) { Remove-Item $path -recurse; }
}

Function RunInstaller($path) {
    Start-Process -FilePath msiexec.exe -ArgumentList /i, $path, /quiet -Wait;
}

Function RunInstaller2([String]$path, [String]$extraOption) {
    Start-Process -FilePath msiexec.exe -ArgumentList /a, $path, /quiet, $extraOption -Wait;
}

Function InstallXna($appName, $pathToExe, $installLocation, $extensionCacheLocation, $version) {
	$vsInstalled = test-path "$pathToExe";
	if($vsInstalled -eq $True) {
		write-host "  $appName is installed on this machine. XNA will be added there.";

		write-host "    Copying files.";
		copy-item $xnaLocation $installLocation -recurse -force;
		
		write-host "    Updating configuration for this version.";
		$content = Get-Content ($installLocation + "\XNA Game Studio 4.0\extension.vsixmanifest");
		$content = $content -replace "Version=`"10.0`">", "Version=`"$version`">`r`n        <Edition>WDExpress</Edition>";
		$content | Out-File ($installLocation + "\XNA Game Studio 4.0\extension.vsixmanifest") -encoding ASCII;
		
		write-host "    Clearing the extensions cache.";
		RemoveIfExists($extensionCacheLocation);
		
		write-host "    Rebuilding the extension cache. This may take a few minutes.";
		Start-Process -FilePath $pathToExe -ArgumentList /setup -Wait
		write-host "    Finished rebuilding cache.";
		write-host "    XNA Game Studio 4.0 is now installed for $appName!";
	}
}

# Don't do anything if Visual Studio is already running.
if((Get-Process "WDExpress" -ErrorAction SilentlyContinue) -or (Get-Process "devenv" -ErrorAction SilentlyContinue)) {
    write-host "Cannot install XNA while a version of Visual Studio is running. Exiting script...";
    return;
}

If (-NOT ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(`
    [Security.Principal.WindowsBuiltInRole] "Administrator"))
{
    Write-Warning "You do not have Administrator rights to run this script!`nPlease re-run this script as an Administrator!"
    Break
}

$currentLocation = (Get-Location).ToString();

Write-Host "`r`n";
Write-Host "Step 1/4: Downloading XNA Installer";

$downloadLocation = ($currentLocation + "\XNAGS40_setup.exe");
if((Test-Path ".\XNAGS40_setup.exe") -eq $False) {
    Write-Host "  Downloading XNA 4.0 Refresh Installer to $downloadLocation. This may take several minutes.";
    $wc = New-Object System.Net.WebClient
    $wc.DownloadFile("http://download.microsoft.com/download/E/C/6/EC68782D-872A-4D58-A8D3-87881995CDD4/XNAGS40_setup.exe", $downloadLocation)
    Write-Host "  Download Complete.";
} else {
    Write-Host "  XNA 4.0 Refresh Installer already downloaded. Skipping download step.";
}
Write-Host "`r`n";
Write-Host "Step 2/4: Running Installers"
Write-Host "  Extracting components from XNA 4.0 Refresh Installer.";
Start-Process -FilePath .\XNAGS40_setup.exe -ArgumentList /extract:XNA, /quiet -Wait;

Write-Host "  Running Redists.msi";
RunInstaller("`"$currentLocation\XNA\redists.msi`"");

Write-Host "  Running XLiveRedist.msi";
RunInstaller("`"C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\Setup\XLiveRedist.msi`"")

Write-Host "  Running xnafx40_redist.msi";
RunInstaller("`"C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\Redist\XNA FX Redist\xnafx40_redist.msi`"")

Write-Host "  Running xnaliveproxy.msi";
RunInstaller("`"C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\Setup\xnaliveproxy.msi`"")

Write-Host "  Running xnags_platform_tools.msi";
RunInstaller("`"C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\Setup\xnags_platform_tools.msi`"")

Write-Host "  Running xnags_shared.msi";
RunInstaller("`"C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\Setup\xnags_shared.msi`"")

Write-Host "  Extracting extension files from xnags_visualstudio.msi";
RunInstaller2 "`"C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\Setup\xnags_visualstudio.msi`"" "TARGETDIR=C:\XNA-temp\ExtractedExtensions\"

Write-Host "  Running arpentry.msi";
RunInstaller("`"$currentLocation\XNA\arpentry.msi`"")

$xnaLocation = ("C:\XNA-temp\ExtractedExtensions\Microsoft Visual Studio 10.0\Common7\IDE\Extensions\Microsoft\XNA Game Studio 4.0");

Write-Host "`r`n";
Write-Host "Step 3/4: Adding Extensions to Installed Versions of Visual Studio";

# The following process is done for:
#   * VS 2012 Professional (or another paid-for version)
#   * VS Express 2012 for Windows Desktop
#   * VS 2013 Professional (or another paid-for version)
#   * VS Express 2013 for Windows Desktop
# 1. Check to see if the program is installed. If it isn't, we won't try to install there.
# 2. If we're going to install there, tell the user.
# 3. Copy the XNA extension to the new location.
# 4. Update the extension's version to the version that we're installing to.
# 5. For express, we need to also add the version name (WDExpress) to the list of supported editions.
# 6. Delete the extensions cache.
# 7. Rebuild the extensions cache.

$appName = "Visual Studio 2012 Pro";
$pathToExe = "${Env:VS110COMNTOOLS}..\IDE\devenv.exe";
$installLocation = "${Env:VS110COMNTOOLS}..\IDE\Extensions\Microsoft";
$extensionCacheLocation = "$home\AppData\Local\Microsoft\VisualStudio\11.0\Extensions";
$version = "11.0";
InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

$appName = "Visual Studio Express 2012 for Windows Desktop";
$pathToExe = "${Env:VS110COMNTOOLS}..\IDE\WDExpress.exe";
$installLocation = "${Env:VS110COMNTOOLS}..\IDE\WDExpressExtensions\Extensions"
$extensionCacheLocation = "$home\AppData\Local\Microsoft\WDExpress\11.0\Extensions";
$version = "11.0";
InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

$appName = "Visual Studio 2013 Pro";
$pathToExe = "${Env:VS120COMNTOOLS}..\IDE\devenv.exe";
$installLocation = "${Env:VS120COMNTOOLS}..\IDE\Extensions\Microsoft";
$extensionCacheLocation = "$home\AppData\Local\Microsoft\VisualStudio\12.0\Extensions";
$version = "12.0";
InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

$appName = "Visual Studio Express 2013 for Windows Desktop";
$pathToExe = "${Env:VS120COMNTOOLS}..\IDE\WDExpress.exe";
$installLocation = "${Env:VS120COMNTOOLS}..\IDE\WDExpressExtensions\Extensions"
$extensionCacheLocation = "$home\AppData\Local\Microsoft\WDExpress\12.0\Extensions";
$version = "12.0";
InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

# The modification below enables XNA 4.0 Refresh on Visual Studio 2015 Enterprise. Changes may need to be made for Visual Studio 2015 Community.

$appName = "Visual Studio 2015 Enterprise";
$pathToExe = "${Env:VS140COMNTOOLS}..\IDE\devenv.exe";
$installLocation = "${Env:VS140COMNTOOLS}..\IDE\Extensions\Microsoft"
$extensionCacheLocation = "$home\AppData\Local\Microsoft\VisualStudio\14.0\Extensions";
$version = "14.0";
InstallXna $appName $pathToExe $installLocation $extensionCacheLocation $version;

Write-Host "Step 4/4: Cleanup";
Write-Host "  Deleting extracted temporary files.";
RemoveIfExists("$currentLocation\XNA");
RemoveIfExists("C:\XNA-temp\");
RemoveIfExists("C:\xnags_visualstudio.msi");

Write-Host "`r`nInstallation Complete.";