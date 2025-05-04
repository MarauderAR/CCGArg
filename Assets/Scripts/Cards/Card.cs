using UnityEngine;

public class Card : MonoBehaviour
{
    private ScriptableCard cardData;
    private CardUI cardUI;

    private void Awake()
    {
        cardUI = GetComponent<CardUI>();
        if (cardUI == null)
        {
            Debug.LogError("❌ No se encontró el componente CardUI");
        }
    }

    public void SetupCard(ScriptableCard scriptableCard)
    {
        if (scriptableCard == null)
        {
            Debug.LogError("❌ SetupCard recibió un ScriptableCard nulo");
            return;
        }

        Debug.Log($"🎴 Configurando carta: {scriptableCard.NombreCarta}");
        cardData = scriptableCard;
        cardUI.SetupCard(cardData);
    }

    public ScriptableCard GetCardData()
    {
        return cardData;
    }
}