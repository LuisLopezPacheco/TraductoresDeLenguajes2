Funcioamiento

Este software Funciona por medio de 2 clases: Léxico y Token, en Léxico contiene en sus atributos una lista que almacenará todos los Tokens que se obtengan al utilizar el método “analyze”, el cual recibe una cadena y analizará cada uno de sus caracteres, determinando si se encuentras los siguiente Tokens:

q1, // variable

q2,	// Entero

q3, // Real

q4, // Operador de adición +-

q5, // Operador de Multiplicación */

q6, // Operador de asignación = 

q7, // Operador relacional < | > | <= | >= | != | ==

q8, // Operador And  &&

q9, // Operador Or  ||

q10, // Parentesis	()

q11, // llave		{}

q12, // punto, coma 

q13, // if

q14, // while
q15, // return

q16, // else

q17, // int

q18, // float

q19, // Operador Not

q20, // $

q21, // string

q22 // Error

Cada uno de estos devolverá el tipo de token y su id, al obtener el token con el método “getToken”. Este método funciona por medio de un “switch” que asigna a los atributos su ID y tipo de símbolo verificando con el “enum” que se haya recibido desde la clase “Léxico”.
El método “analize” en la clase “Léxico”, emplea un autómata de 9 estados y el estado de error, 
El estado 0 es el inicial aquí se valida todos los símbolos de interés como lo son letras, números, y los símbolos mencionado anteriormente, dependiendo del tamaño de la cadena ingresada se hará otra iteración, y cambiará de estado si es necesario (casos necesarios: números, letras, =, (<,>,!), .
El estado 1: se encarga de revisar todo lo relacionado con letras, llamando a un método adicional que revisa el contenido de la cadena que almacena los símbolos que ya fueron analizados, esto con el fin de encontrar alguna coincidencia con alguna palabra reservada y añadirla a la lista de Tokens.
El estado 2: revisa si el carácter es un número, identifica los valores enteros, si recibe un punto cambia de estado al número 3.
El estado 3: El estado 3: se revisa que se ingrese solamente números, para identificar que sea un valor real, en caso de recibir una letra u otro punto, lo tomará como un error y se dirigirá en la siguiente iteración al estado -1. Si recibe cualquier otro carácter agrega un 0 a la cadena resultante y vuelve al estado cero para seguir verificando el resto de la cadena.
El estado 4: realiza el mismo funcionamiento, pero en este estado no se agregará un 0 adicional a la cadena resultante y al recibir otro tipo de símbolo retrocederá hacía atrás, des incrementando el index.
El estado 5: definirá si se trata de un operador de asignación o un operador racional si en la cadena resultante se encuentra solamente un símbolo de “=”.
El estado 6: revisa los operadores racionales excepto el operador “==” ya que ese fue revisa en el estado anterior.
Es estado 7: revisa el operador And verificando si en la cadena resultante ya se encuentra un valor & y el valor que se este revisando en ese momento sea uno del mismo tipo.
El estado 8: revida de la misma manera que el estado 7 solo que ahora para el operador Or.
El estado 9: se encarga de revisar cuando se recibe un punto en el estado cero, si es así y recibe otro punto lo marcará como error poniendo el estado en 0
El estado -1: se llega a este estado cuando se ingresa un carácter no valido, se pude salir de este estado cuando se encuentre un espacio en la cadena o algún otro carácter que no sea digito, letra, o punto.
isReservedWord: este método retorna un valor enum que dependerá si la cadena que recibe coincide con alguna palabra reservada predefinida, si no coincide con ninguno de las opciones retorna que es un identificador o variable.
Para poder obtener todos los Token se tiene que iterar la lista resultante con una iteración posprueba forech que mostrará todos los tokens de la lista.

