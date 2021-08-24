Funcionamiento:


Este Mini_Generador_Lexico es capaz de identificar letras, números enteros y reales. Además, identifica puntos y espacios, esto es posible ya que revisa carácter por carácter ingresado. Permite ingresar caracteres de cualquier tipo, pero los marcará como inválidos, si no pertenece a un grupo de los anterior mencionados

El programa funciona por medio de la implementación de un autómata finito con 5 estados:

-1- Invalido= Se llega a este estado cuando se ingresa algún carácter invalido, cuando después de un punto no se encuentra algún número, y al ser ingresado cuando después de alguna letra. por ejemplo: "addd.33" esto marcará como invalido

0= Estado inicial.

1- Entero= valor ingresado es un entero.

2- Letras= Se ingresan una serie de letras. 

3- Punto= se encarga de identificar al punto cuando se ingresa un número real.

4- Real= se mostrará como real a los números que se encuentre después del punto.

Al ingresar una cadena vacía desde el comienzo, hará que termine la ejecución del programa. El generador léxico es capaz de encontrar varios tipos de valores, ejemplo:
“aaa3.2ddd22”

a: Letra

a: Letra

a: Letra

Se  obtuvo: aaa Letras

3: Interrumpio la secuecia, vuelve al estado inicial

3: Entero

.: Punto

2: Real

Se  obtuvo: 3.2 Real

d: Interrumpio la secuecia, vuelve al estado inicial

d: Letra

d: Letra

d: Letra

Se  obtuvo: ddd Letras

2: Interrumpio la secuecia, vuelve al estado inicial

2: Entero

2: Entero

Final de la cadena

Se  obtuvo: 22 Entero

