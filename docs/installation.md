---
layout: docs
title: Installation
permalink: /docs/installation/
---
Unfortunatly it is required to install the full profile of the [Micrsoft .NET Framework 4][dotnet] together with the [Microsoft XNA Game Studio 4.0][xna] to run our engine and the included editor. These requirements restrict the usage of the engine basically to Windows platforms (PC and Xbox). Nonetheless we have taken this decision as the XNA Framework provides us already with a certain level of hardware abstraction, good documentation and a healthy community which we feel are valid points for a project with learning purpose. 

## Requirements

Due to the usage of the XNA and the .NET Framework you need to ensure your system matches the following requirements:

* [Microsoft .NET Framework 4][dotnet]
* [Microsoft XNA Game Studio 4.0][xna]
* Windows XP Service Pack 3 (or newer)
* Graphics card with support for Shader Model 1.1 and DirectX 9.0c (minimum)

## Helpful Tools

While there are a variaty of tools out in the wild we found some particulary useful during development. These tools are not required and you might already use other software for these purposes. Just take the list a suggestion or simply skip this section. We might however include generated output from these tools in the documentation if we think it could help to improve the overall understanding.

* **PIX included in the [DirectX SDK][directx]**  
  Allows to analyze, debug and optimize programms that use Direct3D. A very helpful tool to inspect the 3D rendering instructions. 
* **[ILSpy .NET Decompiler][ilspy]**  
  ILSpy is an assembly browser and decompiler for .NET. Somethimes you just want to know how the classes of the frameworks work.
* **[SlimTune Profiler][slimtune]**  
  SlimTune is a free profiler for .NET applications which can help us finding the bottlenecks of our implementation.

[dotnet]: http://www.microsoft.com/en-us/download/details.aspx?id=17718
[xna]: http://www.microsoft.com/en-us/download/details.aspx?id=23714
[directx]: http://www.microsoft.com/en-us/download/details.aspx?id=6812
[ilspy]: http://ilspy.net/
[slimtune]: https://code.google.com/p/slimtune/
