**IMergeLevel** represents one level of the XML file to merge. See [IPluginDataFileMergeInfo](/paratext/paratext-demo-plugins/wiki/IPluginDataFileMergeInfo) for more information.

# API Reference

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

### Root

```
#!c#
string Root { get; }
```
(*from version 1.0*)

[XPath][] expression which matches the root element of a list

### MergeKey

```
#!c#
string MergeKey { get; }
```
(*from version 1.0*)

[XPath][] expression which returns the primary key of list elements which uniquely identifies child elements to be merged.

[XPath]: http://www.w3schools.com/xpath