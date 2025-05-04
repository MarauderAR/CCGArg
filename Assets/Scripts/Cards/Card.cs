using UnityEngine;
using UnityEngine.EventSystems; // Necesario para IPointerClickHandler

// Añadimos la interfaz IPointerClickHandler para detectar clics
public class Card : MonoBehaviour, IPointerClickHandler
{
    public ScriptableCard cardData; // Los datos de esta carta específica
    private CardUI cardUI;
    private CardZoomManager zoomManager; // Referencia al manager de zoom

    private void Awake()
    {
        cardUI = GetComponent<CardUI>();
        if (cardUI == null)
        {
            Debug.LogError($"Error en la carta '{gameObject.name}': No se encontró el componente CardUI.");
        }
    }

    private void Start()
    {
        // Buscar el CardZoomManager en la escena al iniciar
        // FindFirstObjectByType es más moderno que FindObjectOfType
        zoomManager = FindFirstObjectByType<CardZoomManager>();
        if (zoomManager == null)
        {
            Debug.LogError("¡ERROR CRÍTICO! No se encontró ninguna instancia de CardZoomManager en la escena.");
        }

        // Configurar la UI inicial si hay datos
        if (cardData != null && cardUI != null)
        {
            cardUI.Setup(cardData);
        }
        else if(cardData == null)
        {
             Debug.LogWarning($"Advertencia en la carta '{gameObject.name}': No tiene cardData asignado en Start.");
        }
    }

    public ScriptableCard GetCardData()
    {
        return cardData;
    }

    // Esta función es llamada por SetCardData y potencialmente desde otros sitios
    private void UpdateCardUI()
    {
         if (cardData != null && cardUI != null)
        {
            cardUI.Setup(cardData);
        }
        else
        {
             Debug.LogWarning($"UpdateCardUI: No se pudo actualizar UI para '{gameObject.name}'. cardData o cardUI es null.");
        }
    }


    public void SetCardData(ScriptableCard newCardData)
    {
        cardData = newCardData;
        // Llama a una función separada para actualizar la UI
        UpdateCardUI();
    }

    // --- ¡NUEVA FUNCIÓN! Se ejecuta cuando se hace clic sobre esta carta ---
    public void OnPointerClick(PointerEventData eventData)
    {
        // Log para confirmar que el clic se detecta en esta carta específica
        Debug.Log($"Clic detectado en la carta: {(cardData != null ? cardData.NombreCarta : "SIN DATOS")}");

        // Verificar si tenemos la referencia al Zoom Manager y si esta carta tiene datos
        if (zoomManager != null && cardData != null)
        {
            // Log justo antes de llamar a ShowCard
            Debug.Log(">>> Intentando llamar a ShowCard desde Card.OnPointerClick...");

            // ¡Aquí es donde finalmente llamamos al Zoom Manager!
            zoomManager.ShowCard(cardData);
        }
        else
        {
            // Logs de error para saber qué falló
            if (zoomManager == null)
            {
                Debug.LogError("¡ERROR en OnPointerClick! No se encontró referencia a CardZoomManager.");
            }
            if (cardData == null)
            {
                Debug.LogError("¡ERROR en OnPointerClick! La carta clickeada no tiene 'cardData' asignado.");
            }
        }
    }
}
