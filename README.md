ShaderlabVS
===========

This is a modified fork to feature some additional functionality and support VS2019.
ShaderlabVS is a Visual Studio Plugin for Unity Shaderlab programming.

### Supports files:

* .shader
* .cginc
* .glslinc
* .compute
* .cg
* .hlsl

Features
-----

### Syntax Hightlighting and outlining

![Highlighting](./img/Highlighting.PNG)

### Quickinfo

![QuickInfo](./img/QuickInfo.PNG)

### Code Completion

![CodeCompletion](./img/CodeCompletion.PNG)

### Signature help for CG and Unity built in functions

![SignatureHelp](./img/SignatureHelp.PNG)

### Supports Dark Theme

![dark](./img/dark.png)

Development
-----

### Requirements 

* Visual Studio
* Visual Studio SDK

### How to debug in Visual Studio
1. Download and install Visual Studio SDK
2. Open ShaderlabVS solution
3. Press *F5* to build solution
4. If you want to debug it in Visual Studio, and encounter problems, please make sure the **_Start exteral program_** and **_Command line arguments_** in the **Debug** tab of ShaderlabVS project settings have value as follow:
    1. Set **_Start external program_** to the path of devenv.exe (the Visual Studio main program)
    2. set **_Command line arguments_** to **/rootsuffix Exp**. Below is a screenshot for the settings:

![](./img/DebugSettings.PNG)

### Support Visual Studio Versions:
* Visual Studio 2019
