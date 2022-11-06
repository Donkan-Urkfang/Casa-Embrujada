using UnityEngine;

public class ActivarCasa : MonoBehaviour

{
    public GameObject final;
    public GameObject luzSolar;
    public GameObject []puertaPrincipal;
    public GameObject fantasma;
    public Jugador setLuces;
    public void Activar(){
        for (int i=0; i<setLuces.luces.Length; i++){
            setLuces.luces[i].GetComponentInChildren<Light>().color = new Color(0.8301f, 0.6453f, 0.6453f, 1f);
        }
        luzSolar.GetComponentInChildren<Light>().color = Color.red;
        puertaPrincipal[0].GetComponent<AbrirPuerta>().Estado();
        puertaPrincipal[1].GetComponent<AbrirPuerta>().Estado();
        fantasma.SetActive(true);
        final.SetActive(true);


        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponent<MeshRenderer>());

        Debug.Log("Que comience el juego.");
    }
}
