# Glimpse.Unity

## Description
A plugin for [Glimpse](http://getglimpse.com/) to show [Unity](https://unity.codeplex.com/) registrations

## Usage
- Add a reference to the compiled DLL (soon available as a NuGet package)
- Call `ActivateGlimpse` on your container:

  ```cs
  var container = new UnityContainer();
  // Build the container
  container.ActivateGlimpse();
  ```
