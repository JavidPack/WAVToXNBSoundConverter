# WAVToXNBSoundConverter
Convers WAV files to XNB sound files. A tool for modding XNA games. This tool was made for Terraria modding in mind, since previously the only way to convert sound files to xnb was to install XNA Game Studios and XNA seems to be no longer supported. Support for other applications is assumed to work.

# Instructions
Running program without arguments will convert all .wav files to .xnb files. Run with arguments to specify files to convert (drag and drop on executable in windows explorer to convert)

# Sample Usage -- Terraria
Produce/Procure a desired wav file for use. Make sure the wav file is PCM format. Drag and drop on executable to convert and a new xnb file will be created. Copy this file into the Terraria sounds folder, taking care to rename the origional xnb file to something else and renaming the recently converted xnb file to the other files origional name. The sound should now play in game whenever the origional sound should have played.

# XNB file format
The XNB file format is detailed in the document from microsoft reposted here in this repository. Further improvements to this project can be implemented by referencing the documentation.