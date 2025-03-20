using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_CONTROLLER : MonoBehaviour
{
    public float enemyHealth;
    public GameObject drop;  // Prefab del drop
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto desde el cual se disparan los proyectiles
    public float shootingCooldown = 2f; // Tiempo de espera entre disparos
    private float lastShotTime = 0f; // Última vez que se disparó un proyectil

    private bool hasDropped = false; // Variable para verificar si el drop ya fue generado

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si el enemigo puede disparar
        if (Time.time - lastShotTime >= shootingCooldown)
        {
            Shoot();
            lastShotTime = Time.time; // Actualiza el tiempo del último disparo
        }

        // Verificar la salud del enemigo
        if (enemyHealth <= 0 && !hasDropped) // Verifica si el enemigo debe morir
        {
            // Antes de destruir al enemigo, generamos los drops
            GenerateDrop();
            hasDropped = true; // Marca que el drop ha sido generado
            Destroy(gameObject); // Eliminar al enemigo
        }
    }

    // Método para disparar el proyectil
    void Shoot()
    {
        if (projectilePrefab != null && shootingPoint != null)
        {
            // Crear el proyectil en el punto de disparo
            Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        }
    }

    // Método para recibir daño
    public void GetDamage()
    {
        enemyHealth -= 2;
        // Solo generar drop si la salud llega a 0 y no se ha generado un drop aún
        if (enemyHealth <= 0 && !hasDropped)
        {
            GenerateDrop();
            hasDropped = true; // Marca que el drop ha sido generado
            Destroy(gameObject); // Eliminar al enemigo
        }
    }

    // Método para generar el drop cuando el enemigo es destruido
    public void GenerateDrop()
    {
        if (drop != null)
        {
            // Generar el drop en la posición del enemigo
            Instantiate(drop, transform.position, Quaternion.identity);
        }
    }
}


