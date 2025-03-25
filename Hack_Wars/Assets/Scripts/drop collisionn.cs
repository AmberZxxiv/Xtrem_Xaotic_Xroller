using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Cuando el jugador recoja el drop (detectando una colisi�n con el jugador)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si es el jugador el que toc� el drop
        if (other.CompareTag("Player"))
        {
            // Depuraci�n para saber cu�ndo y cu�ntas veces ocurre la colisi�n
            Debug.Log("Drop recogido por: " + other.gameObject.name);

            // Intentar obtener el CurrencyManager del jugador
            CurrencyManager currencyManager = other.gameObject.GetComponent<CurrencyManager>();

            // Verificar si se encontr� el CurrencyManager
            if (currencyManager != null)
            {
                currencyManager.CollectDrop(); // Aumentar la moneda
                Destroy(gameObject); // Destruir el objeto drop para que no se recoja m�s de una vez
            }
            else
            {
                Debug.LogError("CurrencyManager no encontrado en el jugador.");
            }
        }
    }
}


