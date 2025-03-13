using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_CONTROLLER : MonoBehaviour
{
    public float enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage()
    {
        enemyHealth -= 2;
    }
}
