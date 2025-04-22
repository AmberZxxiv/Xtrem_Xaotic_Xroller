using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 15f;
    public Vector2 direction = Vector2.right; // Dirección inicial
    public float lifeTime = 2f; // Tiempo antes de destruirse

    void Start()
    {
        Destroy(gameObject, lifeTime); // Eliminar el proyectil tras un tiempo
    }




}


