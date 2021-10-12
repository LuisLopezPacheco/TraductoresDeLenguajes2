﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_Sintanctico
{
	public class Nodo
	{
		public String simbolo;//token
		public Nodo siguiente;
		public String ambito;//
		public char tipoDato;

		public Nodo()
		{
			simbolo = "";
			ambito = "";
			siguiente = null;
		}

		public Nodo(String _ambito, String _simbolo)
		{
			simbolo = _simbolo;
			ambito = _ambito;
			siguiente = null;
		}
		public Nodo(Nodo nodo)
		{
			this.simbolo = nodo.simbolo;
			this.ambito = nodo.ambito;
			this.siguiente = nodo.siguiente;
		}
		virtual public void muestra() { }
	}

	public class NoTerminal : Nodo
	{
		public Nodo nodo;
		public int regla;

		public NoTerminal() { }
		public NoTerminal(int regla)
		{
			this.regla = regla;
		
		}
		public NoTerminal(NoTerminal nt)
		{
			this.nodo = nt.nodo;
			this.regla = nt.regla;
			
		}

	}

	public class Tipo : Nodo
	{
		public Tipo(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Tipo>" + simbolo);
		}
	}
	public class Id : Nodo
	{
		public Id(String _simbolo)
		{
			simbolo = _simbolo;
		}
	}

	public class Constante : Nodo
	{
		public Constante(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Cosntante>" + simbolo);
		}
	}

	public class If : Nodo
	{
		Nodo otro;
		Nodo sentenciaBloque;
		Nodo expresion;
		public If(Stack pila)
		{
			//Sentencia -> if ( Expresion ) SentenciaBloque Otro
			pila.Pop();
			otro = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			sentenciaBloque = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//)
			pila.Pop();
			expresion = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//(
			pila.Pop();
			pila.Pop();//if
			Console.WriteLine("<If>");
		}
	}
	public class While : Nodo
	{
		Nodo expresion;
		Nodo bloque;
		public While(Stack pila)
		{
			//Sentencia ->while ( Expresion ) Bloque
			pila.Pop();
			bloque = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//)
			pila.Pop();
			expresion = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//(
			pila.Pop();
			pila.Pop();//while
			Console.WriteLine("<While>");
		}
	}
	public class Return : Nodo
	{
		Nodo expresion;
		public Return(Stack pila)
		{
			//Sentencia -> return Expresion ;
			pila.Pop();
			pila.Pop();//;
			pila.Pop();
			expresion = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//return
			Console.WriteLine("<Regresa>");
		}
	}


	public class OpSuma : Nodo
	{
		public OpSuma(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Suma>");
		}
	}
	public class OpLogico : Nodo
	{
		public OpLogico(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<OpLogico>");
		}
	}
	public class OpMul : Nodo
	{
		public OpMul(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Multiplicacion>");
		}

	}
	public class OpRelac : Nodo
	{
		public OpRelac(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<OpRelac>");
		}
	}

	public class Programa : Nodo
	{
		public Programa(Stack pila)
		{
			pila.Pop();
			siguiente = ((NoTerminal)pila.Pop()).nodo;
			Console.WriteLine("<Programa>");
		}
	}

	public class DefVar : Nodo
	{
		Nodo listVar;
		Nodo id;
		Nodo tipo;
		public DefVar(Stack pila)
		{//tipo id ListaVar ;
			pila.Pop();
			pila.Pop();//;
			pila.Pop();
			listVar = ((NoTerminal)pila.Pop()).nodo;//ListaVar
			pila.Pop();
			id = (((Nodo)pila.Pop()));//id
			pila.Pop();
			tipo = (((Nodo)pila.Pop()));//tipo
			Console.WriteLine("<Def Var>" + simbolo);
		}
	}
	public class DefFunc : Nodo
	{
		Nodo bloqFunc;
		Nodo parametros;
		Nodo id;
		Nodo tipo;
		public static string varlocal;
		public DefFunc(Stack pila)
		{
			//tipo id ( Parametros ) BloqFunc
			pila.Pop();
			bloqFunc = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//)
			pila.Pop();
			parametros = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//(
			pila.Pop();
			id = ((Nodo)pila.Pop());
			pila.Pop();
			tipo = ((Nodo)pila.Pop());
			Console.WriteLine("<DefFunc>");
		}
	}
	public class Parametros : Nodo
	{
		Nodo tipo;
		Nodo id;
		public Nodo listaParam;
		public Parametros(Stack pila)
		{
			//tipo id ListaParam
			pila.Pop();
			listaParam = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			id = ((Nodo)pila.Pop());
			pila.Pop();
			tipo = (((Nodo)pila.Pop()));
			Console.WriteLine("<Paramatros>");
		}
	}
	public class Asignacion : Nodo
	{
		Nodo id;
		Nodo expresion;
		public Asignacion(Stack pila)
		{
			//Sentencia -> id = Expresion ;
			pila.Pop();
			pila.Pop();//;
			pila.Pop();
			expresion = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//=
			pila.Pop();
			id = (((Nodo)pila.Pop()));
			Console.WriteLine("<Asignacion>" + simbolo);
		}
	}
	public class Expresion : Nodo
	{
		Nodo expresion1;
		Nodo op;
		Nodo expresion2;
		public Nodo listaParam;
		public Expresion(Stack pila)
		{
			//Expresion -> Expresion operacion Expresion
			pila.Pop();
			expresion1 = ((NoTerminal)pila.Pop()).nodo;
			pila.Pop();
			op = (Nodo)pila.Pop();
			pila.Pop();
			expresion2 = ((NoTerminal)pila.Pop()).nodo;
			Console.WriteLine("<Expresion>");
		}
	}
}
