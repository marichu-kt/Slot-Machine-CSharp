# Máquina Tragaperras  - Proyecto en C# 🎰🎲🪙

¡Bienvenido al repositorio de la Máquina Tragaperras! ♠️ ♣️ ♥️ ♦️

![Icono de C#](/Images/img-1.jpeg)

## DESCRIPCIÓN 📄
Este un proyecto implica crear una aplicación de consola para simular una máquina tragaperras. Los jugadores pueden girar los rodillos y ganar alineando símbolos específicos. El programa ofrece opciones para jugar, ver premios y cargar nuevos premios desde un archivo CSV. Ademas se enfatiza el uso de abstracción, encapsulación, herencia y polimorfismo, así como una sólida validación de entrada y un código bien estructurado.

## INTEGRANTES DEL EQUIPO 👥
- 💻 **Mario Martínez Lozano** - Desarrollador - [@marichu-kt](https://github.com/marichu-kt)

## ESTRUCTURA DEL PROGRAMA

La práctica consiste en crear una aplicación de consola que simule una máquina tragaperras, permitiendo a los jugadores jugar en un juego de rodillos tradicional.

![Estructura del programa](/Images/img-2.png)

El programa muestra una interfaz de usuario básica con las siguientes opciones:

- Jugar: esta opción permite al usuario jugar una partida:

    - El juego comienza mostrando las posiciones aleatorias iniciales de los símbolos en tres rodillos.
    - El usuario dispondrá de dos opciones:
        - Jugar: que hace girar los rodillos, reordenando aleatoriamente los símbolos.
        - Salir: que devuelve al usuario al menú principal.

    - Si el usuario consigue una línea de símbolos ganadora (los 3 símbolos iguales), recibe como recompensa una de las frases motivacionales predeterminadas (no hay premios en metálico, no hacemos apología de los juegos de azar / apuestas).

- Mostrar premios: esta opción permite al usuario ver los diferentes premios cargados en la máquina. El proceso debe seguir los siguientes pasos:
    - Mostrar todos los premios disponibles, incluido el nombre. 
    - Pide el identificador (id) del premio al usuario. 
    - Si el premios existe, debe mostrar información detallada sobre el producto, incluido el nombre, la línea de símbolos y la frase de consejo asociada. 

- Carga de premios (Admin): esta opción permite a los usuarios admin cargar premios subiendo un archivo. El proceso debe seguir los siguientes pasos:
    - Mostrar todos los premios disponibles, incluido el nombre. 
    - Se comprueba que el archivo especificado existe. En caso afirmativo, se procederá al siguiente paso.
    - Sustituye los premios actuales de la máquina tragaperras por los premios que figuran en el archivo cargado.

- Salir: esta opción finalizará la ejecución del programa.

Las opciones de administración requieren la introducción de una clave secreta para continuar. Esto significa que debe pedir al usuario la clave cuando se elige esta opción y volver al menú principal si la clave no es válida. 

## FLUJO DEL PROGRAMA 

El siguiente diagrama ilustra la funcionalidad principal del programa, donde:
  - Función roja: función estática definida dentro del programa principal (main). Esta función se puede implementar en la clase del programa. 
  - Funciones naranja: métodos públicos (funciones) pertenecientes a una clase central, idealmente llamada SlotMachine.
  - Funciones azules: métodos públicos que deben ser implementados en otras clases (esto no quiere decir que deba existir una clase para cada método...) 

<p align="center"><img src="/Images/img-3.png" alt="Flujo del programa"></p>

Este flujo es una aproximación, no es obligatorio seguir este diagrama de flujo para crear su solución. 

## DEFINICIÓN DE LOS PREMIOS

La máquina tragaperras está diseñada para dispensar una amplia gama de premios, divididos en dos categorías principales: (1) premios simples y (2) premios aleatorios. Cada categoría de premios engloba los siguientes atributos comunes:
- Nombre (string): nombre del premio
- Símbolo 1 (int): símbolo que debe aparecer en el primer rodillo
- Símbolo 2 (int): símbolo que debe aparecer en el segundo rodillo
- Símbolo 3 (int): símbolo que debe aparecer en el tercer rodillo

Cada tipo de premio se define por sus propias características:
- Los premios simples cuentan con consejos específicos que se muestran cuando aparece la combinación de símbolos correspondiente.
- Los premios aleatorios presentan dos tipos de consejos (consejo 1 y consejo 2), junto con la probabilidad de que se produzca cada uno de ellos. Esto significa que cuando se gana un premio aleatorio, se da uno de los dos consejos en función de las probabilidades predefinidas para ese premio.

Los usuarios administradores son responsables de cargar la máquina tragaperras utilizando un método de carga masiva con un archivo CSV (Comma-Separated Values). Este archivo utiliza punto y coma (;) para separar la información, estructurada de la siguiente manera:
tipo_premio: especifica la categoría del premio: 1 para premios simples; y 2 para premios aleatorios. Esto ayuda a garantizar que los premios se cargan correctamente en la máquina.
- nombre_premio: especifica el nombre del premio.
- simbolo_1: indica el símbolo del primer rodillo.
- simbolo_1: indica el símbolo del segundo rodillo.
- simbolo_3: indica el símbolo del tercer rodillo.
- consejo_1: para los premios simples, es el consejo mostrado; para los premios aleatorios, es el primer consejo potencial.
- consejo_2: indica el segundo consejo potencial para los premios aleatorios.
- probabilidad: indica la probabilidad de que se muestre el primer consejo cuando se gana un premio. Por tanto, la probabilidad para el segundo consejo se establece automáticamente como 1 - probabilidad.

Para facilitar el trabajo, hay un archivo CSV de muestra en este enlace [<span style="color: blue;">Descargar archivo</span>](https://github.com/marichu-kt/Slot-Machine-CSharp-UFV/raw/master/CSV/slot_machine_products.csv). Este archivo sirve de guía para desarrollar el proceso de carga de premios, garantizando una comprensión y aplicación de la funcionalidad de la máquina tragaperras.

## CONSIDERACIONES DE DESAROLLO

Para desarrollar el programa hay que tener en cuenta diferentes consideraciones:
- Las ranuras se definen como una matriz de 3x3 con la fila horizontal central como línea ganadora.
- La máquina expendedora tiene 8 tipos de premios (slots). 
- Existen dos modos de uso: (1) cliente; y (2) administrador.
- Los clientes pueden las siguientes operaciones: (1) jugar; (2) mostrar premios; y (3) salir. 
- Los usuarios admin pueden ejecutar todas estas operaciones, y cargar los datos del fichero. 
- El programa implementa una validación de entrada completa para control de los errores.
- No se utilizan funciones como Environment.Exit(0) para finalizar el programa. 
- No se utilizan break y continue en los bucles. Se deben estructurar los bucles y la lógica de forma que se evite su necesidad, promoviendo un flujo de código claro y comprensible.



