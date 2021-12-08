<h2>Compilador Final.</h2>

Reutilice el código elaborado en las clases anteriores, utilizando los mismos métodos y reglas establecidas, solo que ahora si es aceptada por el analizador semántico se generará un archivo de ensamblador con lo que se haya ingresado (código a analizar), convirtiendo de c++ a ensamblador.

Lo primero que se muestra al ejecutar el código es  el resultado de todos los elementos o tokens identificados por el analizador léxico, junto a una serie de reglas generadas por un método que hace un pre análisis sintáctico.<br>
Posterior a esto se mostrará el resultado en la pila, todos los push y pops generados con base a las reglas establecidas (gramática). Depués de esto se mostrarán los elementos identificados y generados en el árbol sintáctico (el cual será de utilidad para poder realizar la función de generador de código). Por último, se muestran los error semánticos (si los hay). En caso de no haberse generado errores semánticos se generará el archivo al equivalente al código, pero en lenguaje ensamblador


Para lograr la funcionalidad del código que pueda generar los archivos, realizo un recorrido al árbol sintáctico en busca de las variables y expresiones para generar una nueva línea en el archivo. Para esto también fue necesario convertir los elementos en el árbol sintáctico a tipo de dato cadena (String) para poder identificar a las variables y expresiones almacenadas, depués ya sea el elemento que se haya identificado se realizará  escritura en el archivo con su equivalente en ensamblador en la mayoría de los casos se utilizarán los registros AH y BH para la realización de las operaciones y después se les asignará  a las variables si así se definió en el código que se ingreso .

También si se generará el archivo en ensamblador (si es aceptada la gramática) genero unas cabeceras en el archivo, haciendo que el archivo se establezca en las páginas 60, 132 y lo siguiente: <br>
.MODEL SMALL    ; Modelo de memoria small, habilita dos segmentos de 64 KB, uno para Datos y otro para Código<br>
.STACK 64 ;Definir el segmento de la pila <br>
.DATA ;Definir el segmento de datos (donde se almacenan las variables <br>
Y en la parte final también se agrega a todos los archivos lo siguiente: <br>
Interrupción  21h función 4ch para terminar el programa. <br> 
END BEGIN   ;Contiene la dirección de arranque, la etiqueta indica donde debe comenzar la ejecución del programa <br>

Para poder ejecutar los archivos será necesario contar con un emulador, En esta caso yo utilice el emulador emu8086 para poder ejecutar el archivo con el código generado


<h2> Link video: </h2>
<a href = "https://drive.google.com/file/d/1KV-V5ysOY6oKhLB2xqSnE8RVgLcAnj9g/view?usp=sharing"><p>Video.</p>
