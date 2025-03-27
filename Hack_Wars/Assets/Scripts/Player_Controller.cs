using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Par�metros de Movimiento")]
    public float setSpeed;       // Velocidad de movimiento horizontal
    float actualSpeed;
    public float jumpForce;   // Fuerza aplicada al saltar

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador est� en el suelo
    private Vector2 lastMoveDirection = Vector2.right; // �ltima direcci�n de movimiento

    public GameObject bulletPrefab;
    public Transform firePoint; // Un GameObject vac�o donde se originan las balas
    public float fireRate = 0.1f; // Tasa de disparo (tiempo entre disparos)
    private float nextFireTime = 0f;

    void Start()
    {
        // Obtiene el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
        actualSpeed = setSpeed;
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * actualSpeed, rb.velocity.y);

        // Actualizar la �ltima direcci�n de movimiento si hay input del jugador
        if (moveInput > 0)
            lastMoveDirection = Vector2.right;
        else if (moveInput < 0)
            lastMoveDirection = Vector2.left;

        // Salto: se activa cuando se presiona la tecla "Salto" y el jugador est� en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Disparar continuamente mientras el clic izquierdo est� presionado
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Bot�n izquierdo del rat�n
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Establece el tiempo para el siguiente disparo
        }

        // Si se mantiene presionado LeftShift, el jugador se detiene
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed = 0;
        }
        else
        {
            actualSpeed = setSpeed;
        }
    }

    // Comprueba si el jugador est� en contacto con el suelo mediante colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        // El suelo debe tener la etiqueta "Floor"
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
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

    void Shoot()
    {
        // Obtener la posici�n del rat�n en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Asegurarse de que est� en el mismo plano 2D

        // Crear la bala en la posici�n del jugador (o firePoint si lo prefieres)
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // Calcular la direcci�n desde el jugador hacia el rat�n
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        // Asignar la direcci�n de la bala
        bulletScript.direction = shootDirection;
    }
}
