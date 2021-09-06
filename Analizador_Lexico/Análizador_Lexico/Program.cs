using System;
using System.Collections.Generic;


namespace Análizador_Lexico
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexico myLexico = new Lexico();

            string myChain;
            while (true) {
                Console.Clear();
                Console.WriteLine("Ingrese la cadena (para salir ingrese: ___):");
                myChain = Console.ReadLine();
                if (Equals(myChain,"___"))
                {
                    break;
                }
                List<Token> myList = myLexico.analyze(myChain);

                Console.WriteLine();
                Console.WriteLine("Simbolos | Tipo | ID");
                foreach (Token aux in myList)
                {
                    Console.WriteLine(aux.GetToken());
                }
                myList.Clear();
                Console.ReadLine();
            }
        }
    }
}
