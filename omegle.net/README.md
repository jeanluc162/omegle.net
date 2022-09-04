# omegle.net

Revised client for the anonymous chat website [Omegle](https://www.omegle.com/) written in C#. This is an attempt to overhaul my now archived ["Omegle-.NET"-Client](https://github.com/jeanluc162/Omegle-.NET) to achive the following goals:

#### Support for a wide variety of .NET-Versions

I'm planning to support all versions from .NET Framework 4.0 (the latest version still available on Windows XP) to .NET 6.0 (via [.NET-Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)).

Some features (e.g. [ILogger](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging)-Injection) wont be available for older (< 4.6.1) Versions of the .NET-Framework but the core functions will all be implemented.

#### Abstraction

I want to abstract the client fromt the underlying protocol so that users of this library won't have to worry about checking for the connection state before sending a message etc.