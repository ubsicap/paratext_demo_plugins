**IPluginDataFileMergeInfo** represents the information required to do a merge of an XML file when two people have changed the file and they do a send/receive. Each merge level represents a list in the XML file that can be merged (e.g. a list of verses that each contain a list of notes). These merge levels are also used to determine if a merge conflict has happened in a list during the merging process.

Consider the following XML file:

```
#!xml#
<?xml version="1.0" encoding="utf-16"?>
<KeyTermRenderingInfo>
  <Info id="king" default="rey">
    <AdditionalRenderings>rey</AdditionalRenderings>
  </Info>
  <Info id="nation, people" default="pueblo">
    <AdditionalRenderings>pueblo</AdditionalRenderings>
    <AdditionalRenderings>pueblocita</AdditionalRenderings>
  </Info>
</KeyTermRenderingInfo>
```
The XML contains two lists. One at the KeyTermRenderingInfo level (multiple Info objects which each have a unique ID) and another at the AdditionalRenderings level (multiple elements all named AdditionalRenderings that have unique text).

To create the merge information for this XML file you would give the following:

```
#!c#
return new PluginDataFileMergeInfo(
    new MergeLevel("/KeyTermRenderingInfo", "@id"),
    new MergeLevel("AdditionalRenderings", "."));
```

# API Reference

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

### MergeLevels

```
#!c#
IList<IMergeLevel> MergeLevels { get; }
```
(*from version 1.0*)

Gets the merge information for each list-level in the file. See [IMergeLevel](IMergeLevel.md)

### RequiresStrictMergeOrder

```
#!c#
bool RequiresStrictMergeOrder { get; }
```
(*from version 1.0*)

Gets whether or not to require lists to be in a certain order or otherwise be considered a change.