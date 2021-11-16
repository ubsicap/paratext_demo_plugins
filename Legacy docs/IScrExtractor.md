Interface for classes that extract can portions of Scripture data as text

# API Reference

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

### IncludeVerseNumbers

```
#!c#
bool IncludeVerseNumbers { set; }
```
(*from version 1.0*)

Sets whether to include verse numbers in the extracted text.

### IncludeNotes

```
#!c#
bool IncludeNotes { set; }
```
(*from version 1.0*)

Sets whether to include footnotes in the extracted text.

### Extract

```
#!c#
string Extract(int startBBBCCCVVV, int endBBBCCCVVV);
```
(*from version 1.0*)

Gets the range of Scripture data indicated by the start and end parameters, which are BBB/CCC/VVV integers using the versification of the project the extractor was created for.

Can throw an **Exception** - Something can go wrong. Plugins beware!