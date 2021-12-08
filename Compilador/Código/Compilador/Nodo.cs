using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{


	
	public class Nodo1
	{
		public String simbolo;//token
		public Nodo1 siguiente;
		public String ambito;//
		public char tipoDato;

		public Nodo1()
		{
			simbolo = "";
			ambito = "";
			siguiente = null;
		}

		public Nodo1(String _ambito, String _simbolo)
		{
			simbolo = _simbolo;
			ambito = _ambito;
			siguiente = null;
		}
		public Nodo1(Nodo1 nodo)
		{
			this.simbolo = nodo.simbolo;
			this.ambito = nodo.ambito;
			this.siguiente = nodo.siguiente;
		}
		virtual public void muestra() { }
	}

	public class NoTerminal1 : Nodo1
	{
		public Nodo1 nodo;
		public int regla;

		public NoTerminal1() { }
		public NoTerminal1(int regla)
		{
			this.regla = regla;

		}
		public NoTerminal1(NoTerminal1 nt)
		{
			this.nodo = nt.nodo;
			this.regla = nt.regla;

		}

	}

	public class Tipo1 : Nodo1
	{
		public Tipo1(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Tipo>" + simbolo);
		}
	}
	public class Id1 : Nodo1
	{
		public Id1(String _simbolo)
		{
			simbolo = _simbolo;
		}
	}

	public class Constante1 : Nodo1
	{
		public Constante1(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Cosntante>" + simbolo);
		}
	}

	public class If1 : Nodo1
	{
		Nodo1 otro;
		Nodo1 sentenciaBloque;
		Nodo1 expresion;
		public If1(Stack pila)
		{
			//Sentencia -> if ( Expresion ) SentenciaBloque Otro
			pila.Pop();
			otro = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			sentenciaBloque = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//)
			pila.Pop();
			expresion = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//(
			pila.Pop();
			pila.Pop();//if
			Console.WriteLine("<If>");
		}
	}
	public class While1 : Nodo1
	{
		Nodo1 expresion;
		Nodo1 bloque;
		public While1(Stack pila)
		{
			//Sentencia ->while ( Expresion ) Bloque
			pila.Pop();
			bloque = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//)
			pila.Pop();
			expresion = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//(
			pila.Pop();
			pila.Pop();//while
			Console.WriteLine("<While>");
		}
	}
	public class Return1 : Nodo1
	{
		Nodo1 expresion;
		public Return1(Stack pila)
		{
			//Sentencia -> return Expresion ;
			pila.Pop();
			pila.Pop();//;
			pila.Pop();
			expresion = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//return
			Console.WriteLine("<Regresa>");
		}
	}


	public class OpSuma1 : Nodo1
	{
		public OpSuma1(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Suma>");
		}
	}
	public class OpLogico1 : Nodo1
	{
		public OpLogico1(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<OpLogico>");
		}
	}
	public class OpMul1 : Nodo1
	{
		public OpMul1(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<Multiplicacion>");
		}

	}
	public class OpRelac1 : Nodo1
	{
		public OpRelac1(String _simbolo)
		{
			simbolo = _simbolo;
			Console.WriteLine("<OpRelac>");
		}
	}

	public class Programa1 : Nodo1
	{
		public Programa1(Stack pila)
		{
			pila.Pop();
			siguiente = ((NoTerminal1)pila.Pop()).nodo;
			Console.WriteLine("<Programa>");
		}
	}

	public class DefVar1 : Nodo1
	{
		Nodo1 listVar;
		Nodo1 id;
		Nodo1 tipo;
		public DefVar1(Stack pila)
		{//tipo id ListaVar ;
			pila.Pop();
			pila.Pop();//;
			pila.Pop();
			listVar = ((NoTerminal1)pila.Pop()).nodo;//ListaVar
			pila.Pop();
			id = (((Nodo1)pila.Pop()));//id
			pila.Pop();
			tipo = (((Nodo1)pila.Pop()));//tipo
			Console.WriteLine("<Def Var>" + simbolo);
		}
	}
	public class DefFunc1 : Nodo1
	{
		Nodo1 bloqFunc;
		Nodo1 parametros;
		Nodo1 id;
		Nodo1 tipo;
		public static string varlocal;
		public DefFunc1(Stack pila)
		{
			//tipo id ( Parametros ) BloqFunc
			pila.Pop();
			bloqFunc = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//)
			pila.Pop();
			parametros = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//(
			pila.Pop();
			id = ((Nodo1)pila.Pop());
			pila.Pop();
			tipo = ((Nodo1)pila.Pop());
			Console.WriteLine("<DefFunc>");
		}
	}
	public class Parametros1 : Nodo1
	{
		Nodo1 tipo;
		Nodo1 id;
		public Nodo1 listaParam;
		public Parametros1(Stack pila)
		{
			//tipo id ListaParam
			pila.Pop();
			listaParam = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			id = ((Nodo1)pila.Pop());
			pila.Pop();
			tipo = (((Nodo1)pila.Pop()));
			Console.WriteLine("<Paramatros>");
		}
	}
	public class Asignacion1 : Nodo1
	{
		Nodo1 id;
		Nodo1 expresion;
		public Asignacion1(Stack pila)
		{
			//Sentencia -> id = Expresion ;
			pila.Pop();
			pila.Pop();//;
			pila.Pop();
			expresion = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			pila.Pop();//=
			pila.Pop();
			id = (((Nodo1)pila.Pop()));
			Console.WriteLine("<Asignacion>" + simbolo);
		}
	}
	public class Expresion1 : Nodo1
	{
		Nodo1 expresion1;
		Nodo1 op;
		Nodo1 expresion2;
		public Nodo1 listaParam;
		public Expresion1(Stack pila)
		{
			//Expresion -> Expresion operacion Expresion
			pila.Pop();
			expresion1 = ((NoTerminal1)pila.Pop()).nodo;
			pila.Pop();
			op = (Nodo1)pila.Pop();
			pila.Pop();
			expresion2 = ((NoTerminal1)pila.Pop()).nodo;
			Console.WriteLine("<Expresion>");
		}
	}
}
