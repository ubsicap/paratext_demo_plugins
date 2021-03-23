Interface for key term information retrieved from Paratext (See [IHost.GetFactoryKeyTerms](/paratext/paratext-demo-plugins/wiki/IHost#markdown-header-getfactorykeyterms), and [IHost.GetProjectKeyTerms](/paratext/paratext-demo-plugins/wiki/IHost#markdown-header-getprojectkeyterms))

# API Reference

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

### Term

```
#!c#
string Term { get; }
```
(*from version 1.0*)

Gets the term's English gloss.

### Id

```
#!c#
string Id{ get; }
```
(*from version 1.0*)

Gets the term's internal ID.

### BcvOccurences

```
#!c#
IList<int> BcvOccurences { get; }
```
(*from version 1.0*)

Gets the references of all occurences of this key term as integers in the form BBBCCCVVV.
