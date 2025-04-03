using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona_Apuesta : MonoBehaviour
{
    public GameObject zonaApuesta;
    int timeChange = 15; // tiempo cada que se activa el modo apuesta
    public bool rojo;
    public bool negro;
    public bool verde;
    public bool apuestaHecha;
    public int result;
    public Player_Controller player_Controller;
    public Boss_Ruleta_Mecanics Boss_Codigo;

    // Start is called before the first frame update
    void Start()
    {
        zonaApuesta.SetActive(false);
        StartCoroutine(TimeApuesta());
        apuestaHecha = false;
        rojo = false;
        negro = false;
        verde = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (rojo == true && result == 1)
            {
                print("rojo"); //premio JIJI
                result = 0;
                rojo = false;
                negro = false;
                verde = false;
                apuestaHecha = false;
            player_Controller.vidasPlayer++;
            }
            if (negro == true && result == 2)
            {
                print("negro"); //premio JIJI
                result = 0;
                rojo = false;
                negro = false;
                verde = false;
                apuestaHecha = false;
            Boss_Codigo.damage++;
            }
            if (verde == true && result == 3)
            {
                print("verde"); //premio JIJI
                result = 0;
                rojo = false;
                negro = false;
                verde = false;
                apuestaHecha = false;
            player_Controller.setSpeed++;
            //SUMAR VELOCIDAD DE MOVIMIENTO
            }
            else
            {
                result = 0; //no premio :(
                rojo = false;
                negro = false;
                verde = false;
                apuestaHecha = false;
            }
    }

    IEnumerator TimeApuesta() // cada (timeChange) segundos se activa el modo apuesta en la partida
    {
        yield return new WaitForSeconds(timeChange);
        zonaApuesta.SetActive(true);
        Time.timeScale = 0;

    }

    // Boton para pasar a la siguiente fase
    public void Next_Round () //puedes pasar a la siguiente ronda reseteando todos tus tokens(pagas por pasar de nivel :)
    {
        if (player_Controller.tokenCount >= 3 || player_Controller.tokenCount == 0 || Boss_Codigo.health == 0)
        {
        // cargar siguiente fase de boss
        player_Controller.tokenCount = 0;
        player_Controller.tokenInventory.text = player_Controller.tokenCount.ToString("Tokens = " + player_Controller.tokenCount);
        zonaApuesta.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(TimeApuesta());
        }
    }

    // 3 Funciones para apostar a las 3 opciones diferentes
    public void Apuesta_rojo()
    {
        if (player_Controller.tokenCount > 0)
        {
        Ruleta_time();
        player_Controller.tokenCount--;
        player_Controller.tokenInventory.text = player_Controller.tokenCount.ToString("Tokens = " + player_Controller.tokenCount);
        rojo = true;
        apuestaHecha=true;
        }
    }
    public void Apuesta_negro()
    {
        if (player_Controller.tokenCount > 0)
        {
        Ruleta_time();
        player_Controller.tokenCount--;
        player_Controller.tokenInventory.text = player_Controller.tokenCount.ToString("Tokens = " + player_Controller.tokenCount);
        negro = true;
        apuestaHecha = true;
        }
    }
    public void Apuesta_verde()
    {
        if (player_Controller.tokenCount > 0)
        {
            Ruleta_time();
            player_Controller.tokenCount--;
            player_Controller.tokenInventory.text = player_Controller.tokenCount.ToString("Tokens = " + player_Controller.tokenCount);
            verde = true;
            apuestaHecha = true;
        }
    }

    // Genera un numero aleatoria del 1 al 3
    public void Ruleta_time()
    {
        result = Random.Range(1, 4);
    }
}
