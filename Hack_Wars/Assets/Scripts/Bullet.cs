using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.right; // Direcci�n inicial
    public float lifeTime = 2f; // Tiempo antes de destruirse

    void Start()
    {
        Destroy(gameObject, lifeTime); // Eliminar el proyectil tras un tiempo
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    // Detecci�n de colisi�n
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))  // Si colisiona con el Boss
        {
            // Accedemos al script del Boss y le aplicamos da�o
            Boss_Ruleta_Mecanics boss = other.GetComponent<Boss_Ruleta_Mecanics>();
            if (boss != null)
            {
                boss.TakeDamage(1);  // El da�o que recibe el Boss (1 vida por bala)
            }

            // Destruir la bala al colisionar
            Destroy(gameObject);
        }
    }
}


