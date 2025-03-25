README - Hack Wars
1. Información del Proyecto
Nombre del Proyecto: Cyber Runner
Equipo Creador: Pepito, Fulanita, Menganita
Fecha de Creación: 05/03/2024

2. Historial de Hackeos
Hack #1 - Equipo "Glitch Masters" - 12/03/2024
¿Qué hemos cambiado?

Añadimos una mecánica de salto doble.
Ajustamos la velocidad del personaje para que sea más fluida.
¿Cómo lo hemos hecho?

Modificamos el script PlayerMovement.cs, agregando una variable canDoubleJump.
Ajustamos speed en PlayerController.cs de 5 a 6.
¿Qué problemas hemos encontrado?

A veces, el personaje puede hacer más de dos saltos si se presiona rápido el botón.
Notas para el siguiente equipo:

Revisar el bug del salto doble.
Podría ser interesante añadir un efecto visual al saltar.
Hack #2 - Equipo "Byte Busters" - 19/03/2024
¿Qué hemos cambiado?

Arreglamos el bug del salto doble.
Agregamos una animación de partículas al saltar.
¿Cómo lo hemos hecho?

Corregimos la condición en PlayerMovement.cs para evitar múltiples saltos extra.
Añadimos un ParticleSystem al prefab del jugador.
¿Qué problemas hemos encontrado?

El personaje se siente un poco pesado, quizá la gravedad debería ajustarse.
Notas para el siguiente equipo:

Podrían probar con una gravedad más baja o añadir un dash para hacerlo más dinámico.