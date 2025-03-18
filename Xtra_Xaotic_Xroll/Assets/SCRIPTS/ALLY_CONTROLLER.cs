using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALLY_CONTROLLER : MonoBehaviour
{
    public float allyHealth;
    // Start is called before the first frame update
    void Start()
    {
        allyHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (allyHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void GetDamage()
    {
        allyHealth -= 2;
    }


}
