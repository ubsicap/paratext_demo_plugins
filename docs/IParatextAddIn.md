**IParatextAddin** facilitates the ability for **Paratext** to discover and communicate to a plugin. Every plugin *must* have a class that implements this interface. Metadata is also required to be added to the class implementing this interface for a plugin to function properly (see the [Plugin Metadata Reference](Plugin%20Metadata%20Reference.md) for more information).

# API Reference #

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

### Run

```
#!c#
void Run(IHost host, string activeProjectName);
```
(*from version 1.0*)

Called to execute the add-in.

* **host** An object representing the host (see [IHost](IHost.md))

* **activeProjectName** The currently active project when the plugin is run or null if there is no active project.

### RequestShutdown
        
```
#!c#
void RequestShutdown();
```
(*from version 1.0*)

Called to request the add-in to shut down nicely.

### DataFileKeySpecifications

```
#!c#
Dictionary<string, IPluginDataFileMergeInfo> DataFileKeySpecifications { get; }
```
(*from version 1.0*)

Defines the merge handling for data for which a plugin wants to have special merge-handling during a send/receive conflict. The string is the name of the data identifier used when saving and the merge info defines the  merge handling for that data. (see [IPluginDataFileMergeInfo](IPluginDataFileMergeInfo.md) for more information).

# IParatextAddin2

**IParatextAddin2** contains additions to **IParatextAddin** for version 1.0.1. It derives from **IParatextAddin** so there is no need to base your plugin off of both interfaces.

### Activate

```
#!c#
void Activate(string activeProjectName)
```
(*from version 1.0.1*)

Called to tell an existing (running) plugin that the user tried to run it again. Normally, a plugin should respond by activating itself so the user can see it and be happy.

* **activeProjectName** The currently active project.