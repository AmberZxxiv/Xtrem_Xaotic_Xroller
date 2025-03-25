using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINION_CONTROLLER : MonoBehaviour
{
    public float minionHealth;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        minionHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (minionHealth <= 0)
        {
            //aqui agrega cosas de soltar objetos y dineros y eso, se hace antes de que se destruya el objeto
            //Instantiate(drop, transform.position, Quaternion.identity); NO LO ACTIVES QUE SPAWNEA SIN 
            StartCoroutine(Dropear());

        }

    }

    public void GetDamage()
    {
        minionHealth -= 2;
    }
    public void GenerateDrop()
    {
        // Generar drop en la posición del enemigo
        Instantiate(drop, transform.position, Quaternion.identity);
    }
    private IEnumerator Dropear() // Corrutina para crear un drop al morir un enemigo
    {
        yield return new WaitForSeconds(0.0f);
        GenerateDrop();
        Destroy(this.gameObject);
    }

}
