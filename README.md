# Glimpse.Unity

## Description
This is a plugin for [Glimpse](http://getglimpse.com/) to show [Unity](https://unity.codeplex.com/) registrations.
![Screenshot of Glimpse.Unity](/docs/screenshot.jpg?raw=true "Screenshot")

## Usage
- Add a reference to Glimpse.Unity in your project (available as a [NuGet package](https://www.nuget.org/packages/Glimpse.Unity/): `Install-Package Glimpse.Unity`)
- Call `RegisterInGlimpse()` on your container:

  ```cs
  var container = new UnityContainer();
  // Build the container
  // (...)
  // Register the container in Glimpse
  container.RegisterInGlimpse();
  ```
