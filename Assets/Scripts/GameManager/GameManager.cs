using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Jugadores")]
    public PlayerStats jugador1;
    public PlayerStats jugador2;

    private bool turnoJugador1 = true;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        IniciarTurno();
    }

    private void IniciarTurno()
    {
        if (turnoJugador1)
        {
            jugador1.IniciarTurno();
            Debug.Log("Turno de Jugador 1");
        }
        else
        {
            jugador2.IniciarTurno();
            Debug.Log("Turno de Jugador 2");
        }
    }

    public void FinalizarTurno()
    {
        turnoJugador1 = !turnoJugador1;
        IniciarTurno();
    }
}
