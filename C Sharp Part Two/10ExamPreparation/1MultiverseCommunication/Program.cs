// Just one trick ;) try comment !!! No more jockers :P

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

class MultiverseCommunication
{

    public static string[] codes = new string[] { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };


    static void Main()
    {
        string str = "";
        Queue<int> queue = new Queue<int>();
        string input = Console.ReadLine();

        //var appDomain = Thread.GetDomain();
        //var assemblyName = new AssemblyName("MyAssembly");
        //var assemblyBuilder = appDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        //var moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
        //var typeBuilder = moduleBuilder.DefineType(input, TypeAttributes.Class, typeof(Exception));
        //var exceptionType = typeBuilder.CreateType();
        //var exception = (Exception)Activator.CreateInstance(exceptionType);
        //throw exception;

        for (int i = 0; i < input.Length; i++)
        {

            if ((input[i] >= 'A' && input[i] <= 'Z') || input[i] == '-') str += input[i];
            if (str.Length == 3)
            {
                for (int i2 = 0; i2 < 13; i2++)
                {
                    if (str == codes[i2])
                    {
                        queue.Enqueue(i2);

                        break;
                    }

                }
                str = "";
            }
        }

        long output = 0;
        do
        {
            output = output * 13 + queue.Dequeue();
        } while (queue.Count != 0);

        Console.WriteLine(output);
    }
}