#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO.Discovery](index#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery')
## SteamFolderLocator Class
Gog implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator')
```csharp
public class SteamFolderLocator :
OpenConstructionSet.IO.Discovery.IInstallationLocator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SteamFolderLocator  

Implements [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator')  

| Properties | |
| :--- | :--- |
| [Default](j3tWfj0SgqFz+7H2cdKftA 'OpenConstructionSet.IO.Discovery.SteamFolderLocator.Default') | Lazy initiated singlton for when DI is not being used<br/> |
| [Id](pA5tZAI+kJ7vtbmsHLOB7w 'OpenConstructionSet.IO.Discovery.SteamFolderLocator.Id') | The unique identifier for this locator.<br/> |

| Methods | |
| :--- | :--- |
| [TryFind(LocatedFolders)](gyLTUlaXI0FYEkTq671XGA 'OpenConstructionSet.IO.Discovery.SteamFolderLocator.TryFind(OpenConstructionSet.IO.LocatedFolders)') | Attempt to find an installation.<br/> |