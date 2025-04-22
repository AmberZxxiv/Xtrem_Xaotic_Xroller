README - Hack Wars SEGUNDA ENTREGA
1. Información del Proyecto
Nombre del Proyecto: Xtra Xaotic ApuestaX
Equipo Creador: Lorena Pajarola, Alberto Serrano, Adrian Sanz y Amber Zaragoza
Fecha de Creación: 22 Abril 2025

2. Historial de Hackeos
Hack # 2.0 - Xtra Xaotic Enterprix - 22 Abril 2025
¿Qué hemos cambiado?
Para empezar dedicamos varias sesiones en arreglar, optimizar y rehacer las carpetas, códigos y objetos en el inspector, pues la versión que nos llegó tenía mecánicas incompletas o que no funcionaban como se esperaba. Lo solucionamos de las siguientes maneras:
-Añadimos un sistema de vida para el jugador y el boss, reparamos el disparo del jugador, hicimos que el boss pudiera dañar al jugador y que si este se salía del mapa o moría, se recargara la escena.
-Cambiamos el sistema de apuestas para que funcionara como una interfaz, añadiendo el temporizador de activación, los tokens para apostar y los botones para hacerlo y continuar el juego.
- Una vez la base ya funcionaba correctamente, añadimos más fases al boss, hicimos el sistema de apuestas funcional y añadimos sprites placeholders para la apariencia del juego.

¿Cómo lo hemos hecho?
Creamos nuevas carpetas para los assets nuevos, además de otra específica para aquellos componentes prescindibles del proyecto.
- Una vez reorganizados los assets, nos dividimos los apartados a reparar:
Alberto modificó el sistema de disparo del jugador simplificando el código y cambió el método de disparo al cursor del ratón y su clic izquierdo, variando así la cadencia, velocidad y tamaño de las balas. Además, añadió la variable de daño que hacía cada bala y la vida del boss.
Amber añadió un objeto bajo el mapa fuera del campo de visión, con un tag para matar al jugador en caso de que caiga encima, y resetee la escena.
También modificó los colliders del boss para que éste pudiera hacer daño al jugador si le impactaba lateralmente, pero se pudiera saltar por encima de él y esquivarlo sin recibir daño.
Adrián optimizó esto añadiendo tags a los objetos del boss y retocando los colliders, triggers y variables para no afectar a la movilidad del jugador al chocar con él.
Amber eliminó los objetos en escena que se utilizaban para activar las apuestas e interactuar con ellas; añadió un canvas con los tokens disponibles para gastar; los botones correspondientes para apostar a los 3 colores; pasar de ronda y la ruleta.
Adrián añadió un sistema para conseguir 1 token al bajarle los tercios de vida al boss y activar la zona de apuestas cada 15 segundos, aparte de cargar el juego en (lo que será) el botón de cambio de fase.
Lorena modifico las barras de vida hechas por los demas, para representar la vida del jugador y el boss de forma unificada.

- Añadimos nuevas mecánicas que aún no estaban en el proyecto de esta manera:
Adrián hizo funcional el sistema de apuestas, creando un script con la lógica y diferentes opciones y probabilidades de apuesta. Cuando pulsas un color, se genera un número aleatorio del 1 al 4 y si coincide con el número del color apostado, ganas. También añadió la variable para pasar a 1 de las 4 fases aleatorias del boss al pulsar next round.
Amber añadió a este sistema el tener que gastar 1 token para cada apuesta, y todos los que tengas si quieres pasar a la siguiente ronda sin apostar. En caso de ya haber apostado, se puede pasar gratis. También añadimos un sprite para cuando ganas o pierdes. 
Lorena trabajó en la tercera fase del boss en la cual este salta por el escenario de forma aleatoria, dañando al jugador si se encuentra justo en el área inferior en la que impacta, código el cual se añade dentro del script del boss, ligado a un número que representa dicha fase.
También añadió las partículas de dinero que rodean al boss en todas sus fases. 
Esta tercera fase no es funcional, por lo que está dejada como comentario en la parte inferior del código.
Alberto hizo 2 fases más, añadiendoles al mismo código y asignándoles su número.
En una de ellas el boss se mueve rápidamente de un lado a otro, saliéndose del mapa y haciendo que el jugador deba esquivar en el momento preciso su impacto, pues sino es empujado con gran fuerza fuera del mapa.
En la otra, el boss dispara grandes proyectiles instanciados al jugador, mientras se mueve por la parte superior del terreno de juego.
Amber diseñó unos placeholders específicos para cada boss, caracterizando un poco su dinámica y siguiendo la línea de una bola de ruleta gangster, además del diseño del jugador, que es un joker de poker y las partículas que deja atrás al andar.

¿Qué problemas hemos encontrado?
- El mayor problema es que tuvimos que repasar atentamente los scripts, assets y jerarquía, ya que había partes del README que no coincidían totalmente con lo que había en el proyecto, y además de que faltaban cosas, había otras que no hacían lo que se suponía, o directamente no hacían nada.
-BUGS: el boss a veces se queda bugeado de manera muy ocasional, a veces el player después de recibir daño no puede saltar
- A la hora de nosotros trabajar en nuevas mecánicas, nuestro mayor enemigo ha sido usar GitHub sin que se nos rompa todo a cada Push o Pull, por lo que hemos usado más Drive.

Notas para el siguiente equipo:
- En cuanto a las apuestas, teníamos la idea de que el color rojo estuviera relacionado con ganar o perder vida, el negro con el daño, y el verde a la velocidad.
- A nivel visual, las balas del jugador pretendíamos que fueran las 4 figuras del poker, y que el suelo sobre el que se juega pareciera la superficie de una ruleta.
- Recomiendo añadir que haya un descanso de fase a fase porque en cuanto la vida del boss llega a 0 cambia de fase instantáneamente y te puede pillar desprevenido como en el cambio de fase 1 a 2 la velocidad aumenta mucho y puede hacer que pierdas vidas varias veces seguidas y en el cambio de la fase 2 a 4 en cuanto cambia de fase dispara un proyectil enorme 
y no te da tiempo a reaccionar.
-Fase 3 no la conseguimos implementar por falta de tiempo y la explicación de cómo implementarla esta al final del código de boss_ruleta_Mechanics 
- añadir un periodo de invulnerabilidad al player para que no pueda perder vidas en un periodo muy corto de tiempo como a veces ocurre en la fase 1

3. Instrucciones de Uso
- Echar un ojo a cómo está todo ordenado en el asset browser, jerarquía y scripts, además de leer los comentarios antes de trabajar sobre ello.
- Recordar trabajar con prefabs.
- Preguntad si necesitáis algo a los Xtra Xaotics <3
