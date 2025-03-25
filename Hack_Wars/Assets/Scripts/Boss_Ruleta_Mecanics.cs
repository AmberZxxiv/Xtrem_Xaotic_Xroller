using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ruleta_Mecanics : MonoBehaviour
{
    public float speed = 4f;
    public float minX = -9.5f, maxX = 9.5f;
 
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        yield return new WaitForSeconds(Random.Range(0,3));
        speed = Random.Range(4, 15);
        
    }
}
