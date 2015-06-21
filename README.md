# Glimpse.Unity

## Description
This is a plugin for [Glimpse](http://getglimpse.com/) to show [Unity](https://unity.codeplex.com/) registrations.
![Screenshot of Glimpse.Unity](/docs/screenshot.jpg?raw=true "Screenshot")

## Usage
- Add a reference to the compiled DLL (soon available as a NuGet package)
- Call `RegisterInGlimpse()` on your container:

  ```cs
  var container = new UnityContainer();
  // Build the container
  // (...)
  // Register the container in Glimpse
  container.RegisterInGlimpse();
  ```
