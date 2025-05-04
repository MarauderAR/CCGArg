using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    [Header("Mazo Base")]
    public CardCollection mazoBase; // Asset de mazo básico

    public List<ScriptableCard> mazoJugador = new();
    public List<ScriptableCard> mazoEnemigo = new();

    private void Start()
    {
        CrearMazos();
    }

    public void CrearMazos()
    {
        if (mazoBase == null || mazoBase.CardsInCollection == null || mazoBase.CardsInCollection.Count == 0)
        {
            Debug.LogError("❌ El mazo base es nulo o está vacío. No se pueden crear mazos.");
            return;
        }
        mazoJugador = new List<ScriptableCard>(mazoBase.CardsInCollection);
        mazoEnemigo = new List<ScriptableCard>(mazoBase.CardsInCollection);
        Debug.Log($"✅ Mazos creados con {mazoJugador.Count} cartas para el jugador y {mazoEnemigo.Count} cartas para el enemigo.");
    }
}