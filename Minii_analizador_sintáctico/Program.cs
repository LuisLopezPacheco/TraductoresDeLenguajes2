using System;
using System.Collections;
using System.Collections.Generic;

namespace Mini_analizador_sintáctico
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexico myLexico = new Lexico();
            string myChain = "hola+mundo";

            Console.WriteLine("Entrada 1: hola+mundo");

            List<Token> myList = myLexico.analyze(myChain);
            Sintactico mySyntactic = new Sintactico(myList);
            Console.WriteLine();
            Console.WriteLine("Simbolos | Tipo | ID");
            foreach (Token aux in mySyntactic.myList)
            {
                Console.WriteLine(aux.GetToken());
            }
            Console.WriteLine("\nEjercicio 1");
            mySyntactic.analyze1();
            myList.Clear();
            mySyntactic.clear();
            Console.ReadLine();
            //********************************************+Ejercicio: 2********************************************+
            Console.Clear();
            Console.WriteLine("Entrada 2: a+b+c+d+e+f");
            myChain = "a+b+c+d+e+f";
            myList = myLexico.analyze(myChain);
            mySyntactic.myList.AddRange(myList);
            foreach (Token aux in mySyntactic.myList)
            {
                Console.WriteLine(aux.GetToken());
            }
            Console.WriteLine("\nEjercicio 1");
            mySyntactic.analyze2();
            Console.ReadLine();
        }
    }
}
