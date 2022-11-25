using System;
using System.Data;
using System.Reflection;
using System.Security.Claims;

namespace HomeWork8CA
/********************************************************************************************************
 ***   1. Создать 2 проекта.Первый библиотека классов(Class Library - тип проекта)                    *** 
 ***   в котором будет описан один класс. (2 поля, 2 конструктора, 2 свойства, 2 метода).             ***
 ***   Скомпилировать его.                                                                            ***
 ***   Второй проект - простое консольное приложение.С помощью рефлексии подключить первый проект     ***
 ***   ко второму. Получить список всех элементов. Создать экземпляр класса. (40%)                    ***
 ********************************************************************************************************/

{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom(@"F:\Bakunovich_Vitaly\MyCourses\C#\HomeWork\IT_ACD_HW8\exercise1.CA\ClassLibrary.dll");
    
            Console.WriteLine(asm.FullName);
            EmptyCW();
      
            Type[] types = asm.GetTypes();
            foreach (Type t1 in types)
            {
                Info(t1);
                Console.WriteLine($"Full Name: {t1.FullName}, Name: {t1.Name} ");
                EmptyCW();
            }
            try
            {
                string str = "hello";
                Type? TypeClass1 = asm.GetType("ClassLibrary.Class1", true, true);//true -  выдает Exeption если тип не найден; true - игнорирует регистр имени типа
                object activator = Activator.CreateInstance(TypeClass1, str);//создаем экземпляр класса с конструктором 'public Class1(string property2)'
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }
        public static void Info(Type t)
        {
            foreach (MemberInfo member in t.GetMembers(BindingFlags.DeclaredOnly
                        | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($" {member.MemberType} {member.Name}");
            }
        }
        public static void EmptyCW()
        {
            string str = new String('*', 68);
            Console.WriteLine(str);
        }
    }
}
