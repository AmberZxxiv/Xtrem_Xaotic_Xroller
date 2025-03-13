using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PLAYER_MOVEMENT : MonoBehaviour
{
    //public GameObject CoinVaso;
    //public GameObject Ganar;
    //public GameObject Flag;
    public float vel;
    public float jumpForce;
    int _jumpCount;
    Rigidbody2D _rb;
    public GameObject vaultmenu;
    public Slider minimap;
    public float playerPos;
    public TextMeshProUGUI locationText;
    public GameObject playerWeapon;
    public ENEMY_CONTROLLER ENEMY_CONTROLLER;
    public GameObject drop;
    public int _dropCount;

    // Start is called before the first frame update
    void Start()
    {
        vaultmenu.SetActive(false);
        //Ganar.SetActive(false);
        //Flag.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        //_totalCoins = CoinVaso.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.gameObject.transform.position.x;
        minimap.value = playerPos;
        locationText.text = playerPos.ToString("F0");
        float direction = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(vel * direction, _rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount <= 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _jumpCount++;
        }
        else { }
        //if (_coins == _totalCoins)
        //{
        //    Flag.SetActive(true);
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SUELO")
        {
            _jumpCount = 0;
        }
        if (collision.collider.tag == "ENEMYBASE")
        {
            SceneManager.LoadScene(0);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "YOURBASE")
        {
            vaultmenu.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "YOURBASE")
        {
            vaultmenu.SetActive(false);
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "ENEMY" && Input.GetMouseButton(0)) 
        {
            print("BONK");
            other.gameObject.GetComponent<ENEMY_CONTROLLER>().GetDamage();
            //aqui si deja apretao se ejecuta 1000 veces por segundo, añade algun tipo de cooldown crack
        }
        if (other.tag == "DROP")
        {
            _dropCount += 10;
            print(_dropCount);
            Destroy(drop);
        }
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{

    //if (collision.collider.tag == "SPIKE")
    //{
    //    SceneManager.LoadScene(0);
    //}
    //if (collision.collider.tag == "MUELTE")
    //{
    //    SceneManager.LoadScene(0);
    //}

    //}
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "COIN")
    //    {
    //        _coins++;
    //        Destroy(collision.gameObject);
    //    }
    //    if (collision.tag == "FLAG")
    //    {
    //        print("GANASTE NEN@");
    //        SceneManager.LoadScene(0);
    //        Ganar.SetActive(true);
    //    }
    //}
}
