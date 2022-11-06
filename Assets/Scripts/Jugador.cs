using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    //Empieza el juego
    public bool casaActivada;
    public bool adentroDeCasa;
    // Variables de Objetos recogidos
    public bool martillo;
    public int llaves;


    public float cordura = 100f;
    public Transform enemigo;
    public Transform camara;
    public float distanciaRaycast;
    private float parpadeo = 10f;
    public GameObject []luces;
    private float IntencidadLinternaEstandar;
    private float IntencidadLucesEstandar;

    private void Update() {
        Cordura();
        Luces();
        Raycast();
    }

    IEnumerator Parpadeo(int repeticiones)
    {
		for (int i=0; i<repeticiones; i++) {
            gameObject.GetComponentInChildren<AudioSource>().Play();
            gameObject.GetComponentInChildren<Light>().intensity = Random.Range(1f, 10f);
            for (int x=0; x<luces.Length; x++)
            {
                luces[x].GetComponentInChildren<Light>().intensity = Random.Range(0.1f, 2f);
            }
        	yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
		}
        gameObject.GetComponentInChildren<Light>().intensity = IntencidadLinternaEstandar;
        luces[0].GetComponentInChildren<Light>().intensity = IntencidadLucesEstandar;
    }

    void DañoFantasma(){
                if (Vector3.Distance(enemigo.transform.position, transform.position) < 1f) {
                    cordura -= 1f * Time.deltaTime;
                } 
                else if (Vector3.Distance(enemigo.transform.position, transform.position) < 3f) {
                    cordura -= 0.5f * Time.deltaTime;
                } 
                else if (Vector3.Distance(enemigo.transform.position, transform.position) < 7f) {
                    cordura -= 0.25f * Time.deltaTime;
                }
    }
    void Cordura(){
        if (casaActivada){
            if (cordura>70f){
                DañoFantasma();
                IntencidadLinternaEstandar = 12f;
                IntencidadLucesEstandar = 3f;
            } 
            else if (cordura>40f){
                DañoFantasma();
                IntencidadLinternaEstandar = 10f;
                IntencidadLucesEstandar = 2f;
            } 
            else if (cordura>0f){
                DañoFantasma();
                IntencidadLinternaEstandar = 6f;
                IntencidadLucesEstandar = 1f;
            } 
            else if (cordura<=0f){
                Reset();
            }
        }
    }

    void Luces(){
        if (casaActivada){ 
            parpadeo -= 0.5f * Time.deltaTime;
            if (parpadeo<0) {
                parpadeo = Random.Range(10f, 15f);
                StartCoroutine(Parpadeo(10));
            }
        }
        
        
    }

    void Raycast(){
        Debug.DrawRay(camara.position, camara.forward * distanciaRaycast, Color.red);
        if (Input.GetKeyDown(KeyCode.E)){
            RaycastHit golpe;
            if (Physics.Raycast(camara.position, camara.forward, out golpe, distanciaRaycast, LayerMask.GetMask("Interactuable"))) {
                golpe.transform.GetComponent<Interactuables>().Usar();
            }
        }
    }

    void ObjetosRecogidos(string objeto){
        switch (objeto){
            case "Martillo":
                martillo = true;
                break;
            case "Llave":
                llaves = 4;
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Adentro"){
            adentroDeCasa = true;
        } else {
            adentroDeCasa = false;
        }
    }

    void Reset(){
        if (cordura <= 0){
            SceneManager.LoadScene("House");
        }
    }
}