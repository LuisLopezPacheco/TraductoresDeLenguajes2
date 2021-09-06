using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_analizador_sintáctico
{
    class Sintactico
    {
        public List<Token> myList = new List<Token>();
        public Stack<int> myStack = new Stack<int>();
        private int fila, columna, accion;
        private bool aceptacion = false;

        public Sintactico(List<Token> l)
        {
            myList.AddRange(l);
        }

        public void analyze1()
        {
            Token terminal = new Token(Token.Type.q20, "$");
            myStack.Clear();
            myStack.Push(2);
            myStack.Push(0);
            myList.Add(terminal);
            int index=0;
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
                if (!regla1) {
                    fila = myStack.Peek();
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
                    for (int i=0; i<6; i++)
                    {
                        Console.Write(myStack.Pop());
                        if (i < 5)
                        {
                            Console.Write(", ");
                        }
                    }
                    fila = myStack.Peek();
                    columna = 3;
                   
                    Console.WriteLine();
                    regla1 = true;
                }
                else if(accion == -1)
                {
                    Console.WriteLine("Regla: r0(acept)");
                    aceptacion = true; 
                }
                else
                {
                    myStack.Push(myList[index].Type1);
                    myStack.Push(accion);
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
            Token terminal = new Token(Token.Type.q20, "$");
            myStack.Clear();
            myStack.Push(2);
            myStack.Push(0);
            myList.Add(terminal);
            int index = 0;
            bool regla1 = false;
            int[] idReglas = { 2, 2 };
            int[] lonReglas = { 3, 0 };
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
                if (!regla1)
                {
                    fila = myStack.Peek();
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
                else if (accion == -2)       //Regla r1
                {
                    Console.WriteLine("Regla: r1(E→<id> + E)");
                    Console.Write("POP: ");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write(myStack.Pop());
                        if (i < 5)
                        {
                            Console.Write(", ");
                        }
                    }
                    fila = myStack.Peek();
                    columna = 3;

                    Console.WriteLine();
                    regla1 = true;
                }
                else if (accion == -1)  //Regla de aceptacion
                {
                    Console.WriteLine("Regla: r0(acept)");
                    aceptacion = true;
                }
                else if (accion == -3) //Regla r2
                {
                    Console.WriteLine("Regla: r1(E→<id> + E)");
                    Console.Write("POP: ");
                    for (int i = 0; i < 2; i++)
                    {

                        Console.Write(myStack.Pop());
                        if (i < 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    fila = myStack.Peek();
                    columna = 3;
                    Console.WriteLine();
                    regla1 = true;
                }
                else
                {
                    myStack.Push(myList[index].Type1);
                    myStack.Push(accion);
                }

                if (myList[index].Chain != "$")
                {
                    index++;
                }
                Console.ReadLine();

            }
            clear();
        }

        public void clear()
        {
            myList.Clear();
            myStack.Clear();
        }

        public void showStack()
        {
            foreach (var aux in myStack)
            {
                Console.Write(aux + " ");
            }
        }

    }
}
