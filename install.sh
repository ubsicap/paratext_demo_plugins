#/bin/sh

if [ "$1" = "Debug" ] || [ "$1" == "Release"]
then
 BUILD=$1
else
 echo "usage: install.sh BUILD"
 echo ""
 echo "Where BUILD is Debug or Release"
 exit 1
fi

PLUGINS_DIR=/usr/lib/Paratext/plugins

installPlugin()
{
	NAME=$1
	mkdir -p $PLUGINS_DIR/$NAME
	cp ./$NAME/bin/$BUILD/*.dll $PLUGINS_DIR/$NAME/
} 

installPlugin ChapterWordle
installPlugin ParatextHelloWorldMenuPlugin
installPlugin ParatextTestPlugin
installPlugin ParatextTipOfTheDayPlugin
