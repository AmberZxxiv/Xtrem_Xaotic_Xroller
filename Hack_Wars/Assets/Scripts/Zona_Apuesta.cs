using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona_Apuesta : MonoBehaviour
{
    public GameObject zonaApuesta;
    public int timeChange = 5; // tiempo cada que se activa el modo apuesta

    // Start is called before the first frame update
    void Start()
    {
        zonaApuesta.SetActive(false);
        StartCoroutine(TimeApuesta());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeApuesta() // cada (timeChange) segundos se activa el modo apuesta en la partida
    {
        yield return new WaitForSeconds(timeChange);
        zonaApuesta.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void Next_Round ()
    {
        // cargar siguiente fase de boss
        zonaApuesta.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(TimeApuesta());
    }
}
