using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona_Apuesta : MonoBehaviour
{
    public GameObject zonaApuesta;
    public int timeChange = 5; // tiempo cada que se activa el modo apuesta
    public bool rojo;
    public bool negro;
    public bool verde;
    public bool apuestaHecha;
    public int result;

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
        if(rojo==true && result==1)
        {
            print("rojo");
        }
        if(negro==true && result==2)
        {
            print("negro");
        }
        if(verde==true && result==3)
        {
            print("verde");
        }
    }

    IEnumerator TimeApuesta() // cada (timeChange) segundos se activa el modo apuesta en la partida
    {
        yield return new WaitForSeconds(timeChange);
        zonaApuesta.SetActive(true);
        Time.timeScale = 0;

    }

    // Boton para pasar a la siguiente fase
    public void Next_Round ()
    {
        // cargar siguiente fase de boss
        zonaApuesta.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(TimeApuesta());
    }

    // 3 Funciones para apostar a las 3 opciones diferentes
    public void Apuesta_rojo()
    {
        Ruleta_time();
        rojo = true;
        apuestaHecha=true;
    }
    public void Apuesta_negro()
    {
        Ruleta_time();
        negro = true;
        apuestaHecha = true;
    }
    public void Apuesta_verde()
    {
        Ruleta_time();
        verde = true;
        apuestaHecha = true;
    }

    // Genera un numero aleatoria del 1 al 3
    public void Ruleta_time()
    {
        result = Random.Range(1, 3);
    }
}
