using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Apuesta_mode : MonoBehaviour
{
    public bool changeApuesta = false;
    public bool apuestaHecha = false;

    public bool rojoApuesta = false;
    public bool negroApuesta = false;
    public bool verdeApuesta = false;

    public bool rojoRuleta = false;
    public bool negroRuleta = false;
    public bool verdeRuleta = false;

    public bool perdiste = false;

    public int timeChange = 30; // tiempo cada que se activa el modo apuesta
    public int probabilidad = 101; // numero del 1 al 100 que se usa para hacer la probabilidad de la ruleta
    public int dañoABoss; // cantidad de daño que se le hace al boss si ganas en la ruleta

    public Button BotonModoApuesta;
    public GameObject ModoApuesta;
    public GameObject zonaApuesta;
    public BotonesApuesta botonesApuesta;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(TimeApuesta());
        zonaApuesta.SetActive(false);
        ModoApuesta.SetActive(false);
        botonesApuesta.botonRojo.SetActive(false);
        botonesApuesta.botonVerde.SetActive(false);
        botonesApuesta.botonNegro.SetActive(false);

         rojoApuesta = false;
         negroApuesta = false;
         verdeApuesta = false;

         rojoRuleta = false;
         negroRuleta = false;
         verdeRuleta = false;

        apuestaHecha= false;
        perdiste = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (apuestaHecha==true) // Una vez hecha la apuesta se vuelve a activar el tiempo para el modo apuesta
        {
            StartCoroutine(TimeApuesta());
            zonaApuesta.SetActive(false);
            apuestaHecha = false;

        }

        if (probabilidad <= 4) //despues de apostar, probalbilidad de que te toque verde
        {
            verdeRuleta = true;
            perdiste = true;
            ResultadoApuesta();

        }
        else if (probabilidad >= 5 && probabilidad <= 48) // despues de apostar, probalbilidad de que te toque rojo
        {
            rojoRuleta = true;
            perdiste = true;
            ResultadoApuesta();
        }
        else if (probabilidad >= 49 && probabilidad <= 100) //despues de apostar, probalbilidad de que te toque negro
        {
            negroRuleta = true;
            perdiste = true;
            ResultadoApuesta();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            BotonModoApuesta.onClick.Invoke();
        }



    }

    public void Apuesta() //funcion llamada por el boton de apostar para que se active la zona de apuesta y el boton de apostar se desactive 
    {
        zonaApuesta.SetActive(true);
        ModoApuesta.SetActive(false);
        botonesApuesta.botonRojo.SetActive(true);
        botonesApuesta.botonVerde.SetActive(true);
        botonesApuesta.botonNegro.SetActive(true);

    }
    public void ApuestaRojo()
    {
        probabilidad = Random.Range(0, 100);
        rojoApuesta = true;
    }
    public void ApuestaNegro()
    {
        probabilidad = Random.Range(0, 100);
        negroApuesta = true;
    }
    public void ApuestaVerde()
    {
        probabilidad = Random.Range(0, 100);
        verdeApuesta = true;
    }
    public void ResultadoApuesta()
    {

        if (rojoApuesta == true && rojoRuleta == true)
        {
            //Dano a boss
            Debug.Log("ganasterojo");
        }
        else if (negroApuesta == true && negroRuleta == true)
        {
            Debug.Log("ganastenegro");
            //Dano a boss
        }
        else if (verdeApuesta==true && verdeRuleta == true)// al ser tan baja la probabilidad de que te toque el verde, si apuestas y te toca, matas automaticamente al boss
        {
            Debug.Log("ganasteverde");
            //Destruir a (Boss) ;
        }
        else if(!((rojoApuesta == true && rojoRuleta == true) || (negroApuesta == true && negroRuleta == true)||(verdeApuesta == true && verdeRuleta == true)) && perdiste == true)
        {

            Debug.Log("perdistebobo");
            //Dano a player, te quita una vida
        }
        rojoApuesta = false;
        negroApuesta = false;
        verdeApuesta = false;

        rojoRuleta = false;
        negroRuleta = false;
        verdeRuleta = false;
        probabilidad = 101;
        apuestaHecha = true;
        perdiste = false;

    }

    IEnumerator TimeApuesta() // cada (timeChange) segundos se activa el modo apuesta en la partida
    {
        yield return new WaitForSeconds(timeChange);
        ModoApuesta.SetActive(true);
    }



}
