One of the first things you will need to do when creating a plugin for Paratext is decide what to call it and determine how it will be started from within Paratext. Paratext and the MAF framework it uses access metadata in each plugin to determine this information. This page describes the required and optional attributes a plugin needs to have.

**Note:** *The plugin interface for version 1.0.3 is currently in flux. The API marked as version 1.0.3 could change without notice.*

[TOC]

## AddIn Attribute ##
This attribute is defined in the [System.AddIn](http://msdn.microsoft.com/en-us/library/system.addin.aspx) namespace. [See full documentation](http://msdn.microsoft.com/en-us/library/system.addin.addinattribute.aspx). The name and description should be user-friendly, as they will be used in the UI (particularly in the Plugin Manager).

## QualificationData Attribute ##
This attribute is defined in the [System.AddIn.Pipeline](http://msdn.microsoft.com/en-us/library/system.addin.pipeline.aspx) namespace. [See full documentation](http://msdn.microsoft.com/en-us/library/system.addin.pipeline.qualificationdataattribute.aspx). Paratext recognizes several metadata keys, which can be supplied using this attribute. As a convenience to the plugin developer, there are constants defined for these keys in **AddInSideViews.PluginMetaDataKeys**:

### RunWhen ###

(*from version 1.0*)

*Description*: Indicates when Paratext should run the plugin. This metadata key must be supplied for any plugin to run *automatically* in Paratext.

*Valid Values*: Defined in constants in **AddInSideViews.WhenToRun**

* **ProgramStart**: Run plugin as soon as Paratext plugins are loaded

* **MainFormShown**: Run plugin immediately after Paratext's main window is shown

* **ProgramShutdown**: Run plugin when Paratext's main window is closing

### MenuText ###

(*from version 1.0*)

*Description*: For a plugin that is to be run from a menu added into Paratext, the value of this metadata will be the text to appear on the menu. If this metadata key is supplied, it is not necessary to supply the **RunWhen** key.

*Details*: The value is user-friendly text to be set as the value of the **Text** property of the **ToolStripMenuItem** created for this plugin. Note that by convention, if the text is in a script that distinguishes case, title case should be used. Also, if a plugin will open a window, the menu text should end with "...".

### MenuImagePath ###

(*from version 1.0*)

*Description*: For a plugin that is to be run from a menu added into Paratext, this is the path of the image to display on the menu. *Optional*.

*Details*: The value is the path (relative to Paratext's *plugins* folder) of the image file to use. Since plugins must be installed in a subfolder of Paratext's *plugins* folder, the value will always have at least one path separator character in it. If the path is invalid, cannot be found, or represents a file which is not a valid image, no image will be displayed. If the image is not a 24x24 pixel image, it will be scaled to fit.

### InsertAfterMenuName ###

(*from version 1.0*)

*Description*: For a plugin that is to be run from a menu added into Paratext, this indicates where in the Paratext menu hierarchy this plugin will appear. *Optional, but highly recommended*.

*Details*: The value is the "path" to the menu item after which this plugin's menu item is to be added, where each level in the hierarchy is separated by a vertical bar (|). This is based on the English menu names. For menu items which have ampersands (&) or periods (.) in their names, do not include these characters in the path. Generally, avoid trying to specify the path to the menu item of another plugin, since you cannot know whether other plugins will be installed or control the order in which they are added to Paratext's menu structure. If menu path is invalid or refers to a non-existent menu item, the menu item will be added in a default location (currently following the **Text Converter** menu item in the **Tools** menu).

*Examples*:

* **"Tools|Advanced"** - Menu item will be added to the **Tools** menu below the **Advanced** menu

* **"Window"** - Top-level menu item will be added between the **Window** and **Help** menu.

### EnableWhen ###

(*from version 1.0*)

*Description*: For a plugin that is to be run from a menu added into Paratext, this indicates the conditions under which Paratext should enable the menu item.

*Valid Values*: Defined in constants in **AddInSideViews.WhenToEnable**

* **Always**: Menu always enabled

* **ScriptureProjectActive**: Menu enabled whenever the active child window in the main window is a Scripture project

* **AnyProjectActive**: Menu enabled whenever there is a project open in the main window

* **NonResourceProjectActive**: Menu enabled whenever the active child window in the main window is a non-resource Scripture project

* **ConsultantNoteProjectActive**: Menu enabled whenever the active child window in the main window is a consultant note project

### MultipleInstances ###

(*from version 1.0.1*)

*Description*: Indicates whether a new instance of a plugin should be created if the user attempts to run the plugin again. This only applies to plugins that are started by user interaction.

*Valid Values*: Defined in constants in **AddInSideViews.CreateInstanceRule**

* **Always**: When plugin is requested to run, a new instance will always be created. (This is the default.)

* **ForEachActiveProject**: When plugin is requested to run, a new instance will be created only if there is not already one for the currently active project.

* **Never**: When plugin is requested to run, a new instance will be created only if there is not already one running.
