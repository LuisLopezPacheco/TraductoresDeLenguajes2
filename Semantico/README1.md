Análisis Semántcio.

Fase del compilador en la que se comprueba la corrección semántica del programa. Conjunto de subrutinas independientes que pueden ser invocadas por los analizadores 
morfológico y sintáctico  El procesamiento semántico funciona sobre los constituyentes de la oración. Si no existe un paso de análisis sintáctico, el sistema semántico 
debe identificar sus propios constituyentes. Por otro lado, si se realiza un análisis sintáctico, se restringe enormemente el número de constituyentes a considerar por 
el semántico, mucho más complejo y menos fiable. 

Implementación.
Para la creación de esta actividad utilice el código generado en la actividad, pero realice algunas modificaciones, principalmente se pueden notar las modificaciones al 
mostrar el árbol sintáctico, ya que de esta manera fue como conseguir realizar la parte del análisis semántico. Para realizar la parte del análisis semántico fue necesario 
volver a repasar las reglas de la gramática en la tabla, para poder comprender mejor como implementar el análisis semántico.

Ahora adicionalmente si se encuentra algún error sintáctico y el código ingresado es invalido no se mostrará la visualización del árbol sintáctico.

Se crearon nuevos métodos para almacenar e identificar el motivo por el que se ocasione algún error semántico, este método funciona por medio de la identificación de 
las reglas que producen un error semántico.

Además ahora realice cambios en los nodos para que realicen las reducciones en la pila dependiendo del tipo de token que se trate, con esto es más fácil manejar las 
reducciones y también al momento de apilar.

Además ahora añadí nuevas listas para almacenar mejor las reglas y las entradas y salidas al realizar el análisis sintáctico.El resto de métodos utilizados siguen funcionan 
de la misma manera, como el generador de matriz, pero en esta ocasión también intente realizar un método de prueba que también genera la matriz, ahora es posible utilizar 
cualquiera de los dos métodos para generar la matriz y contemplar las reglas de la gramática.

Para demostración del funcionamiento del analizador semántico se ingresará el siguiente código:

int a; int suma( int a, int b){return a+b;}int main(){float a;int b;int c;c = a+b;c = suma(8,9);}

Este código producirá un error semántico al tratar de asignar a c la suma de a más b, ya que a es de tipo flotante y c de tipo entero.
