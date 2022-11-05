using UnityEngine;

public class ActivarCasa : MonoBehaviour

{
    public GameObject []luces;
    public GameObject luzSolar;
    public GameObject []puertaPrincipal;
    public GameObject fantasma;
    public void Activar(){
        for (int i=0; i<luces.Length; i++){
            luces[i].GetComponentInChildren<Light>().color = new Color(0.8113f, 0.5158f, 0.5158f, 1f);
        }
        luzSolar.GetComponentInChildren<Light>().color = Color.red;
        puertaPrincipal[0].GetComponent<AbrirPuerta>().Estado();
        puertaPrincipal[1].GetComponent<AbrirPuerta>().Estado();
        fantasma.SetActive(true);

        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponent<MeshRenderer>());
    }
}
