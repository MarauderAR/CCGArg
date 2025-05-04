using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [Header("Text Elements")]
    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI descripcionText;
    public TextMeshProUGUI costoText;
    public TextMeshProUGUI influenciaText;
    public TextMeshProUGUI resistenciaText;

    [Header("Image Elements")]
    public Image ilustracionImage;
    public Image tipoCartaImage;

    private ScriptableCard cardData;

    public void SetupCard(ScriptableCard card)
    {
        cardData = card;
        nombreText.text = card.NombreCarta;
        descripcionText.text = card.Descripcion;
        costoText.text = card.CostoPoderPolitico.ToString();
        influenciaText.text = card.Influencia.ToString();
        resistenciaText.text = card.Resistencia.ToString();
        
        if (card.Ilustracion != null)
        {
            ilustracionImage.sprite = card.Ilustracion;
        }
    }

    public ScriptableCard GetCardData()
    {
        return cardData;
    }
}