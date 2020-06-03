**IHost** facilitates the ability of a plugin to talk to **Paratext**.

# API Reference #

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

### ApplicationName

```
#!c#
string ApplicationName { get; }
```
(*from version 1.0*)

Gets the host application name (Always **'Paratext'**).

### ApplicationVersion

```
#!c#
string ApplicationVersion { get; }
```
(*from version 1.0*)

Gets the version of the host application

### UserName

```
#!c#
string UserName { get; }
```
(*from version 1.0*)

Gets the name of the current user

### GetProjectFont

```
#!c#
Font GetProjectFont(string projectName);
```
(*from version 1.0*)

Gets the font used by a project.

### GetProjectLanguageId

```
#!c#
string GetProjectLanguageId(string projectName, string operation);
```
(*from version 1.0*)

Gets the language ID for a project. Operation is used to tell the user what operation they can not do without the language ID.

### GetProjectRtoL

```
#!c#
bool GetProjectRtoL(string projectName);
```
(*from version 1.0*)

Gets whether a project language is displayed right-to-left.

### GetProjectVersificationName

```
#!c#
string GetProjectVersificationName(string projectName);
```
(*from version 1.0*)

Gets the name of the versification in use by the given project.

### GetCurrentRef

```
#!c#
int GetCurrentRef(string versificationName);
```
(*from version 1.0*)

Gets the current Scripture reference of the Paratext main window. The returned value is the BBBCCCVVV value of the current reference in the specified versification.

### GetCssStylesheet

```
#!c#
string GetCssStylesheet(string projectName);
```
(*from version 1.0*)

Gets the cascading stylesheet for the requested project.

### LookUpKeyTerm

```
#!c#
void LookUpKeyTerm(string projectName, IList<string> terms);
```
(*from version 1.0*)

Shows a key term in the Biblical Terms tool. It will show the first term that is available in the specified list of terms and fallback to the first term in the Biblical Terms list if none are found.

### GetScriptureExtractor

```
#!c#
IScrExtractor GetScriptureExtractor(string projectName, ExtractorType type);
```
(*from version 1.0*)

Gets an extractor from which Scripture data can be requested.

### GetLastChapter

```
#!c#
int GetLastChapter(int bookNum, string vrsName);
```
(*from version 1.0*)

Gets the last chapter for the specified book in the specified versification

### GetLastVerse

```
#!c#
int GetLastVerse(int bookNum, int chapterNum, string vrsName);
```
(*from version 1.0*)

Gets the last verse for the specified chapter of the specified book in the specified versification

### ChangeVersification

```
#!c#
int ChangeVersification(int reference, string vrsSourceName, string vrsDestName);
```
(*from version 1.0*)

Converts the specified Scripture reference from the specified source versification to the specified destination versification.

### PutPlugInData

```
#!c#
bool PutPlugInData(IParatextAddIn plugin, string projectName, string dataIdentifier, string data);
```
(*from version 1.0*)

Saves plugin data for a project for Send/Receive purposes. (see [IParatextAddIn][])

### GetPlugInData

```
#!c#
string GetPlugInData(IParatextAddIn plugin, string projectName, string dataIdentifier);
```
(*from version 1.0*)

Retrieves plugin data that was previously saved using **PutPlugInData**. (see [IParatextAddIn][])

### GetPlugInDataLastModifiedTime

```
#!c#
DateTime GetPlugInDataLastModifiedTime(IParatextAddIn plugin, string projectName, string dataIdentifier);
```
(*from version 1.0*)

Gets the date/time in coordinated universal time (UTC) when the plugin data was last modified. Note that this might be different from the time any given user last put the data, since a subsequent merge might result in a new modified time. (see [IParatextAddIn][])

### WriteLineToLog

```
#!c#
void WriteLineToLog(IParatextAddIn plugin, string line);
```
(*from version 1.0*)

