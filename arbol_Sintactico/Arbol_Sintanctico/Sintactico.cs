using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_Sintanctico
{
    class Sintactico : Lexico
    {

        private Stack objectStack = new();
        private Stack<int> intStack = new();
        private int fila, columna, accion;
        private bool aceptacion;
        String s2 = "";
        StreamReader reglas = new StreamReader(@"file\\GR2slrRulesId.txt");
        StreamReader Tabla = new StreamReader(@"file\\GR2slrTable.txt");
        int[,] _reglas = new int[44, 2];
        int[,] _tabla = new int[84, 40];
        Stack arbol = new Stack();

        public Sintactico()
        {

        }

        public void analyze1()
        {
            Token terminal = new(Token.Type.q20, "$");
            objectStack.Clear();
            objectStack.Push(terminal);
            objectStack.Push(0);
            myList.Add(terminal);
            int index = 0;
            bool regla1 = false;
            bool aceptacion = false;

            int[,] tabla = new int[,] {
                //0,1,2,3
                //id,+,$,E
                {2,0,0,1},
                {0,0,-1,0},
                {0,3,0,0},
                {4,0,0,0},
                {0,0,-2,0}
            };

            while (!aceptacion)
            {
                if (!regla1)
                {

                    fila = (int)objectStack.Peek();
                    columna = myList[index].Type1;
                }
                regla1 = false;
                accion = tabla[fila, columna];
                Console.WriteLine("Columna: " + columna);
                Console.WriteLine("fila: " + fila);
                Console.Write("Contenido en la pila: ");
                showStack();
                Console.WriteLine("\nEntrada: " + myList[index].Chain + " | " + myList[index].Symbol);
                Console.WriteLine("Acción: " + accion);
                if (accion == 0)
                {
                    Console.WriteLine("Valor no aceptado");
                    Console.WriteLine("Cadena rechazada...");
                    break;
                }
                else if (accion == -2)
                {
                    Console.WriteLine("Regla: r1(E-><id>+<id>)");
                    Console.Write("POP: ");
                    for (int i = 0; i < 3; i++)
                    {
                        ShowPop();
                        if (i < 5)
                        {
                            Console.Write(", ");
                        }
                    }
                    var aux = (int)objectStack.Peek();
                    fila = aux;
                    columna = 3;

                    Console.WriteLine();
                    regla1 = true;
                }
                else if (accion == -1)
                {
                    Console.WriteLine("Regla: r0(acept)");
                    aceptacion = true;
                }
                else
                {
                    objectStack.Push((Token)myList[index]);
                    objectStack.Push(accion);
                }

                if (myList[index].Chain != "$")
                {
                    index++;
                }
                Console.ReadLine();
            }
            clear();
        }

        public void analyze2()
        {
            Token terminal = new(Token.Type.q20, "$");
            objectStack.Clear();
            objectStack.Push(terminal);
            objectStack.Push(0);
            myList.Add(terminal);

            int index = 0, abs;
            bool regla = false;
            aceptacion = false;
            int[] idReglas = { 3, 3 };
            int[] lonReglas = { 3, 1 };
            int[,] tabla = new int[,] {
                //0,1,2,3
                //id,+,$,E
                {2,0,0,1},
                {0,0,-1,0},
                {0,3,-3,0},
                {2,0,0,4},
                {0,0,-2,0}
            };
            while (!aceptacion)
            {
                if (!regla)
                {
                    fila = (int)objectStack.Peek();
                    columna = myList[index].Type1;
                }
                regla = false;
                accion = tabla[fila, columna];
                Console.WriteLine("Columna: " + columna);
                Console.WriteLine("fila: " + fila);
                Console.Write("Contenido en la pila: ");
                showStack();
                Console.WriteLine("\nEntrada: " + myList[index].Chain + " | " + myList[index].Symbol);
                Console.WriteLine("Acción: " + accion);

                if (accion > 0)                      //Desplazamiento
                {
                    objectStack.Push(myList[index]);
                    objectStack.Push(accion);
                }
                else if (accion < -1)                //reducción
                {
                    abs = (Math.Abs(accion)) - 2;
                    Console.WriteLine("Regla: r" + ((Math.Abs(accion)) - 1));

                    Console.Write("POP: ");

                    for (int i = 0; i < (lonReglas[abs]); i++)
                    {
                        ShowPop();
                        if (i < ((lonReglas[abs] * 2) - 1))
                        {
                            Console.Write(", ");
                        }
                    }

                    fila = (int)objectStack.Peek();

                    columna = idReglas[abs];
                    Console.WriteLine();
                    regla = true;

                }
                else if (accion == -1)
                {
                    Console.WriteLine("Regla: r0(acept)");
                    aceptacion = true;
                }
                else if (accion == 0)
                {
                    Console.WriteLine("Valor no aceptado");
                    Console.WriteLine("Cadena rechazada...");
                    break;
                }

                if (myList[index].Chain != "$")
                {
                    index++;
                }
                Console.ReadLine();

            }
            clear();
        }


        public void Analyzer()
        {
            matriz();
            Stack<int> pila = new Stack<int>();
            int accion = 0, regla, reduccion, fila, columna, index = 0;
            bool valido = false;
            Token terminal = new(Token.Type.q20, "$");
            myList.Add(terminal);
            myList.Add(new Token());
            Nodo aux;
            NoTerminal nt;
            aceptacion = false;
            //agregamos el cero a la pila
            pila.Push(0);
            arbol.Push(0);
            var token = myList[index];//creo un nodo Token

            do
            {
                fila = pila.Peek();
                columna = token.Type1 + 1;

                accion = _tabla[fila, columna];

                if (accion > 0)
                {
                    //desplazamiento
                    pila.Push(columna);
                    pila.Push(accion);

                    aux = new Nodo("ambito", token.Chain);
                    nt = new();
                    nt.nodo = aux;

                    arbol.Push(new NoTerminal(nt));
                    arbol.Push(accion);


                }
                else if (accion < -1)
                {
                    // regla
                    regla = accion * (-1) - 1;
                    reduccion = _reglas[regla, 1] * 2;//elementos a sacar de la pila

                    aux = creacionArbol(arbol, regla);

                    for (int i = 0; i < reduccion; i++)
                    {
                        pila.Pop();
                    }
                    //agregar al tope de la pila
                    fila = pila.Peek();
                    columna = _reglas[regla, 0] + 1;
                    pila.Push(columna);
                    pila.Push(_tabla[fila, columna]);

                    nt = new NoTerminal(columna);
                    nt.nodo = aux;

                    arbol.Push(new NoTerminal(nt));
                    arbol.Push(_tabla[fila, columna]);

                }
                else if (accion == -1)
                {
                    valido = true;
                    Console.WriteLine("Sintaxis  valida!");
                }
                else
                {
                    //error
                    Console.WriteLine("Sintaxis no valida...");
                    break;
                }

                //siguiente token
                if (myList[index].Chain != "$")
                {
                    index++;
                    token = myList[index];
                }

            } while (!valido);

            String s2 = "";
            arbol.Pop();
            nt = ((NoTerminal)arbol.Peek());
            while (nt.nodo != null)
            {
                s2 += nt.simbolo + "|\n";
                s2 += nt.nodo.simbolo + "_\n";
                nt.nodo = nt.nodo.siguiente;
                Console.WriteLine(s2);
            }

        }

        public void Analyzer1()
        {
            matriz();
            LinkedList<Token> listToken = new(myList);//lista de tokens de entrada
            Stack<int> pila = new Stack<int>();
            int accion, regla, reduccion, fila, columna, i = 0;
            Token terminal = new(Token.Type.q20, "$");
            listToken.AddLast(terminal);
            aceptacion = false;
            Nodo aux;
            NoTerminal nt;
            //inicialización de las pilas
            pila.Push(0);
            arbol.Push(0);
            var token = listToken.First;//creo un nodo Token
            listToken.AddLast(new Token());
            do
            {
                fila = pila.Peek();
                columna = (token.Value.Type1 + 1);
                //Console.WriteLine("fila: " + fila);
                //Console.WriteLine("columna: " + columna);
                accion = _tabla[fila, columna];
                //Console.WriteLine("acción: " + accion);

                if (accion > 0)//desplazamiento
                {

                    pila.Push(columna);
                    pila.Push(accion);

                    aux = new Nodo("ambito", token.Value.Chain);
                    nt = new NoTerminal();
                    nt.nodo = aux;

                    arbol.Push(new NoTerminal(nt));
                    arbol.Push(accion);

                    //siguiente token
                    token = token.Next;
                }
                else if (accion < -1) //reducción
                {
                    //ir a la regla

                    regla = accion * (-1) - 1;
                    reduccion = _reglas[regla, 1] * 2; // cantidad de pops

                    aux = creacionArbol(arbol, regla);

                    for (; 0 < reduccion; reduccion--)
                    {
                        pila.Pop();//hacer pop
                    }
                    //agregar al tope de la pila
                    fila = pila.Peek();
                    columna = _reglas[regla, 0] + 1;
                    pila.Push(columna);
                    pila.Push(_tabla[fila, columna]);

                    nt = new NoTerminal(columna);
                    nt.nodo = aux;

                    arbol.Push(new NoTerminal(nt));
                    arbol.Push(_tabla[fila, columna]);
                }
                else if (accion == -1)
                {
                    aceptacion = true;
                    token = token.Next;
                    Console.WriteLine("Valido!");
                }
                else
                {
                    //error
                    Console.WriteLine("invalido...");
                    break;
                }
                i++;
            } while (token != listToken.Last);


            arbol.Pop();
            nt = ((NoTerminal)arbol.Peek());
            while (nt.nodo != null)
            {
                s2 += nt.simbolo + "|\n";
                s2 += nt.nodo.simbolo + "_\n";
                nt.nodo = nt.nodo.siguiente;
                s2 += 'a';
            }

        }


        Nodo creacionArbol(Stack pila, int regla)
        {
            Nodo nodo = new();
            Nodo aux = new();


            switch (regla)
            {
                case 0: //Programa -> Definiciones
                    Console.WriteLine("<Programa>");
                    nodo = new Programa(pila);
                    break;

                case 3: //Definicion Variable
                    Console.WriteLine("<Definicion> ");
                    break;
                case 4: //Definicion -> DefFuncion
                    Console.WriteLine("<Definicion > ");
                    break;
                case 16://DefLocal -> DefVarriable
                    Console.WriteLine("<DefLocal -> DefVarriable> ");
                    break;
                case 17://DefLocal -> Sentencia
                    Console.WriteLine("<DefLocal -> DefVarriable>");
                    break;
                case 32://Expresion -> LlamadaFuncicon
                    Console.WriteLine("<Expresion -> LlamadaFuncicon>");
                    break;
                case 33://Expresion -> id
                    Console.WriteLine("<Expresion -> id>");
                    break;
                case 34://Expresion -> constante
                    Console.WriteLine("<Expresion -> constante>");
                    break;
                case 36://SentenciaBloque -> Sentencia
                    Console.WriteLine("<SentenciaBloque -> Sentencia>");
                    break;
                case 37://SentenciaBloque -> Bloque
                    Console.WriteLine("<SentenciaBloque -> Bloque>");
                    pila.Pop();
                    nodo = ((NoTerminal)pila.Pop()).nodo;
                    break;

                case 1: //Definiciones -> ''
                    Console.WriteLine("<Definiciones -> ''>");
                    break;
                case 6: //ListaVar -> ''
                    Console.WriteLine("<ListaVar -> ''>");
                    break;
                case 9: //Parametros -> ''
                    Console.WriteLine("<Parametros -> ''>");
                    break;
                case 11://ListaParam -> ''
                    Console.WriteLine("<ListaParam -> ''> ");
                    break;
                case 14://DefLocales -> ''
                    Console.WriteLine("<DefLocales -> ''> ");
                    break;
                case 18://Sentencias -> ''
                    Console.WriteLine("<Sentencias -> ''> ");
                    break;
                case 25://Otro -> ''
                    Console.WriteLine("<Otro -> ''> ");
                    break;
                case 28://Argumentos -> ''
                    Console.WriteLine("<Argumentos -> ''> ");
                    break;
                case 30://ListaArgumentos -> ''
                        //for(int i = 0; i < regla; i++) {
                        //pila.Pop();
                        //}
                    break;

                case 2: //Definiciones -> Definicion Definiciones
                    Console.WriteLine("<Definiciones -> Definicion Definiciones>");
                    break;
                case 15://DefLocales -> DefLocal DefLocales
                    Console.WriteLine("<DefLocales -> DefLocal DefLocales>");
                    break;
                case 19://Sentencias ->Sentencia Sentencias
                    Console.WriteLine("<Sentencias ->Sentencia Sentencias>");
                    break;
                case 29://Argumentos -> Expresion ListaArgumentos
                    Console.WriteLine("<Argumentos -> Expresion ListaArgumentos>");
                    pila.Pop();
                    aux = ((NoTerminal)pila.Pop()).nodo;
                    pila.Pop();
                    nodo = ((NoTerminal)pila.Pop()).nodo;
                    nodo.siguiente = aux;
                    break;

                case 5: //DefVar -> tipo id ListaVar ;
                    Console.WriteLine("<DefVar -> tipo id ListaVar>");
                    nodo = new DefVar(pila);
                    break;

                case 7: //ListaVar -> , id ListaVar
                    Console.WriteLine("<ListaVar -> , id ListaVar>");
                    pila.Pop();
                    aux = (NoTerminal)pila.Pop();
                    pila.Pop();
                    nodo = (((Nodo)pila.Pop()));
                    pila.Pop();
                    pila.Pop();//,
                    nodo.siguiente = aux;
                    break;

                case 8: //DefFunc -> tipo id ( Parametros ) BloqFunc
                    Console.WriteLine("<DefFunc -> tipo id ( Parametros ) BloqFunc>");
                    break;
                    nodo = new DefFunc(pila);
                    break;

                case 10://Parametros -> tipo id ListaParam
                    Console.WriteLine("<Parametros -> tipo id ListaParam>");
                    nodo = new Parametros(pila);
                    break;

                case 12://ListaParam -> , tipo id ListaParam
                    Console.WriteLine("<ListaParam -> , tipo id ListaParam>");
                    nodo = new Parametros(pila);
                    pila.Pop();
                    pila.Pop();//,
                    break;

                case 13://BloqFunc -> { DefLocales }
                    Console.WriteLine("<BloqFunc -> { DefLocales }>");
                    break;
                case 27://Bloque -> { Sentencias }
                    Console.WriteLine("<Bloque -> { Sentencias }>");
                    break;
                case 38://Expresion -> ( Expresion )
                    Console.WriteLine("<Expresion -> ( Expresion )>");
                    pila.Pop();
                    pila.Pop();//)
                    pila.Pop();
                    nodo = ((NoTerminal)pila.Pop()).nodo;
                    pila.Pop();
                    pila.Pop();//)
                    break;

                case 20://Sentencia -> id = Expresion ;
                    Console.WriteLine("<Sentencia -> id = Expresion ;>");
                    nodo = new Asignacion(pila);
                    break;

                case 21://Sentencia -> if ( Expresion ) SentenciaBloque Otro
                    Console.WriteLine("<Sentencia -> if ( Expresion ) SentenciaBloque Otro>");
                    nodo = new If(pila);
                    break;

                case 22://Sentencia ->while ( Expresion ) Bloque
                    Console.WriteLine("<Sentencia ->while ( Expresion ) Bloque>");
                    nodo = new While(pila);
                    break;

                case 23://Sentencia -> return Expresion ;
                    Console.WriteLine("<Sentencia -> return Expresion>");
                    nodo = new Return(pila);
                    break;

                case 24://Sentencia -> LlamadaFunc ;
                    Console.WriteLine("<Sentencia -> LlamadaFunc>");
                    pila.Pop();
                    pila.Pop();//;
                    pila.Pop();
                    nodo = ((NoTerminal)pila.Pop()).nodo;
                    break;

                case 26://Otro -> else SentenciaBloque
                    Console.WriteLine("<Otro -> else SentenciaBloque>");
                    pila.Pop();
                    nodo = ((NoTerminal)pila.Pop()).nodo;
                    pila.Pop();
                    pila.Pop();//else
                    break;

                case 31://ListaArgumentos ->, Expresion ListaArgumentos
                    Console.WriteLine("<ListaArgumentos ->, Expresion ListaArgumentos>");
                    pila.Pop();
                    aux = ((NoTerminal)pila.Pop()).nodo;
                    pila.Pop();
                    nodo = ((NoTerminal)pila.Pop()).nodo;
                    pila.Pop();
                    pila.Pop();//,
                    nodo.siguiente = aux;
                    break;


                case 35://LlamadaFunc -> id ( Argumentos )
                    Console.WriteLine("<LlamadaFunc -> id ( Argumentos )>");
                    pila.Pop();
                    pila.Pop();//)
                    pila.Pop();
                    aux = ((NoTerminal)pila.Pop()).nodo;
                    pila.Pop();
                    pila.Pop();//(
                    pila.Pop();
                    nodo = (((Nodo)pila.Pop()));
                    nodo.siguiente = aux;
                    break;

                case 39://Expresion -> Expresion opSuma Expresion	
                    Console.WriteLine("<Expresion -> Expresion opSuma Expresion>");
                    break;
                case 40://Expresion -> Expresion opLogico Expresion
                    Console.WriteLine("<Expresion -> Expresion opLogico Expresion>");
                    break;
                case 41://Expresion -> Expresion opMul Expresion
                    Console.WriteLine("<Expresion -> Expresion opMul Expresion>");
                    break;
                case 42://Expresion -> Expresion opRelac Expresion
                    Console.WriteLine("<Expresion -> Expresion opRelac Expresion>");

                    nodo = new Expresion(pila);
                    break;
            }
            return nodo;
        }

        public void clear()
        {
            myList.Clear();
            objectStack.Clear();
        }

        public void ShowPop()
        {
            int id = (int)objectStack.Pop();
            Token token = (Token)objectStack.Pop();

            Console.Write(token.Chain + id + " ");
        }
        //Generador de Matriz
        void matriz()
        {
            int i = 0;
            String aux;

            String[] corte = new string[2];
            while ((aux = reglas.ReadLine()) != null)
            {
                corte = aux.Split('\t');
                _reglas[i, 0] = int.Parse(corte[0]);
                _reglas[i++, 1] = int.Parse(corte[1]);
            }

            i = 0;
            corte = new string[40];
            while ((aux = Tabla.ReadLine()) != null)
            {

                corte = aux.Split('\t');
                for (int j = 0; j < 40; j++)
                {
                    _tabla[i, j] = int.Parse(corte[j]);
                }
                i++;
            }

        }

        public void showStack()
        {
            Stack aux = new(objectStack);

            while (aux.Count != 0)
            {
                Token token = (Token)aux.Pop();
                int id = (int)aux.Pop();
                Console.Write(token.Chain + id + " ");
            }

        }
    }
}
