using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Ruleta_Mecanics : MonoBehaviour
{
    public float speed = 4f;
    public float minX = -9.5f, maxX = 9.5f;
    public int health = 100;  // Salud del Boss
    public int damage;

    public Slider healthSlider;  // Referencia al Slider de la barra de vida

    private int direction = 1;

    void Start()
    {
        // Configura el valor máximo del slider según la salud inicial del Boss
        if (healthSlider != null)
        {
            healthSlider.maxValue = health;  // Asigna el valor máximo del slider (100 en este caso)
            healthSlider.value = health;    // Asigna el valor inicial del slider (también 100)
        }
    }

    void Update()
    {
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            StartCoroutine(RandomVelocity());
            direction *= -1;
        }
    }

    IEnumerator RandomVelocity()
    {
        speed = 0;
        yield return new WaitForSeconds(Random.Range(0, 3));
        speed = Random.Range(4, 15);
    }

    // Método para reducir la vida del Boss
    public void TakeDamage(int damage)
    {
        health -= damage;  // Resta la vida

        // Actualiza la barra de vida del Slider
        if (healthSlider != null)
        {
            healthSlider.value = health;  // Actualiza el valor del slider con la vida restante
        }

        if (health <= 0)
        {
            Die();  // Si la vida llega a 0, el Boss muere
        }
    }

    void Die()
    {
        // Aquí puedes poner la lógica de la muerte del Boss (animación, efectos, etc.)
        Debug.Log("Boss ha muerto");
        Destroy(gameObject);  // Destruye el objeto del Boss
    }
}

