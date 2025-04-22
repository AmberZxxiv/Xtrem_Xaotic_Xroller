using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss_Ruleta_Mecanics : MonoBehaviour
{
    public Player_Controller player_Controller;
    public float speed = 4f;  // Velocidad de movimiento (ajustable)
    public float minX = -8.75f, maxX = 8.75f;  // L�mites de movimiento
    public int health = 100;  // Salud inicial del Boss
    public float damage;
    public Slider healthSlider;  // Barra de vida del Boss
    public GameObject BossWeapon;  // Referencia al arma del Boss
    public GameObject projectilePrefab;
    public GameObject walls;// Prefab del proyectil
    public Transform firePoint;  // Punto de disparo del proyectil
    public GameObject target;  // Objetivo (Player o cualquier otro GameObject asignado en el Inspector)
    public GameObject phase1sprite;
    public GameObject phase2sprite;
    public GameObject phase3sprite;
    public GameObject phase4sprite;

    private int direction = 1;  // Direcci�n de movimiento (1 = derecha, -1 = izquierda)
    private int phase = 1;  // Fase inicial del Boss
    private bool isChangingVelocity = false;  // Controla si estamos cambiando la velocidad
    private Vector3 startPos;  // Posici�n inicial del Boss para el movimiento semicircular

    private float fireCooldown = 2f;  // Tiempo entre disparos
    private float nextFireTime = 0f;  // Tiempo en el que se podr� disparar de nuevo
    private bool phaseFourInitialized = false; // Para asegurar que solo se aumente la altura al entrar en fase 4

    public float JumpForce = 10;
    public Transform player;
    private Rigidbody2D rb;
    private bool isJumping = false;


    void Start()
    {
        phase1sprite.SetActive(false);
        phase2sprite.SetActive(false);
        phase3sprite.SetActive(false);
        phase4sprite.SetActive(false);
        startPos = transform.position;  // Guardar la posici�n inicial del Boss

        // Configura el valor m�ximo del slider seg�n la salud inicial del Boss
        if (healthSlider != null)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }

        // Asignar una velocidad inicial aleatoria para fase 1
        speed = Random.Range(9f, 17f); // Establece un rango de velocidad aleatoria en fase 1
    }

    void Update()
    {
        // Dependiendo de la fase, el boss se comporta de manera diferente
        if (phase == 1)
        {
            phase1sprite.SetActive(true);
            phase2sprite.SetActive(false);
            phase3sprite.SetActive(false);
            phase4sprite.SetActive(false);
            //player_Controller.premio1 = false;
            //player_Controller.premio2 = false;
            //player_Controller.premio3 = false;
            NormalPhaseBehavior();
        }
        else if (phase == 2)
        {
            phase2sprite.SetActive(true);
            phase3sprite.SetActive(false);
            phase4sprite.SetActive(false);
            phase1sprite.SetActive(false);
            //player_Controller.premio1 = false;
            //player_Controller.premio2 = false;
            //player_Controller.premio3 = false;
            PhaseTwoBehavior();
        }
        else if (phase == 4)
        {
            phase4sprite.SetActive(true);
            phase1sprite.SetActive(false);
            phase2sprite.SetActive(false);
            phase3sprite.SetActive(false);
            //player_Controller.premio1 = false;
            //player_Controller.premio2 = false;
            //player_Controller.premio3 = false;
            PhaseFourBehavior();
        }
    }
    public void TakeDamages(int damage)
    {
        health -= damage;  // Resta la vida

        // Actualiza la barra de vida del Slider
        if (healthSlider != null)
        {
            healthSlider.value = health;  // Actualiza el valor del slider con la vida restante
        }

        if (health <= 0)
        {
            player_Controller.premio1 = false;
            player_Controller.premio2 = false;
            player_Controller.premio3 = false;
            Die();  // Si la vida llega a 0, el Boss muere
        }
        void Die()
        {
            // Aqu� puedes poner la l�gica de la muerte del Boss (animaci�n, efectos, etc.)
            Debug.Log("Boss ha muerto");
            Destroy(gameObject);  // Destruye el objeto del Boss
        }

    }

    // Comportamiento de la fase 1
    void NormalPhaseBehavior()
    {

        // Mueve al boss en la direcci�n actual
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        // Si el boss llega al l�mite de la pantalla (izquierda o derecha), cambia de direcci�n
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            ChangeDirection();  // Cambia la direcci�n cuando toca el l�mite
        }

        // Cambiar la velocidad aleatoriamente despu�s de un tiempo
        if (!isChangingVelocity)
        {
            StartCoroutine(RandomVelocity());
        }
    }

    // Comportamiento de la fase 2
    void PhaseTwoBehavior()
    {
        // En fase 2, la velocidad es constante y el boss se mueve a esa velocidad
        transform.position += new Vector3(25f * direction * Time.deltaTime, 0, 0);

        // Cambia de direcci�n si llega a los nuevos l�mites de fase 2
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            ChangeDirection();
        }

        // Si la salud del boss llega a 0, el boss pasa a la fase 4 con 100 de vida
        if (health <= 0 && phase == 2)
        {
            EnterPhaseFour();  // Llamamos al m�todo para pasar a la fase 4
        }
    }
    // M�todo para hacer que el enemigo salte hacia la posici�n del jugador
    void PhaseThreeBehavior()
    {
        isJumping = true;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, JumpForce));
    }


    // Comportamiento de la fase 4
    void PhaseFourBehavior()
    {
        // Aumentar la altura al entrar en fase 4 si no se ha hecho antes

        if (!phaseFourInitialized)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 8.5f, transform.position.z);
            phaseFourInitialized = true;  // Marcamos que ya se ha aumentado la altura
        }

        // Movimiento horizontal igual que en la fase 2
        transform.position += new Vector3(15f * direction * Time.deltaTime, 0, 0);

        // Cambia de direcci�n si llega a los nuevos l�mites de fase 4
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            ChangeDirection();
        }

        // Disparar proyectiles al jugador a intervalos regulares
        if (Time.time >= nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + fireCooldown;  // Actualizamos el siguiente tiempo de disparo
        }
    }

    // M�todo para disparar proyectiles al jugador o objetivo
    void ShootProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instanciar el proyectil y lanzarlo hacia el objetivo
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Si no se ha asignado un objetivo, usar al jugador como objetivo predeterminado
            if (target == null)
            {
                target = GameObject.FindWithTag("Player");  // Buscar el GameObject con el tag "Player"
            }

            if (target != null)
            {
                // Apuntar y disparar hacia el objetivo
                Vector3 direction = (target.transform.position - firePoint.position).normalized;
                projectile.GetComponent<Rigidbody2D>().velocity = direction * 15f;  // Velocidad del proyectil
            }
        }
    }

    // M�todo para cambiar la direcci�n del Boss
    void ChangeDirection()
    {
        direction *= -1;  // Cambia la direcci�n (de izquierda a derecha o viceversa)
    }

    // Corutina para cambiar la velocidad aleatoriamente en la fase 1
    IEnumerator RandomVelocity()
    {
        isChangingVelocity = true;

        // Cambiar la velocidad aleatoriamente dentro de un rango cada 2-5 segundos
        yield return new WaitForSeconds(Random.Range(2f, 3f));  // Espera entre 2 y 3 segundos
        speed = Random.Range(6f, 15f);  // Asigna una nueva velocidad aleatoria entre 4 y 10

        isChangingVelocity = false;
    }

    // M�todo para activar la fase 2
    void EnterPhaseTwo()
    {
        phase = 2;
        health = 100;  // Restaura la salud a 100
        if (healthSlider != null)
        {
            healthSlider.value = health;  // Actualiza la barra de vida
        }

        // Cambiar los l�mites para la fase 2
        minX = -14f;  // Aumentamos los l�mites en la fase 2
        maxX = 14f;

        // La velocidad en fase 2 es constante y de 25f
        speed = 25f;
        Debug.Log("El Boss ha entrado en la fase 2 y ha restaurado su salud a 100!");

        // Desactivar el GameObject Boss_Weapon
        if (BossWeapon != null)
        {
            BossWeapon.SetActive(false);  // Desactiva el arma del Boss
            Debug.Log("El arma del Boss ha sido desactivada");
        }
        if (walls != null)
        {
            walls.SetActive(false);  // Desactiva el muro
            Debug.Log("muros desactivaos");
        }
    }

    // M�todo para activar la fase 4
    void EnterPhaseFour()
    {
        phase = 4;
        health = 100;  // Restaurar la salud a 100 en la fase 4
        if (healthSlider != null)
        {
            healthSlider.value = health;  // Actualiza la barra de vida
        }
        Debug.Log("El Boss ha entrado en la fase 4 con 100 de vida!");
    }

    // M�todo para reducir la vida del Boss
    public void TakeDamage(int damage)
    {
        health -= damage;  // Resta la vida

        // Actualiza la barra de vida del Slider
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        // El Boss pasa a la fase 2 cuando su vida llega a 0
        if (health <= 0 && phase == 1)
        {
            EnterPhaseTwo();  // El Boss pasa a la fase 2 cuando su vida llega a 0
        }
    }

    //Al final no conseguimos a�adir la fase 3 porque para a�adir las fisicas de salto hay que cambiar el rigidbody de kinematic a dynamic 
    //y eso hace que en el resto fases no funcionen correctamente tambien hay que activar las variables que estan comentadas arriba del todo
    //y en el inspector cambiar la jump force a 380
    //void PhaseThreeBehavior()
    //{
    //    isJumping = true;

    //    rb.velocity = new Vector2(rb.velocity.x, 0);
    //    rb.AddForce(new Vector2(0, JumpForce));
    //}
    //void JumpToPlayer()
    //{
    //    isJumping = true;

    //    rb.velocity = new Vector2(rb.velocity.x, 0);
    //    rb.AddForce(new Vector2(0, JumpForce));
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor"))
    //    {
    //        isJumping = false;

    //        rb.velocity = new Vector2(rb.velocity.x, 0);
    //    }
    //}
}

}


