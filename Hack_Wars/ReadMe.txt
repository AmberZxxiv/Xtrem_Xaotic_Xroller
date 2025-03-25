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


