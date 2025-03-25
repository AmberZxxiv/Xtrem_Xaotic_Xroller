using UnityEngine;
using UnityEngine.UI; // Para actualizar la UI si usas un Text para mostrar la moneda
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    public int currency = 5;  // Cantidad inicial de monedas
    public TextMeshProUGUI currencyText;  // Referencia al componente Text de la UI para mostrar las monedas

    // Start se llama antes de que comience el juego
    void Start()
    {
        // Asegúrate de que la UI se actualice al inicio con el valor de la moneda
        UpdateCurrencyUI();
    }

    // Método para aumentar la moneda
    public void CollectDrop()
    {
        currency += 1;  // Aumenta la moneda en 1 cada vez que se recoge un drop
        UpdateCurrencyUI(); // Actualiza la UI para reflejar el cambio
    }

    // Método para mostrar la moneda en la UI
    private void UpdateCurrencyUI()
    {
        if (currencyText != null)
        {
            currencyText.text = "Monedas: " + currency;  // Actualiza el texto en la UI
        }
    }

    // Método opcional para reducir la cantidad de monedas (si es necesario)
    public void SpendCurrency(int amount)
    {
        if (currency >= amount)
        {
            currency -= amount;  // Reducir las monedas
            UpdateCurrencyUI();  // Actualiza la UI después de gastar
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }
}


