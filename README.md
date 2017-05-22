# Delete-Inactive-TS-Ports
Microsoft now have a new Hotfix to resolve Inactive TS Ports issue on Windows Server 2008 R2 RDS Servers.
KB 2655998 Long logon time when you establish an RD session to a Windows Server 2008 R2-based RD Session Host server if Printer Redirection is enabled http://support.microsoft.com/default.aspx?scid=kb;en-US;2655998

There is also a FixIt tool to remove the currently installed inactive ports for downlevel OS. Please use this FixIT now to remove the Inactive TS Ports. http://go.microsoft.com/?linkid=9799054

Please find more information about the hotfix and the FixIT from http://blogs.technet.com/b/askperf/archive/2012/03/06/performance-issues-due-to-inactive-terminal-server-ports.aspx

I would urge all the visitors to now start using this new FixIT only as there would not be any further changes made to the InactiveTSPortList.exe and very soon it would be removed from the downloads.

31 Jan 2012
On popular demand, i created a new version of the tool - DeleteTSPorts.exe which just deletes the Inactive TS Ports.This can be used to create a scheduled task that can run periodically and delete the ports without passing any parameters of waiting on the press any key to exit.


Project Description
The presence of Inactive TS Ports may cause a Windows Server 2003/2003R2/2008/2008R2 RDS system to hang or become sluggish and unresponsive. Printer redirection may also suffer when there are numerous Inactive TS Ports presents in the registry.

System Requirements
.NET Framework 3.0
Administrator rights on the machine.
Windows 2003/2003R2/Windows Server 2008/Windows 2008R2.

Background
We have seen multiple issues where the presence of numerous Inactive TS Ports causes a system to hang or become sluggish and unresponsive. We also see issues with Printer redirection when there are a frequent Inactive TS Ports present in the machine. While troubleshooting OS Performance, RDS Printer redirection and Print spooler hanging scenarios, check the presence of the a large number of keys under - 
HKLM\SYSTEM\CurrentControlSet\Control\DeviceClasses\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}
#TS001
#TS002
#TS003
#TS004
#TS005
…
#TS00n

The key names a little different. For Windows 2003/2008, it is 
HKLM\SYSTEM\CurrentControlSet\Control\DeviceClasses\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}
For 2008R2, it is 
HKLM\SYSTEM\CurrentControlSet\Control\DeviceClasses\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}

For each of these keys, check the Device Parameters subkey and the "Port Description" value.
If it says "Inactive TS Port" then we need to delete the entire root key ie. HKLM\SYSTEM\CurrentControlSet\Control\DeviceClasses\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\#TS001

This is a tedious process if there are hundreds or more of these keys present.
Here is the tool to automate the clean-up process.

Just run the tool with any of these options:
To list all the Inactive TS Ports on the system
InactiveTSPortList /r

To delete all the Inactive TS Ports from the system
InactiveTSPortList /d 

This is an example of a bloated TS registry key -


To clean this we need the InactiveTSPortList.exe


The tool can run in reporting mode to list all the Inactive TS Ports on the machine


To clean up, we need to run it in the Delete mode

