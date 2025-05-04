using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CartaDetalleUI : MonoBehaviour
{
    public static CartaDetalleUI Instance;

    [Header("Componentes de la UI")]
    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI descripcionText;
    public TextMeshProUGUI ataqueText;
    public TextMeshProUGUI defensaText;
    public Image artImage;

    void Awake()
    {
        // Implementación del patrón Singleton
        Instance = this;
        gameObject.SetActive(false); // El panel comienza oculto
    }

    public void MostrarDetalles(ScriptableCard data)
    {
        if (data == null) return;

        // Asigna los datos de la carta a los elementos de la UI
        nombreText.text = data.NombreCarta;
        descripcionText.text = data.Descripcion;
        ataqueText.text = "Ataque: " + data.Influencia.ToString();
        defensaText.text = "Defensa: " + data.Resistencia.ToString();
        artImage.sprite = data.Ilustracion;

        // Muestra el panel
        gameObject.SetActive(true);
    }

    public void Ocultar()
    {
        // Oculta el panel
        gameObject.SetActive(false);
    }
}