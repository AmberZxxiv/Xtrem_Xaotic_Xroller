README - Hack Wars
1. Información del Proyecto
Nombre del Proyecto: Cuphead Casino
Equipo Creador: Techno Evil Corp
Fecha de Creación: 11/03/2025



Descripción: Juego basado en el gameplay de Cuphead. Solo hay bosses, no hay run n guns. El juego entero serán 4 bosses uno detrás de otro. Cuando termines un boss, pasarás al siguiente. Puede haber un descanso entre boss y boss, como un menú principal o algo por el estilo. Pero no habrá ninguna otra cosa de gameplay.

El jugador tendrá 5 vidas, cada vez que el jugador colisione con el enemigo, o reciba algún tipo de daño, se le restará una vida.

Que el jugador dispare ya está hecho. Te mueves con WASD o con las flechas. Mantén el botón intro para disparar. Si mantienes shift te quedarás quieto en el suelo, ayudándote a poder disparar sin tener que moverte. El jugador disparará depende de adonde estés apuntando con las teclas de dirección. Si mantienes A y W o W y D, dispararás en diagonal.

*PARA PROS QUE HAYAN JUGADO A CUPHEAD*: Si os veis capaces podéis hacer el modo de disparo múltiple, y el dash.

A diferencia de Cuphead, aquí saldrán las barras de vida de los bosses, como ocurre en Dark Souls o en muchos otros ejemplos de videojuegos.

Los bosses estarán tematizados de juegos de Casino, son los siguientes:

-Boss de la Ruleta
-Boss del Blackjack
-Boss de apostar a los dados
-Boss de la tragaperras

Todos las peleas de bosses sucederán de la siguiente manera:
Empezaran con un combate genérico de cuphead, donde el boss te intentará hacer daño. Tu tienes que esquivar sus ataques, y mientras, le puedes disparar para hacerle daño al boss. Después de 30 segundos (tiempo provisional, se puede cambiar si se ve que es muy largo o muy poco tiempo) pasamos al modo apuesta, donde se jugará al juego de cada boss, y durante este modo, el boss no puede recibir daño, tampoco te atacará.
Si ganas la apuesta, quitaras una gran suma de daño al enemigo, si pierdes la apuesta se te quitará una vida. Cuando termine el modo apuesta volveremos al modo de combate genérico, donde después de esos *30 segundos* volveremos al modo apuesta, repitiendo el bucle infinitamente hasta que mates al boss. NO ES OBLIGATORIO APOSTAR. En el modo apuesta puedes decidir no apostar, y pasar de nuevo al modo genérico.

*Nota para programadores*: Las balas que disparas, son un prefab que lleva un tag "bullet" La idea es que la programación del daño realizado a los bosses, sea a través de OnCollisionEnter2D y detecte ese tag "bullet" y por cada colisión detectada haga una cantidad de daño al boss.



BOSS DE LA RULETA:

El boss es la bola de la ruleta, se pondrá a girar sobre si misma, y se moverá de izquierda a derecha. Si colisiona con el jugador, el jugador pierde una vida. Habrá que saltarla para esquivarla y que no te haga daño. En el modo apuesta se apostara simplemente por color. Rojo, negro o verde.

- Probabilidad de que salga rojo: 48,5%
- Probabilidad de que salga negro: 48,5%
- Probabilidad de que salga verde: 3%

Si aciertas la apuesta le quitaras una gran cantidad de daño. Si pierdes la apuesta se te quitará una vida. Si has apostado al verde, y ganas la apuesta, mataras instantáneamente al boss. Si pierdes la apuesta al verde, NO habrá mayor penalización, aparte de la vida perdida por haber perdido la apuesta.



BOSS DEL BLACKJACK (Recomendado dejarlo para gente con conocimientos avanzados de programación):

El boss son unos guantes blancos, como los del juego del trilero de Wii Party, o como el boss de Super Smash Bros. En el modo genérico, dispara naipes que se quedarán clavados en el suelo durante 1 segundo. Tu tendrás que esquivarlos para que no te hagan daño. En el modo apuesta jugareis al BlackJack (DEBERÁ SER FIEL AL JUEGO ORIGINAL, Y NO FALSEARLO. MUY IMPORTANTE LEERSE LAS REGLAS DEL BLACKJACK PARA REPLICARLO BIEN), donde podrás jugar como quieras, pedir carta y pasar. Si ganas la mano le haces una gran suma de daño al boss, si pierdes la mano el te quitará una vida. Si sacas BlackJack matarás instantáneamente al boss. RECUERDA QUE SOLO ES BLACKJACK SI SALE 21 EN TUS PRIMERAS DOS CARTAS. (UN AS, Y UNA FIGURA O UN 10).



BOSS DE LOS DADOS:

El boss serán dos dados (dos cubos) que saltaran independientemente cada uno y si te pisan te hacen daño. Como ocurre con Goopy le grande en Cuphead.
En el modo apuesta, ambos se meteran en un cubilete y se tiraran. Ambos son dados de 6. Se sumaran los números que salgan. Numero minimo posible 1 + 1 = 2. Numero maximo posible 6 + 6 = 12.

Los resultados posibles son del 2 al 12. Antes de que salga el resultado, el jugador apostara si el numero se pasa de 7 (numero del 8 al 12) o NO se pasa de 7 (numero del 2 al 6). Si justo sale 7, se considerara empate (Ni haces daño, ni pierdes vida). Nota: Es imposible que salga 1, debido a que lo minimo que puede salir es 1 + 1. Si sale 6 + 6, y apostaste a que se pasaba de 7. Mataras instantáneamente al boss.


BOSS DE LA TRAGAPERRAS:

Debido a la baja probabilidad que tiene este juego de ganar, el juego de la tragaperras estará falseado para poder ajustarse al resto de juegos.

El boss sera una tragaperras, que irá escupiendo monedas al cielo, e irán cayendo. El jugador tendrá que esquivarlas, si colisiona con una, perderá una vida.

El modo apuesta falseado funcionara de la siguiente manera:

Tiraras de la palanca de la tragaperras. Internamente tendrá una probabilidad de 50% de ganar o de perder. Si sale que pierdes, la tragaperras mostrará una combinación de figuras aleatoria que no premia nada. Ejemplo: Cereza, diamante, siete. Si ganas el 50% se lanzará internamente una nueva probabilidad de 1/3 (33%) donde podra salir una de las tres siguientes opciones:

- Daño bajo al boss (Se muestran 3 cerezas)
- Daño alto al boss (Se muestran 3 diamantes)
- Muerte instantánea del boss (Se muestran 3 sietes)
-------------------------------------------------------

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
Lorena modificó los placeholders que usamos los demas, para representar la vida del jugador y el boss de forma unificada.

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



