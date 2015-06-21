function Get-ScriptDirectory
{
   $Invocation = (Get-Variable MyInvocation -Scope 1).Value
   Split-Path $Invocation.MyCommand.Path
}

# build the solution from scratch
$version = "v4.0.30319"
$sln = Join-Path (Get-ScriptDirectory) ..\src\Glimpse.Unity.sln

. $env:windir\Microsoft.NET\Framework\$version\MSBuild.exe $sln /t:Rebuild /p:Configuration=Release /m /v:q

# package it up

$nuget = ".\NuGet.exe"
$nuspec = Join-Path (Get-ScriptDirectory) .\glimpse.unity.nuspec

. $nuget pack $nuspec