Writes the given line to the hosts log file (tagged with the plugin's path to identify the source of the logged info. (see [IParatextAddIn][])

### GetFigurePath

```
#!c#
string GetFigurePath(string projectName, bool local);
```
(*from version 1.0*)

Gets the absolute path to the figures for the specified project. (Location is not guaranteed to exist.)

* **projectName** The name of the project whose figures to get

* **local** True to get the local (not synchronized via send/receive) store, false to get the the synchronized store.

### GetProjectKeyboard

```
#!c#
string GetProjectKeyboard(string projectName);
```
(*from version 1.0*)

Gets the default keyboard for the given project, null if there is no keyboard for the given project, or the system default keyboard if **projectName** is null.

### GetProjectKeyTermListType

```
#!c#
string GetProjectKeyTermListType(string projectName);
```
(*from version 1.0*)

Gets the type of the biblical terms list associated with the given project. (This is a string-representation of an enumeration inside Paratext - not to be displayed in the user-interface)

### GetKeyTermListName

```
#!c#
string GetKeyTermListName(string listTypeName, string projectName);
```
(*from version 1.0*)

Gets the user-friendly name (in the locale that Paratext is currently displaying) of the biblical terms list of the given type.

* **listTypeName** List type name (as returned by **GetProjectKeyTermListType**)

* **projectName** Project name (only needed for non-factory lists, specifically to deal with the situation where a Project list is in use)

### GetFactoryKeyTerms

```
#!c#
IList<IKeyTerm> GetFactoryKeyTerms(string listTypeName, string glossLanguageId);
```
(*from version 1.0*)

Gets the key terms and occurrences for the built-in list having the given name. (see [IKeyTerm][])

* **listTypeName** Used to determine which list of terms will be returned

* **glossLanguageId** ISO 639-3 language code with optional RFC 5646 subtags to identify the language in which term glosses are to be returned (will fall back to English (en) if localization in requested language is not available).

### GetFactoryKeyTerms

```
#!c#
IList<IKeyTerm> GetFactoryKeyTerms(string listTypeName, string glossLangId, int firstBCV, int lastBCV);
```
(*from version 1.0*)

Gets the key terms and occurrences for the built-in list having the given name, limited to terms that occur in the specified verse range. (see [IKeyTerm][])

* **listTypeName** Used to determine which list of terms will be returned

* **glossLangId** ISO 639-3 language code with optional RFC 5646 subtags to identify the language in which term glosses are to be returned (will fall back to English (en) if localization in requested language is not available).

* **firstBCV** First verse of range of occurences to include

* **lastBCV** Last verse of range of occurences to include

### GetProjectKeyTerms

```
#!c#
IList<IKeyTerm> GetProjectKeyTerms(string projectName, string glossLanguageId);
```
(*from version 1.0*)

Gets the key terms and occurrences for a project. (see [IKeyTerm][])

* **projectName** Used to determine which list of terms will be returned

* **glossLanguageId** ISO 639-3 language code with optional RFC 5646 subtags to identify the language in which term glosses are to be returned (will fall back to English (en) if localization in requested language is not available).

### GetProjectTermRenderings

```
#!c#
IList<string> GetProjectTermRenderings(string projectName, string termId, bool guessIfNotRendered);
```
(*from version 1.0*)

Gets the vernacular renderings from the project for the requested term. The most frequently occurring rendering will be first.

* **projectName** Used to determine what the renderings are

* **termId** The ID of the key term whose renderings are needed

* **guessIfNotRendered** If true and there are no (guessed or approved) renderings Paratext will use the guessing logic to try to find some renderings. These guessed renderings will not be added to the ones Paratext persists. This might take a while.

### GetTermOccurrences

```
#!c#
IList<int> GetTermOccurrences(string listTypeName, string projectName, string termId);
```
(*from version 1.0*)

Gets the occurrences of the requested term (as BBBCCCVVV references)

* **listTypeName** The name of the biblical terms list in which the term is found

* **projectName** Project name (only needed for non-factory lists, specifically to deal with the situation where a Project list is in use)

* **termId** The ID of the key term whose occurrences are needed

### GetApplicationSetting

```
#!c#
string GetApplicationSetting(string settingName);
```
(*from version 1.0.2*)

Gets an application (system or user) setting. (If the setting is not a string, the value returned will be the result of calling ToString(), so you'll have to know what data type it was to be able to interpret it properly.)

* **settingName** The name of the desired setting. Hint: If you don't have access to Paratext source code, and you want to know how to magically know what settings exist, try looking at a user's config file or decompile the Paratext DLL to find the desired setting

### GetProjectSetting

```
#!c#
string GetProjectSetting(string projectName, sstring settingName);
```
(*from version 1.0.2*)

Gets a project setting (i.e., the kinds of settings stored in a project's SSF file. Returns an empty string if a non-existent setting is requested, or null if a non-existent or bogus project name is supplied or if settingName is null.

* **projectName** Project name, used to determine which project's settings to get

* **settingName** The name of the desired setting. Hint: Look in the SSF file to see what settings are stored.

[IKeyTerm:](IKeyTerm.md)
[IParatextAddIn:](IParatextAddIn.md)