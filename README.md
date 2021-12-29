# DDV_Final_Project
Videogame development project on Unity3D. CoderHouse Course. 

# Explicación de Mecánica y consideraciones generales
Historia: 
Se encuentra detallada en la escena de introducción del juego.

Objetivo general del juego:
Escapar del laboratorio y del ejercito humano para poder llegar a la nave para escapar.

Controles del juego:
W-A-S-D: Movimiento del Player
Shift: Sprint del Player
Espaciadora: Salto del Player
Click Derecho: Mira para poder disparar
Click Izquierdo: Disparo (Se debe estar con la mira para disparar)
Click en la rueda del mouse: Cambia la mira de posición
Rueda del mouse: Modifica la velocidad de caminar del player
F1 - F2: cambio de cámaras; F1 (Cámara de Player en 3ra persona), F2 (cámara de vigilancia de visualización tipo Top Down)

Mecánicas:
Nivel 0(Laboratorio): Se debe encontrar el portal que lleva al proximo nivel antes de que termine el tiempo o el jugador pierde, el portal solo permanecerá por pocos segundos en su posición, luego se moverá a otra ubicación del laboratorio. Y se deben recordar los números que aparecen en los distintos niveles, podrían ser útiles mas adelante.

Nivel 1 (Laboratorio-Exterior): Se debe eliminar o esquivar a los enemigos para poder acceder al nivel 2. Dentro del nivel 1 contamos
con un regenerador de energía, y si se elimina a los enemigos se podrá acceder a un nivel secreto!!! Dentro del nivel secreto deberá realizar un minigame que consiste en disparar un campo de fuerza para coincidir el color de 3 círculos flotantes. 

Nivel 2 (Plano superior-Naves de escape): Para acceder a donde se encuentra el hangar de salida con su nave, se deberá eliminar a todos los enemigos de este nivel, ya que en tanto eso no ocurra el acceso se encontrará bloqueado.
En este nivel encontraremos una vida extra (si nos arriesgamos a cruzar paneles flotantes para conseguirla).
También contamos en este nivel con un regenerador de energía para los disparos.

Bugs encontrados por nosotros:
- El salto de player llega mas alto de lo que debería cuando colisiona con ciertos objetos.
- La mira del player a veces queda descentrada de donde se dirige el disparo laser.
- Se dan colisiones extrañas en el nivel 2 con el player.
- Los enemigos del nivel 1 debería frenar al ver al player pero los mismos no se detienen (esto se consulto a un tutor pero no fue
respondida la consulta).
- En el nivel oculto dentro del nivel 1, hay 3 cilindros para la ejecucion del minigame en el cual uno de los cilindros no se colorea cuando se corre el juego desde el ejecutable, pero funciona bien en Unity. A pesar de ello, el juego puede continuar perfectamente ya que la lógica para ganar no está determinada por los colores sino que por una función matemática
