using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ENEMY_AI_TARGETING : MonoBehaviour
{
    public GameObject[] allyTroop;
    public GameObject allyBase;
    public float movSpeed;
    GameObject target;
    bool triggered;

    void Start()
    {
        triggered = false; //desactiva el trigger de enemigos
        TargetBase(); //llama al targeteo de la base enemiga
    }

    void Update()
    {
    //    OnTriggerEnter2D(triggered=true);
    //    OnTriggerExit2D(triggered=false);
        //SI EL ENEMIGO NO TIENE CONTRINCANTE
        if (!triggered)
        {
            TargetBase();

            //if entra en la base aliada, le pega y recibirá daño

            //if entra en el triger de un contrincante, esta triggered
           
        }

        //SI ENCUENTRA CONTRINCANTE
        if (triggered)
        {
            //se pega con el enemigo

            //si ya no esta dentro del trigger, !triggered
        }
    }

    //TARGETEA SOLDADO DE TROPAS
    void TargetAlly()
    {
        //por cada hijo dentro de la tropa
        foreach (GameObject allySoldier in allyTroop)
        {
            
                //lo targeteo
                target = allySoldier;
                break;
            
        }
    }

    //TARGETEA BASE ALIADA
    void TargetBase()
    {
        //lo targeteo
        target = allyBase; 
    }

}
