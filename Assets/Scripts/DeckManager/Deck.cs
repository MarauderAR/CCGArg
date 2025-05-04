using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public Transform playerHandArea;
    public GameObject cardPrefab;
    public int cartasIniciales = 5;

    private DeckManager deckManager;
    private List<GameObject> cartasEnMano = new List<GameObject>();

    private void Start()
    {
        deckManager = GetComponent<DeckManager>();
        if (deckManager == null)
        {
            Debug.LogError("❌ No se encontró el DeckManager");
            return;
        }
        RepartirCartasIniciales();
    }

    public void RepartirCartasIniciales()
    {
        for (int i = 0; i < cartasIniciales; i++)
        {
            RepartirCartaAJugador();
        }
    }

    private void RepartirCartaAJugador()
    {
        if (deckManager.mazoJugador.Count == 0)
        {
            Debug.LogWarning("No quedan cartas en el mazo del jugador");
            return;
        }

        int randomIndex = Random.Range(0, deckManager.mazoJugador.Count);
        ScriptableCard cartaARepartir = deckManager.mazoJugador[randomIndex];
        deckManager.mazoJugador.RemoveAt(randomIndex);

        GameObject cartaGO = Instantiate(cardPrefab, playerHandArea);
        Card cardComponent = cartaGO.GetComponent<Card>();
        if (cardComponent != null)
        {
            cardComponent.SetCardData(cartaARepartir);  // Cambiado de SetupCard a SetCardData
            cartasEnMano.Add(cartaGO);
        }
    }

    public List<GameObject> GetCartasEnMano()
    {
        return cartasEnMano;
    }
}