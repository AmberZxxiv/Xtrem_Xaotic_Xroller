using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Parámetros de Movimiento")]
    public float setSpeed;       // Velocidad de movimiento horizontal
    float actualSpeed;
    public float jumpForce;   // Fuerza aplicada al saltar

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador está en el suelo
    private Vector2 lastMoveDirection = Vector2.right; // Última dirección de movimiento

    public GameObject bulletPrefab;
    public Transform firePoint; // Un GameObject vacío donde se originan las balas
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

        // Actualizar la última dirección de movimiento si hay input del jugador
        if (moveInput > 0)
            lastMoveDirection = Vector2.right;
        else if (moveInput < 0)
            lastMoveDirection = Vector2.left;

        // Salto: se activa cuando se presiona la tecla "Salto" y el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Disparar continuamente mientras el clic izquierdo esté presionado
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Botón izquierdo del ratón
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

    // Comprueba si el jugador está en contacto con el suelo mediante colisiones
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
}
