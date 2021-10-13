using System;
using System.Collections.Generic;

namespace Analizador_Semantico
{
    class Program
    {
        static void Main(string[] args)
        {
            string myChain = "";
            //Console.WriteLine("Entrada 1: hola+mundo");

            Sintactico mySyntactic = new();
            //mySyntactic.analyze(myChain);
            //Console.WriteLine();
            //Console.WriteLine("Simbolos | Tipo | ID");
            //foreach (Token aux in mySyntactic.myList)
            //{
            //    Console.WriteLine(aux.GetToken());
            //}
            //Console.WriteLine("\nEjercicio 1");

            //mySyntactic.clear();
            ////Console.ReadLine();
            ////********************************************+Ejercicio: 2********************************************+
            //Console.Clear();
            //Console.WriteLine("Entrada 2: a+b+c+d+e+f");
            //myChain = "a+b+c+d+e+f";
            //mySyntactic.analyze(myChain);
            //foreach (Token aux in mySyntactic.myList)
            //{
            //    Console.WriteLine(aux.GetToken());
            //}
            //Console.WriteLine("\nEjercicio 1");
            //Console.Clear();
            //********************************************Analizador Sintactico********************************************
             Console.WriteLine("Ingrese el código a analizar:");

             myChain = Console.ReadLine();
             mySyntactic.analyze(myChain);
             foreach (Token aux in mySyntactic.myList)
             {
                 Console.WriteLine(aux.GetToken());
             }
            if (mySyntactic.Analyzer1())
            {
                Semantico semantico = new();
                semantico.Analizador(myChain);
                List<String> listaSintactic = new(semantico.dameListaSintactico());
                String arbol = semantico.muestraArbol();
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("ARBOL SINTACTICO");
                Console.WriteLine(arbol);


                String ErroresSemanticos = semantico.dameListaErroresSemanticos();
                //Semantico
                Console.WriteLine("SEMANTICO");
                if (ErroresSemanticos.Equals(""))
                {
                    Console.WriteLine("Sin errores Semanticos!");
                }
                else
                {
                    Console.WriteLine(ErroresSemanticos);
                }
            }
            else
            {
                Console.WriteLine("");
            }
            
            
            

            Console.ReadLine();

        }
    }
}
