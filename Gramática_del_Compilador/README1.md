Introducción.

Para la creación de este programa reutilice el código generado en la actividad anterior, pero ahora realice bastantes cambios y añadí más métodos y objetos para lograr 
que funcionará este analizado sintáctico, además de hacer la creación del árbol.

Implementación.

Cree un nuevo método llamado “matriz” que se encarga de leer y generar la tabla que contiene la gramática. Y almacena en un arreglo la tabla de la gramática y en otro lo que 
realiza cada regla, esto lo logra con una lectura por renglón de cada elemento en el archivo.

El método que se encarga de hacer el análisis sintáctico es “analyzer1” en esta ocasión realice varios cambios, el más evidente es la utilización de una lista ligada ya que con 
esta estructura me fue más fácil el manejo de los nodos al crear el árbol, para esto realice una copia de los tokens anteriormente analizados por el analizador léxico, que genera
una lista con los token detectados de la cadena que ingresa el usuario. 

También es importante mencionar que lo primero que realiza el método “analyzer1” es la generación de la matriz con este mismo método (matriz()). Posteriormente se añade el token terminal 
que es el símbolo “$”. También se crean 2 nodos extras, para el manejo de los nodos y los no terminales, y antes de comenzar la iteración preprueba “do while”, que funciona de 
la misma manera como en las actividades anteriores, solo que ahora se hace un desplazamiento diferente ya que utilice como mencione anteriormente una lista ligada. Además de 
utilizar 2 pilas una de enteros y otra pila de objetos que almacena los nodos generados. El método “creacionArbol” por medio de recibir por parámetro una pila y una regla, 
que determina cuantas eliminaciones en la pila de enteros se realizarán, debido a que hay varias reglas que hacen el mismo numero de eliminaciones se agrupan con un “switch” 
que dependiendo de la regla, hará una serie de eliminaciones, y creación de sus respectivos nodos.

En la clase nodo fue necesario crear otros objetos que heredan de la clase Nodo para hacer el correcto manejo del árbol pila, ya que tuve que implementar como clases 
algunas palabras reservadas y en su constructor todos las eliminaciones necesarias que requiere la expresión o el token que se haya ingresado.

También fueron necesarias algunas modificaciones en la clase léxico y token para que funcionará correctamente con la gramática, principalmente realice cambios en los id de 
cada símbolo, y también que fueran detectadas más palabras reversadas y produjeran su respectivo id, para ser posteriormente analizadas con el método analyzer (analizador sintáctico).
Solamente como la implementación la realice en consola y no con interfaz gráfica todos los elementos que sean ingresados por el usuario tienen que ser de forma líneal 
(sin saltos de línea), por ejemplo:
int main() {int a,b,sum; while(a<b){sum = a+b;}} <- es una entrada valida.

Para que funcione el analizador sintáctico primero se ingresa una cadena generada por el usuario y después se realiza el análisis léxico, en está implementación posteriormente 
se muestra cada uno de los token generados y por ultimo se muestra las reglas que fueron utilizadas y si la sintaxis fue valida o no. 
