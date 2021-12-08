using System;
using System.Collections.Generic;
using System.IO;


namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            string myChain = "";
            //Console.WriteLine("Entrada 1: hola+mundo");

            Sintactico Compilador = new();
            //Compilador.analyze(myChain);
            //Console.WriteLine();
            //Console.WriteLine("Simbolos | Tipo | ID");
            //foreach (Token aux in Compilador.myList)
            //{
            //    Console.WriteLine(aux.GetToken());
            //}
            //Console.WriteLine("\nEjercicio 1");

            //Compilador.clear();
            ////Console.ReadLine();
            ////********************************************+Ejercicio: 2********************************************+
            //Console.Clear();
            //Console.WriteLine("Entrada 2: a+b+c+d+e+f");
            //myChain = "a+b+c+d+e+f";
            //Compilador.analyze(myChain);
            //foreach (Token aux in Compilador.myList)
            //{
            //    Console.WriteLine(aux.GetToken());
            //}
            //Console.WriteLine("\nEjercicio 1");
            //Console.Clear();
            //********************************************Analizador Sintactico********************************************
             Console.WriteLine("Ingrese el código a analizar:");

             myChain = Console.ReadLine();
             Compilador.analyze(myChain);
             foreach (Token aux in Compilador.myList)
             {
                 Console.WriteLine(aux.GetToken());
             }
            if (Compilador.Analyzer1())
            {
                Semantico semantico = new();
                semantico.Analizador(myChain);
                List<String> listaSintactic = new(semantico.dameListaSintactico());
                Console.ReadLine();
                Console.Clear();
                foreach (String aux in listaSintactic)
                {
                    Console.WriteLine(aux);
                }
                String arbol = semantico.muestraArbol();
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("ARBOL SINTACTICO");
                Console.WriteLine(arbol);
                Console.ReadLine();

                String ErroresSemanticos = semantico.dameListaErroresSemanticos();
                //Semantico
                Console.WriteLine("SEMANTICO");
                if (ErroresSemanticos.Equals(""))
                {
                    Console.WriteLine("Sin errores Semanticos!");
                    Console.ReadLine();
                    int contadorVariables=0;
                    int contExpresion=0;
                    bool banVariables=false, BanCode=false;
                    Console.WriteLine("Archivo Generado...");
                    foreach(var aux in semantico.arbolSint)
                    {
                        if (aux.Contains("Tipo")  && (aux.Contains("main") == false))
                        {
                            if(banVariables == false)
                            {
                                TextWriter Codigo = new StreamWriter("Codigo.asm");
                                banVariables = true;
                                Codigo.WriteLine("PAGE 60,132");
                                Codigo.WriteLine(".MODEL SMALL");
                                Codigo.WriteLine(".STACK 64");
                                Codigo.WriteLine(".DATA");
                               
                                Codigo.Close();
                            }
                            StreamWriter linea = File.AppendText("Codigo.asm");
                            linea.WriteLine("var"+ contadorVariables++ + " DB ?" );  //Guardar en el archivo
                            Console.WriteLine(aux);
                            linea.Close();
                           
                        }  
                        if(banVariables == true && aux.Contains("Expresión") && contExpresion <= contadorVariables)
                        {
                            if(BanCode == false)
                            {
                                BanCode = true;
                                StreamWriter linea1 = File.AppendText("Codigo.asm");
                                linea1.WriteLine(".CODE");
                                linea1.WriteLine("BEGIN PROC FAR");
                                linea1.WriteLine("MOV AX, @DATA");
                                linea1.WriteLine("MOV DS, AX");
                                linea1.Close();
                            }

                            StreamWriter linea = File.AppendText("Codigo.asm");
                            linea.WriteLine("MOV AH, var"+contExpresion);
                            linea.WriteLine("MOV BH, var"+(contExpresion+1));

                            linea.WriteLine("ADD AH, BH");
                            linea.WriteLine("MOV " + "var" + (contExpresion + 2) + ", AH");

                            linea.Close();
                        }
                    }
                    if(banVariables == true)
                    {
                        StreamWriter linea = File.AppendText("Codigo.asm");
                        linea.WriteLine("INT 21H");
                        linea.WriteLine("BEGIN ENDP"); 
                        linea.WriteLine("END BEGIN");
                        linea.Close();
                    }
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
