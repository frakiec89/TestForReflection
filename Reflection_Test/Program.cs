using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly asm = Assembly.
                LoadFrom(@"C:\Users\Rishat\source\repos\TestForReflection\TestForReflection\bin\Debug\netcoreapp3.1\TestForReflection.dll");
            Console.WriteLine("Вы в программе  для входа в систему");

           
            Console.WriteLine(asm.FullName);
            Console.WriteLine("В сборке вот такие классы");
            // получаем все типы из сборки dll
            List<Type> types = asm.GetTypes().ToList();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }

            Type pr = types[0];
            Type user = types[1];

            // создаем экземпляр класса Program
            object programObj = Activator.CreateInstance(pr);

            // создаем экземпляр класса Program
            FieldInfo[] fi = pr.GetFields(BindingFlags.Instance
                                | BindingFlags.Static
                                | BindingFlags.NonPublic);


            foreach (var item in fi)
            {
                Console.WriteLine(item);
            }





            Console.WriteLine("напишите  \'да\' чтобы зайти  через ввод пароля");

            Console.WriteLine("если  хотите  обойти  ввод  пароля напишите \'РЕФЛЕКСИЯ\'");

            string temp = Console.ReadLine().ToLower();

            if ( temp == "да" )
            {
                // вызов метода  мейн 
                MethodInfo method = pr.GetMethod("Main", BindingFlags.DeclaredOnly
        |       BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
                method.Invoke(programObj, new object[] { new string[] { } });
            }

            if (temp == "рефлексия")
            {
                MethodInfo method = pr.GetMethod("GetStart", BindingFlags.DeclaredOnly |
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
                method.Invoke(programObj, null);
            }

            


        }
    }
}
