using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_sintactico_LR_1
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
}
