# Ight hear me out!

<h2>

This might sound silly but I do hate having that `<app>.runtimeconfig.json` hanging around<br>
because i want the directory to look clean :D

</h2>

thats why I made a starter using .net framework 4.8 **(because its preinstalled on most of the windows)**
and embed the EXE and RUNTIMECONFIG.JSON in it so at runtime this app will extract those files and run it then hide

Here I leave the source code so IF I didn't post the source of this y'all think I was making a malware so here's the<br>
code for you to check that it just extract the embeded exe from `LauncherDL` no funny business.

---
<br><br>

# Always run the `BuildAPP.exe` if you want to automate the build process with this launcher included.

If you want to do it manually then sure here's some steps:

- Build the Launcher DL first. DEBUG and RELEASE for this thing to build without error<br>
or you can build DEBUG then copy the debug and rename it to release.

- Finally build this `SelfLauncher` csproj.

- copy the EXE only from the bin and go to the `Launcher DL` build then remove the ff:
  - uvad.exe
  - uvad.runtimeconfig.json

- paste the EXE on it and done.