using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card Collection", menuName = "Cards/Card Collection")]
public class CardCollection : ScriptableObject
{
    [SerializeField] private List<ScriptableCard> cardsInCollection = new List<ScriptableCard>();

    public List<ScriptableCard> CardsInCollection 
    { 
        get { return cardsInCollection; }
        set { cardsInCollection = value; }
    }
}