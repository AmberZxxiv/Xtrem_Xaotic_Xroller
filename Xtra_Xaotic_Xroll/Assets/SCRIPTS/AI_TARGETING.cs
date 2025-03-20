using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_TARGETING : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("ENEMY")) // Comportamientos de enemigos
        {
        this.gameObject.transform.Translate(-2 * Time.deltaTime, 0, 0);
        }
        if (CompareTag("ALLY")) // Comportamietos de aliados
        {
            this.gameObject.transform.Translate(2 * Time.deltaTime, 0, 0);
        }
    }
}
