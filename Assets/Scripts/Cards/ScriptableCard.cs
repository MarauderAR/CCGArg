using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class ScriptableCard : ScriptableObject
{
    [SerializeField] private string nombreCarta;
    [SerializeField] private string descripcion;
    [SerializeField] private int costoPoderPolitico;
    [SerializeField] private int influencia;
    [SerializeField] private int resistencia;
    [SerializeField] private Sprite ilustracion;

    public string NombreCarta 
    { 
        get { return nombreCarta; }
        set { nombreCarta = value; }
    }

    public string Descripcion 
    { 
        get { return descripcion; }
        set { descripcion = value; }
    }

    public int CostoPoderPolitico 
    { 
        get { return costoPoderPolitico; }
        set { costoPoderPolitico = value; }
    }

    public int Influencia 
    { 
        get { return influencia; }
        set { influencia = value; }
    }

    public int Resistencia 
    { 
        get { return resistencia; }
        set { resistencia = value; }
    }

    public Sprite Ilustracion 
    { 
        get { return ilustracion; }
        set { ilustracion = value; }
    }
}