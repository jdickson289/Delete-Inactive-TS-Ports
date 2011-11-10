//Version update 
//31-10 Checking in code for 2008R2
//11-11 Fixed a few errors of null reference with invalid registry keys
//Added support for Windows 2003/2008. 
//2003 and 2008 -  [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceClasses\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}]
//2008R2 -[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceClasses\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}]



using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace InactiveTSPortList
{
    class Program
    {
        static void Main(string[] args)
        {


            //if (args[1] == "//r" || args[1] == "//R")
            //    Console.WriteLine("Read only mode");
            //if (args[1] == "//f" || args[1] == "//F")
            //    Console.WriteLine("Delete mode");

            // Create a RegistryKey, which will access the HKLM key in the registry of this machine.
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rn = Registry.LocalMachine;
            RegistryKey rn1 = Registry.LocalMachine;
            RegistryKey rp = Registry.LocalMachine;
            RegistryKey rp1 = Registry.LocalMachine;
            RegistryKey rl = Registry.LocalMachine;

            String m;
            String t;
            int l = 0;

            Console.WriteLine("\n*-*-*-*-*-*-* InactiveTSPortList Version 1.0 *-*-*-*-*-*-*");
            Console.WriteLine("*-*-*-*-*-* List and Delete Inactive TS Ports *-*-*-*-*-*\n");

            if (args.Length == 1)
            {
                foreach (string s in args)
                {
                    switch (s)
                    {
                        case "/r": Console.WriteLine("Running in read only mode.");
                            // Print out the subkeys.
                           
                            //Loooking for keys for 2008 R2

                            rk = rk.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rk != null)
                            {
                                PrintKeys(rk); 
                                rk.Close();
                            }
                            else
                            { // Start looking for keys for 2003 and 2008 Server.
                                rk1 = rk1.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                                if (rk1 != null)
                                {
                                    PrintKeys(rk1);
                                    rk1.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Require registry key does not exist. Nothing to display"); break;

                                }
                            }

                                                       
                            //============================

                            Console.WriteLine("............................................................................ ");
                            Console.WriteLine();
                            // === Looking for keys for 2008R2 first ===
                            rn = rn.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rn != null)
                            {
                                Console.WriteLine("Searching for Inactive TS Ports");
                                // Console.WriteLine(" ");
                                String[] prnpm = rn.GetSubKeyNames();
                                if (rn.GetSubKeyNames() != null)
                                {

                                    foreach (String n in prnpm)
                                    {
                                        m = n + "\\Device Parameters";
                                        rl = rn.OpenSubKey(m);

                                        string pal = null;
                                        if (rl != null)
                                        {
                                            pal = rl.GetValue("Port Description").ToString();
                                        }

                                        if ((pal == "Inactive TS Port"))
                                        {
                                            Console.Write(++l); Console.Write(". ");
                                            // Console.Write(n);
                                            Console.WriteLine(n + " is Inactive TS Port");
                                        }


                                    }

                                    if (l == 0)
                                        Console.WriteLine("Found No Inactive TS Port ..............");
                                    }
                                rn.Close();

                            }     // close finding Inactive TS Port 


                                // === Start looking for keys for 2003 and 2008===
                            else
                            {
                                rn1 = rn1.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                                if (rn1 != null)
                                {
                                    Console.WriteLine("Searching for Inactive TS Ports");
                                    // Console.WriteLine(" ");
                                    String[] prnpm = rn1.GetSubKeyNames();
                                    if (rn1.GetSubKeyNames() != null)
                                    {

                                        foreach (String n in prnpm)
                                        {
                                            m = n + "\\Device Parameters";
                                            rl = rn1.OpenSubKey(m);

                                            string pal = null;
                                            if (rl != null)
                                            {
                                                pal = rl.GetValue("Port Description").ToString();
                                            }

                                            if ((pal == "Inactive TS Port"))
                                            {
                                                Console.Write(++l); Console.Write(". ");
                                                // Console.Write(n);
                                                Console.WriteLine(n + " is Inactive TS Port");
                                            }


                                        }

                                        if (l == 0)
                                            Console.WriteLine("Found No Inactive TS Port ..............");
                                       }
                                    rn1.Close();

                                }
                                else Console.WriteLine("Key doenst exist");
                                
                                // close finding Inactive TS Port 

                            }

                            break;

                        case "/R": Console.WriteLine("Running in read only mode.");

                            // Print out the subkeys.

                            //Loooking for keys for 2008 R2

                            rk = rk.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rk != null)
                            {
                                PrintKeys(rk);
                                rk.Close();
                            }
                            else
                            { // Start looking for keys for 2003 and 2008 Server.
                                rk1 = rk1.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                                if (rk1 != null)
                                {
                                    PrintKeys(rk1);
                                    rk1.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Require registry key does not exist. Nothing to display"); break;

                                }
                            }


                            //============================

                            Console.WriteLine("............................................................................ ");
                            Console.WriteLine();
                            // === Looking for keys for 2008R2 first ===
                            rn = rn.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rn != null)
                            {
                                Console.WriteLine("Searching for Inactive TS Ports");
                                // Console.WriteLine(" ");
                                String[] prnpm = rn.GetSubKeyNames();
                                if (rn.GetSubKeyNames() != null)
                                {

                                    foreach (String n in prnpm)
                                    {
                                        m = n + "\\Device Parameters";
                                        rl = rn.OpenSubKey(m);

                                        string pal = null;
                                        if (rl != null)
                                        {
                                            pal = rl.GetValue("Port Description").ToString();
                                        }

                                        if ((pal == "Inactive TS Port"))
                                        {
                                            Console.Write(++l); Console.Write(". ");
                                            // Console.Write(n);
                                            Console.WriteLine(n + " is Inactive TS Port");
                                        }


                                    }

                                    if (l == 0)
                                        Console.WriteLine("Found No Inactive TS Port ..............");
                                }
                                rn.Close();

                            }     // close finding Inactive TS Port 


                                // === Start looking for keys for 2003 and 2008===
                            else
                            {
                                rn1 = rn1.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                                if (rn1 != null)
                                {
                                    Console.WriteLine("Searching for Inactive TS Ports");
                                    // Console.WriteLine(" ");
                                    String[] prnpm = rn1.GetSubKeyNames();
                                    if (rn1.GetSubKeyNames() != null)
                                    {

                                        foreach (String n in prnpm)
                                        {
                                            m = n + "\\Device Parameters";
                                            rl = rn1.OpenSubKey(m);

                                            string pal = null;
                                            if (rl != null)
                                            {
                                                pal = rl.GetValue("Port Description").ToString();
                                            }

                                            if ((pal == "Inactive TS Port"))
                                            {
                                                Console.Write(++l); Console.Write(". ");
                                                // Console.Write(n);
                                                Console.WriteLine(n + " is Inactive TS Port");
                                            }


                                        }

                                        if (l == 0)
                                            Console.WriteLine("Found No Inactive TS Port ..............");
                                    }
                                    rn1.Close();

                                }
                                else Console.WriteLine("Key doenst exist");

                                // close finding Inactive TS Port 

                            }

                            break;

                        case "/d": Console.WriteLine("In DELETE Mode, we delete all the Keys which have Port Description as Inactive TS Port");


                            // To delete the Inactive TS Port registry


                            Console.WriteLine("\nNow Deleting the Inactive TS Ports");
                            //checking for 2008R2
                            rp = rp.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rp != null)
                            { 

                                String[] prnpm = rp.GetSubKeyNames();
                                if (rp.GetSubKeyNames() != null)
                                {
                                    foreach (String n in prnpm)
                                    {
                                        m = n + "\\Device Parameters";
                                        rl = rp.OpenSubKey(m);
                                        string dc = null; //delete candidate 
                                        if (rl != null)
                                        {
                                            dc = rl.GetValue("Port Description").ToString();
                                        }

                                        if ((dc == "Inactive TS Port"))
                                        {
                                            // Console.Write(++l); Console.Write(". ");

                                            try
                                            {
                                                Console.WriteLine(n + " will be deleted");
                                                rp.DeleteSubKeyTree(n);

                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Error while deleting test value: {0}", ex);
                                            }

                                        }

                                    }

                                    if (l == 0)
                                        Console.WriteLine("Found No Inactive TS Port ..............");
                                }
                            rp.Close();
                            }

                            
                        else 
                            { //checking for 2003 and 2008 
                              
                                 rp1 = rp1.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rp1 != null)
                            {

                                String[] prnpm = rp1.GetSubKeyNames();
                                if (rp1.GetSubKeyNames() != null)
                                {
                                    foreach (String n in prnpm)
                                    {
                                        m = n + "\\Device Parameters";
                                        rl = rp1.OpenSubKey(m);
                                        string dc = null; //delete candidate 
                                        if (rl != null)
                                        {
                                            dc = rl.GetValue("Port Description").ToString();
                                        }

                                        if ((dc == "Inactive TS Port"))
                                        {
                                            // Console.Write(++l); Console.Write(". ");

                                            try
                                            {
                                                Console.WriteLine(n + " was deleted");
                                                rp1.DeleteSubKeyTree(n);

                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Error while deleting test value: {0}", ex);
                                            }

                                        }

                                    }

                                    if (l == 0)
                                        Console.WriteLine("Found No Inactive TS Port ..............");
                                }
                            rp1.Close();
                            }

                            else   
                            { 
                                Console.WriteLine("Required registry Key does not exist. Nothing to delete");
                            }

                            }

                   // close delete Inactive TS Port 

                            break;


                        case "/D": Console.WriteLine("In DELETE Mode, we delete all the Keys which have Port Description as Inactive TS Port");


                            // To delete the Inactive TS Port registry

                            //============================
                            // if (l == 0) goto endlabel;

                            //Console.WriteLine("Do you want to delete all of the Inactive TS Ports (y/n)");
                            // ConsoleKeyInfo ch = Console.ReadKey();
                            // if (ch.KeyChar == 'y' || ch.KeyChar == 'Y')
                            // {



                            // To delete the Inactive TS Port registry


                            Console.WriteLine("\nNow Deleting the Inactive TS Ports");
                            //checking for 2008R2
                            rp = rp.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPBUS#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                            if (rp != null)
                            {

                                String[] prnpm = rp.GetSubKeyNames();
                                if (rp.GetSubKeyNames() != null)
                                {
                                    foreach (String n in prnpm)
                                    {
                                        m = n + "\\Device Parameters";
                                        rl = rp.OpenSubKey(m);
                                        string dc = null; //delete candidate 
                                        if (rl != null)
                                        {
                                            dc = rl.GetValue("Port Description").ToString();
                                        }

                                        if ((dc == "Inactive TS Port"))
                                        {
                                            // Console.Write(++l); Console.Write(". ");

                                            try
                                            {
                                                Console.WriteLine(n + " will be deleted");
                                                rp.DeleteSubKeyTree(n);

                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Error while deleting test value: {0}", ex);
                                            }

                                        }

                                    }

                                    if (l == 0)
                                        Console.WriteLine("Found No Inactive TS Port ..............");
                                }
                                rp.Close();
                            }


                            else
                            { //checking for 2003 and 2008 

                                rp1 = rp1.OpenSubKey("SYSTEM\\CURRENTCONTROLSET\\CONTROL\\DeviceClasses\\{28d78fad-5a12-11d1-ae5b-0000f803a8c2}\\##?#Root#RDPDR#0000#{28d78fad-5a12-11d1-ae5b-0000f803a8c2}", true);
                                if (rp1 != null)
                                {

                                    String[] prnpm = rp1.GetSubKeyNames();
                                    if (rp1.GetSubKeyNames() != null)
                                    {
                                        foreach (String n in prnpm)
                                        {
                                            m = n + "\\Device Parameters";
                                            rl = rp1.OpenSubKey(m);
                                            string dc = null; //delete candidate 
                                            if (rl != null)
                                            {
                                                dc = rl.GetValue("Port Description").ToString();
                                            }

                                            if ((dc == "Inactive TS Port"))
                                            {
                                                // Console.Write(++l); Console.Write(". ");

                                                try
                                                {
                                                    Console.WriteLine(n + " was deleted");
                                                    rp1.DeleteSubKeyTree(n);

                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error while deleting test value: {0}", ex);
                                                }

                                            }

                                        }

                                        if (l == 0)
                                            Console.WriteLine("Found No Inactive TS Port ..............");
                                    }
                                    rp1.Close();
                                }

                                else
                                {
                                    Console.WriteLine("Required registry Key does not exist. Nothing to delete");
                                }

                            }

                            // close delete Inactive TS Port 

                            break;


                        case "/?":
                            Console.WriteLine("InactiveTSPortList Version 1.0");
                            Console.WriteLine("Please use the /r switch to list  the Inactive TS Ports present on the system");
                            Console.WriteLine("Please use the /d switch to delete the Inactive TS Ports from the system");
                            Console.WriteLine("Please use /? to display this message");
                            Console.WriteLine("e.g.");
                            Console.WriteLine("\t InactiveTSPortList /r\t Will show all the Inactive TS Ports on the system");
                            Console.WriteLine("\t InactiveTSPortList /d\t Will delete all the Inactive TS Ports from the system");
                            break;

                        default: Console.WriteLine("Unidentified parameter, please try /? to display help message");
                            break;

                    } // end switch


                } // end for each

            } // end main IF

            else
            {
                Console.WriteLine("Too many parameters or no paramerters. Run the tool from the command line OR use /? to display help message");

            }
           
            Console.WriteLine("\nPress a key to exit");
            Console.ReadKey();

        }

        public static void PrintKeys(RegistryKey rkey)
        {

            // Retrieve all the subkeys for the specified key.
            //rkey = rkey.OpenSubKey("PRINT");
            String[] names = rkey.GetSubKeyNames();

            int icount = 0;

            Console.WriteLine("Subkeys of " + rkey.Name);
            Console.WriteLine("-----------------------------------------------");

            // Print the contents of the array to the console.
            foreach (String s in names)
            {
                Console.WriteLine(s);

                // The following code puts a limit on the number
                // of keys displayed.  Comment it out to print the
                // complete list.
                //icount++;
                //if (icount >= 10)
                // break;
            }
        }


    }
}
