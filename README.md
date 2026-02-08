
Npp.DotNet.Templates
--------------------

[![Current Version]][nuget-org]

.NET SDK project templates for Notepad++ plugin developers


### Getting started

Install the [.NET SDK](https://dotnet.microsoft.com/download), then install the template package:

    dotnet new install Npp.DotNet.Templates

Start a new project by running [`dotnet new`] `<template> --name <your_project_name>`


### Available project templates

| Name                     | Description                                                     |
| :---                     | :---                                                            |
| `npp-plugin`             | Creates a new plugin starter project (without Windows Forms)    |
| `npp-winforms-plugin`    | Creates a new plugin project with Windows Forms integration     |


### Available item templates

| Name                     | Description                                       |
| :---                     | :---                                              |
| `npp-plugin-ini`         | Creates a new INI file manager class (derived from [`Npp.DotNet.Plugin.Extensions.DefaultSettings`]) |


### License

    (c) 2026 Npp.NET Team and Contributors

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

      http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

This README and all other documentation, including images, are distributed under a [CC0 v1.0 Public Domain Dedication].

[`dotnet new`]: https://learn.microsoft.com/dotnet/core/tools/dotnet-new
[`Npp.DotNet.Plugin.Extensions.DefaultSettings`]: https://npp-dotnet.github.io/Npp.DotNet.Plugin/api/Npp.DotNet.Plugin.Extensions.DefaultSettings.html
[Current Version]: https://img.shields.io/nuget/vpre/npp.dotnet.templates?color=blueviolet&logo=nuget
[nuget-org]: https://www.nuget.org/packages/npp.dotnet.templates
[CC0 v1.0 Public Domain Dedication]: https://raw.githubusercontent.com/npp-dotnet/npp.dotnet.plugin/main/LICENSES/CC0-1.0.txt
