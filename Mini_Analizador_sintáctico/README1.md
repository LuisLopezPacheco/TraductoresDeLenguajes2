Introducción

Utilice el analizador léxico elaborado la actividad anterior, me fue de gran ayuda debido a que ya guardaba varios atributos de cada token, con esto en esta práctica al momento de comparar con lo que produce cada símbolo y apilarlo, me fue útil para esa parte.

Funcionamiento

Primero se realiza el análisis léxico a cada token resultante en la cadena ingresada, almacenando cada token en una lista, después esa lista se copia cada elemento a el objeto analizador sintáctico.

Cree un método para cada ejercicio (1,2), para ambos me base en la información proporcionada por el profesor, su funcionamiento es por medio de una tabla que indica que los símbolos aceptados, junto a un identificador de ese símbolo, además de una serie de reglas, que son la gramática. También se necesita una pila que almacena un identificador del símbolo y un identificador de la acción realizada un paso anterior.
Debido a que en mi analizador léxico ya se obtiene todos los identificadores de cada token cambio un poco la implementación con respecto al ejemplo proporcionado por el profesor. 

En la ejecución del programa se muestra primero el resultado del análisis léxico de la cadena ingresada, después se mostrará paso por paso el análisis sintáctico de la cadena (para continuar es necesario presionar enter) así es posible visualizar cada iteración del análisis de la cadena ingresada, y poder definir si es aceptada o no.
