using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClassLibrary
/********************************************************************************************************
 ***   1. Создать 2 проекта.Первый библиотека классов(Class Library - тип проекта)                    *** 
 ***   в котором будет описан один класс. (2 поля, 2 конструктора, 2 свойства, 2 метода).             ***
 ***   Скомпилировать его.                                                                            ***
 ***   Второй проект - простое консольное приложение.С помощью рефлексии подключить первый проект     ***
 ***   ко второму. Получить список всех элементов. Создать экземпляр класса. (40%)                    ***
 ********************************************************************************************************/
{
    public class Class1
    {
        private string field1;
        private uint field2;

        public byte Property1 { get; set; }
        public string Property2 { get; set; }

        public Class1(byte property1)
        {
            Property1 = property1;
        }
        public Class1(string property2)
        {
            Property2 = property2;
        }

        public void Method1()
        {
            Console.WriteLine($"{Property1}");
        }
        public void Method2()
        {
            Console.WriteLine($"{Property2}");
        }
        static void Main(string[] args)
        {
            Class1 LC1 = new Class1(255);
            Class1 LC2 = new Class1("Hello");
            LC1.Method1();
            LC2.Method2();
        }
    }
}