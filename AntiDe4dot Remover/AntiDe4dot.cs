using System;
using dnlib.DotNet;

namespace AntiDe4dot_Remover
{
    class AntiDe4dot
    {
        public static void Execute (ModuleDefMD module)
        {
            for (int i = 0; i < module.Types.Count; i++)
            {
                TypeDef type = module.Types[i];
                bool hasInterfaces = type.HasInterfaces;
                if (hasInterfaces)
                {
                    for (int j = 0; j < type.Interfaces.Count; j++)
                    {
                        bool flag = type.Interfaces[j].Interface.Name.Contains(type.Name) || type.Name.Contains(type.Interfaces[j].Interface.Name);
                        if (flag)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Detected AntiDe4dot in type {0}", type.Name);
                            module.Types.RemoveAt(i);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[+] Removed AntiDe4dot in type {0}", type.Name);
                        }
                    }
                }
            }
        }
        
    }
}

