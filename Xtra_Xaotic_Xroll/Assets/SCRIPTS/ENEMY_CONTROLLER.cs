using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_CONTROLLER : MonoBehaviour
{
    public float enemyHealth;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            //aqui agrega cosas de soltar objetos y dineros y eso, se hace antes de que se destruya el objeto
            //Instantiate(drop, transform.position, Quaternion.identity); NO LO ACTIVES QUE SPAWNEA SIN 
            StartCoroutine(Dropear());

        }

    }

    public void GetDamage()
    {
        enemyHealth -= 2;
    }
    public void GenerateDrop()
    {
        // Generar drop en la posición del enemigo
        Instantiate(drop, transform.position, Quaternion.identity);
    }
    private IEnumerator Dropear()
    {
        yield return new WaitForSeconds(0.2f);
        print("mecago");
        GenerateDrop();
        Instantiate(drop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
