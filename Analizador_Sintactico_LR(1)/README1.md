Introducción.

Para la creación de este programa reutilice el código generado en la actividad anterior, pero ahora realice cambios al momento de apilar, ya que
anteriormente solo se apilaban números entero, y ahora es posible apilar objetos o también números enteros.


Implementación

Siguiendo el algoritmo, lo que realice fue cambiar la pila de enteros por una de objetos, al momento de apilar primero se ingresa el token para poder ser visualizado y después su identificador con base a la tabla (gramática), también con base a esto mismo implemente 2 métodos nuevos:
ShowPop: permite ver el contenido en la pila. Esto es posible utilizando una pila auxiliar con el mismo contenido de la pila de objetos principal, y se realiza pop y se muestra ese token junto a su identificador.
ShowPop: cuando hay una reducción se tenia que multiplicar por 2 para hacer 6 o 2 pop (eliminaciones) dependiendo de la regla que se produjera, ahora con este método ya no es necesario tener que multiplicar, ya que este método se encarga de hacer siempre 2 eliminaciones, lo que equivale a la eliminación de un token y su identificado.
También creé las clases nodo y NoTerminal, que serán utilizadas para la siguiente actividad al crear el árbol que funcionará por medio de lo que produce cada regla de la gramática.
Realice unos cambios a la implementación principal del programa, ya que anteriormente no se comunicaban las clases Léxico y Sintáctico, pero ahora Sintáctico hereda los atributos de la clase Léxico y esto permite tener que utilizar menos listas que almacenan los tokens de la cadena de entrada a analizar, ya que anteriormente la implementación usaba 3 listas adicionales, pero con estos cambios solo se utiliza una (por el momento) que almacena los tokens producidos por la cadena de entrada.
De momento esta actividad no se complicó mucho ya que las particularidades del lenguaje C# me ayudo bastante, pero leyendo los requerimientos para la siguiente actividad tendré que investigar más información de cómo realizar varias partes.
