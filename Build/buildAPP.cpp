// WAG PAKIELAMAN ANG MGA KONTENTO NITONG FILE NA ITO
// DAHIL SINABI KO, NAKIKI-USAP LANG PO AAAAAA
// AKO'Y DI SANAY SA LENGUWAHENG C++ NGUNIT ONTI LANG LANG ANG AKING ALAM.
//
// mga adjik ang umakalang kano ang nag translate lng papuntang tagalog lmao
// sinetch tay' tngina hahahaha
#include <fstream>
#include <string>
#include <iostream>

using namespace std;

int main(int argc, char** argv)
{
    string parameter;

    if(argc >= 2) parameter = argv[1];

    const char* batch_file_name = "a.bat";
    {
        ofstream batch_file( batch_file_name );
        if(parameter == "-r")
        {
            batch_file << 
                "@REM if you see this then wow im impressed for cancelling that build lmao\n"
                "@echo off\n"
                "cd Build\n"
                "echo [101;103m[101;30m================================[0m\n"
                "echo [101;103m[101;30m= Building Launcher DL RELEASE =[0m\n"
                "echo [101;103m[101;30m================================[0m\n"
                "dotnet build BuildLauncherDL.msbuild -c Release \n";
        }
        else
        {
            batch_file << 
                "@REM if you see this then wow im impressed for cancelling that build lmao\n"
                "@echo off\n"
                "cd Build\n"
                "echo [101;103m[101;30m================================[0m\n"
                "echo [101;103m[101;30m= Building Launcher DL DEBUG   =[0m\n"
                "echo [101;103m[101;30m================================[0m\n"
                "echo.\n"
                "echo Add \"-r\" to build it on Release\n"
                "echo.\n"
                "dotnet build BuildLauncherDL.msbuild -c Debug\n";

        }
    };
    
    system("attrib +s +h a.bat");
    system(batch_file_name);
    remove(batch_file_name);
    
};