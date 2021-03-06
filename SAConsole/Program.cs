﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SAConsole
{
    class Program
    {
        static string Prompt = "SAC> ";
        

        static void Main(string[] args)
        {
            string line = string.Empty;
            Type ts = typeof(SymbolicAlgebra.SymbolicVariable);

            var lib_ver = (AssemblyFileVersionAttribute)ts.Assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0];

            string copyright = $@"Symbolic Algebra Console
Copyright 2012-{DateTime.Now.Year} at Lost Particles.
";

            copyright += "\nVersion " + lib_ver.Version + @"
All Rights Reserved for Ahmed Sadek the Auther of the library.

Ahmed.Sadek@LostParticles.net
-----------------------------
Type :Q  to Quit

SA> x+x   will produce 2*x
    '|' Differentiation Operator

SA> (x^2+2*x)|x   will produce  2*x+x

Enjoy
";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(copyright);

            while (line.ToUpperInvariant() != ":Q")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Prompt);
                line = Console.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    if (line.ToUpperInvariant() == ":Q") break;

                    try
                    {
                        var result = SymbolicAlgebra.SymbolicVariable.Parse(line);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("     " + result);
                    }
                    catch(SymbolicAlgebra.SymbolicException se)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(se.Message);
                    }
                }
                else
                {
                    line = string.Empty;
                }
                

            }

        }
    }
}
