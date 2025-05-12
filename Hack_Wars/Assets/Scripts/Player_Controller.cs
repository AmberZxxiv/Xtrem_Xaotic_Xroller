using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    [Header("Parámetros de Movimiento")]
    public float setSpeed;       // Velocidad de movimiento horizontal
    float actualSpeed;
    public float jumpForce;   // Fuerza aplicada al saltar

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador está en el suelo
    private Vector2 lastMoveDirection = Vector2.right; // Última dirección de movimiento

    public GameObject pause;
    private GameObject victory;
    private GameObject dead;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint; // Un GameObject vacío donde se originan las balas
    public float fireRate = 0.1f; // Tiempo entre disparo
    private float nextFireTime = 0f;

    SpriteRenderer playerSpriteRenderer;

    public float vidasPlayer;
    public Slider playerHealth;
    public Slider bossHealth;
    public int tokenCount;
    public TextMeshProUGUI tokenInventory;
    public bool premio1;
    public bool premio2;
    public bool premio3;
    public bool premio4;
    public int token_YoN;

    void Start()
    {
        // Obtiene los componentes del jugador
        rb = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        actualSpeed = setSpeed;
        vidasPlayer = 5;
        premio1 = false;
        premio2 = false;
        premio3 = false;
        pause.SetActive(false);
        dead.SetActive(false);
        victory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }

        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * actualSpeed, rb.velocity.y);
        playerHealth.value = vidasPlayer;

        // Actualizar la última dirección de movimiento si hay input del jugador
        if (moveInput > 0)
        {
            if (animator.GetBool("Walking") == false)
            {
                animator.SetBool("Walking", true);
            }
            if (!playerSpriteRenderer.flipX)
            {

                playerSpriteRenderer.flipX = true;
            }
            lastMoveDirection = Vector2.right;
        }
        else if (moveInput < 0)
        {
            if (animator.GetBool("Walking") == false)
            {
                animator.SetBool("Walking", true);
            }
            if (playerSpriteRenderer.flipX)
            {

                playerSpriteRenderer.flipX = false;
            }
            lastMoveDirection = Vector2.left;
        }
        // Salto: se activa cuando se presiona la tecla "Salto" y el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jumping");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Disparar continuamente mientras el clic izquierdo esté presionado
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Botón izquierdo del ratón
        {
            animator.SetTrigger("Shot");
            Shoot();
            nextFireTime = Time.time + fireRate; // Establece el tiempo para el siguiente disparo
        }

        // Si se mantiene presionado Shift, el jugador se detiene
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed = 0;
        }
        else
        {
            actualSpeed = setSpeed;
        }
        if(vidasPlayer == 0)
        {
            SceneManager.LoadScene(0);
        }

        // Le da tokens al jugador cuando llega a X vida del boss
        if (bossHealth.value <= 66 && premio1 == false)
        {
            tokenCount++;
            premio1 = true;
            tokenInventory.text = tokenCount.ToString("Tokens = "+tokenCount);
        }
        if (bossHealth.value <= 33 && premio2 == false)
        {
            tokenCount++;
            premio2 = true;
            tokenInventory.text = tokenCount.ToString("Tokens = " + tokenCount);
        }
        if (bossHealth.value <= 0 && premio3 == false)
        {
            tokenCount++;
            premio3 = true;
            tokenInventory.text = tokenCount.ToString("Tokens = " + tokenCount);
        }
    }

    // Comprueba si el jugador está en contacto con el suelo mediante colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        // El suelo debe tener la etiqueta "Ground"
        if (collision.gameObject.CompareTag("Floor") )
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("voidead"))
        {
            vidasPlayer--;
            this.gameObject.transform.position = new Vector2(0,1);
        }
    }

    // Cuando el jugador deja de estar en contacto con el suelo, se marca como no en el suelo
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossWeapon"))
        {
            animator.SetTrigger("Damaged");
            vidasPlayer--;
        }
    }

    void Shoot()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Asegurarse de que esté en el mismo plano 2D

        // Crear la bala en la posición del jugador (o firePoint si lo prefieres)
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // Calcular la dirección desde el jugador hacia el ratón
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        // Asignar la dirección de la bala
        bulletScript.direction = shootDirection;

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
}