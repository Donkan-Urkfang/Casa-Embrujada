using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform posJugador;
    public Transform salidaDeRaycast;
    public float distanciaRaycast;
    private float esperaAccion = 1f;

    private void Update() {
        Raycast();
    }

    private void FixedUpdate() {
        SeguirJugador();
    }

    void SeguirJugador(){
        agent.SetDestination(posJugador.position);
    }

    void Raycast(){
        Debug.DrawRay(salidaDeRaycast.position, salidaDeRaycast.forward * distanciaRaycast, Color.red);
        RaycastHit golpe;
        if (esperaAccion<=0){
            if (Physics.Raycast(salidaDeRaycast.position, salidaDeRaycast.forward, out golpe, distanciaRaycast, LayerMask.GetMask("Interactuable"))) {
            golpe.transform.GetComponent<AbrirPuerta>().Estado();
            esperaAccion=1f;
            }
        } else {
            esperaAccion -= 0.2f * Time.deltaTime;
        }
        
    }
}
