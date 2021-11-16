### Requirements

* **Visual Studio 2008** or later

* **.Net 3.5** or later (**Mono** is currently *not* supported)

* [Paratext](http://paratext.org) version 7.4.0.89 or later

* [Mecurial](http://mercurial.selenic.com) ([TortoiseHg](http://tortoisehg.bitbucket.org) is highly recommended).

### Getting the demo plugin code

* Create a new directory on your machine

* Clone the Hg repository to this new directory using [https://bitbucket.org/paratext/paratext-demo-plugins](https://bitbucket.org/paratext/paratext-demo-plugins) as your source directory

### Setting up the coding environment

* Create a new environment variable (Control Panel > System > Advanced System Settings > Environment Variables) and name it **ParatextInstallDir**. Set the value to the full path to your Paratext installation (usually **C:\Program Files\Paratext 7** or **C:\Program Files (x86)\Paratext 7**). 

* Open the solution file **ParatextDemoPlugins.sln** which should now be located in the root of the repository (i.e. the new directory you created).

* If you are using a version of Visual Studio later than 2008, the projects will upgrade automatically. During this process, Visual Studio changes the framework version. After the upgrade, you will need to open the properties of each demo project you want to build and set the .Net version back to 3.5; otherwise, you will get a run-time error when you try to run the plugins within Paratext.

* If you will be testing your plugins on your development machine using a normal Paratext installation, you need to run Visual Studio as an administrator for the automated post-build copying of files to work. The easiest way to do this is to select the option to run VS as an administrator.

### Getting the projects to build

*Each project in the **ParatextDemoPlugins** solution needs to have the **AddInViews** reference updated to the location of the installed version of **Paratext** on your machine. If you have the **Paratext** source code repository and the **Paratext Demo Plugins** in the same root directory, then this setup is not necessary.*

For each of the projects:

* Remove the reference to **AddInViews**

* Add a new reference and find the **AddInViews.dll** located in the **Pipeline\AddInViews** folder of your **Paratext** install directory (usually **C:\Program Files\Paratext 7** or **C:\Program Files (x86)\Paratext 7**). Set the **CopyLocal** property to **false**.

* At this point you should be able to compile all 4 demo projects.

### Running the demo projects

You can try out a plugin by opening Paratext.

* The “Tip of the Day” plug-in should run automatically.

* To run the “Hello World” plugin: on the **Tools** menu, point to **Advanced**, and then click **Hello World Demo Menu Plugin**.

* To run the “Project Text Editor” plugin: on the **Tools** menu and then click **Project Text Editor**.

* To run the “Chapter Word Cloud” plugin: on the **Tools** menu and then click **Chapter Word Cloud**.