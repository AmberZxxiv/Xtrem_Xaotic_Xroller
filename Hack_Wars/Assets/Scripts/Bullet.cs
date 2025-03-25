using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.right; // Dirección inicial
    public float lifeTime = 2f; // Tiempo antes de destruirse

    void Start()
    {
        Destroy(gameObject, lifeTime); // Eliminar el proyectil tras un tiempo
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Destroy(gameObject);
    //        // Aquí puedes agregar daño al enemigo
    //    }
    //}
}

