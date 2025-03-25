using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALLY_SPAWNER : MonoBehaviour
{
    public GameObject allyprefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GenerateAlly()
    {
        // Generar el enemigo en la posición del spawner
        Instantiate(allyprefab, transform.position, Quaternion.identity);
    }
}