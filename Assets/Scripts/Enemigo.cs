using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform posJugador;

    void SeguirJugador(){
        agent.SetDestination(posJugador.position);
    }

    void Update()
    {
        SeguirJugador();
    }

}
