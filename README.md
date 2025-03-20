README - Hack Wars
1. Información del Proyecto
Nombre del Proyecto: Xtra Xaotic Xroller
Equipo Creador: Lorena Pajarola, Alberto Serrano, Adrian Sanz y Amber Zaragoza
Fecha de Creación: 13 Marzo 2025

2. Historial de Hackeos
Cada equipo que modifique este proyecto debe añadir una nueva entrada siguiendo este formato:

Hack # 0.1 - Xtra Xaotic Enterprix - 20 Marzo 2025
¿Qué hemos cambiado?
- Primero añadimos un suelo, con dos bases a los lados y una barrera invisible detrás.
- La base enemiga tiene un spawners con enemigos básicos cada 5 segundos, que se desplazan hasta la base aliada.
- Metemos un jugador, que se puede mover y saltar, además de un arma para atacar a los enemigos con un daño mínimo.
- En la base aliada, activamos por proximidad del jugador lo que será el inventario, en el que de momento puede generar las tropas aliadas básicas que van a la base enemiga.
- Añadimos tambien un minimapa para que el jugador sepa a que distancia se encuentra.
- Los enemigos sueltan un drop provisional que suma recursos al jugador cuando se coje.
- Añadimos algunos sprites placeholders para guiar el concepto visual y narrativo del juego.

¿Cómo lo hemos hecho?
- Tenemos un script que controla el spawner de enemigos y otro el de aliados.
- Un script controla el movimiento y las interacciones del jugador
- Los enemigos y aliados comparten un script con las stats básicas.
- Otro script controla el movimiento y el trackeo de los contrincantes o la base
- Funcionamos en base a prefabs de las diferentes tropas y drops, por lo que cada objeto nuevo que se cree, deberá ser guardado como tal.

¿Qué problemas hemos encontrado?
- Al hacer clic para atacar a los enemigos, el daño se aplica infinitamente en lugar de 1 vez.
- En ocasiones suma mas puntos de lo debido.

Notas para el siguiente equipo:
- A la hora de generar nuevas tropas enemigas, aliadas o drops, PLIS, generar prefabs.
- Mantener el orden de las capas existentes y las nomenclaturas utilizadas.
- La idea es hacer un jueguito infinito por oleadas, hasta destruir la base enemiga
Con los recursos que consigues de los enemigos, puedes generar tropas y torretas para defender. (refs: stick wars, plants vs zombies, clash royale / of clans, starcraft )

3. Instrucciones de Uso
- Los controles son los básicos de cruceta / WASD, espacio y clics.

