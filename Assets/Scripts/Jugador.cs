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
    public float distanciaRaycast;
    private float parpadeo = 10f;
    private float IntencidadLinternaEstandar;
    private float IntencidadLucesEstandar;
    public GameObject []luces;
    public GameObject []puertaPrincipal;
    public GameObject enemigo;
    public GameObject comienzo;
    public GameObject final; 
    public GameObject luzSolar; 
    public Transform salidaDeRaycast;
    public ControlDeSonidos sounds;

    private void Update() {
        Cordura();
        Luces();
        Raycast();
    }

    IEnumerator Parpadeo(int repeticiones)
    {
		for (int i=0; i<repeticiones; i++) {
            sounds.SFX_Sounds[4].Play();
            gameObject.GetComponentInChildren<Light>().intensity = Random.Range(1f, 10f);
            for (int x=0; x<luces.Length; x++)
            {
                luces[x].GetComponentInChildren<Light>().intensity = Random.Range(0.1f, 4f);
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
                IntencidadLucesEstandar = 5f;
            } 
            else if (cordura>40f){
                DañoFantasma();
                IntencidadLinternaEstandar = 10f;
                IntencidadLucesEstandar = 3f;
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
                sounds.SFX_Sounds[1].Play();
                StartCoroutine(Parpadeo(10));
            }
        }
        
        
    }

    void Raycast(){
        Debug.DrawRay(salidaDeRaycast.position, salidaDeRaycast.forward * distanciaRaycast, Color.red);
        if (Input.GetKeyDown(KeyCode.E)){
            RaycastHit golpe;
            if (Physics.Raycast(salidaDeRaycast.position, salidaDeRaycast.forward, out golpe, distanciaRaycast, LayerMask.GetMask("Interactuable"))) {
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
        switch (other.name){
            case "Adentro":
                adentroDeCasa = true;
                break;
            case "Afuera":
                adentroDeCasa = false;
                break;
            case "Comienza":
                ActivarCasa();
                break;
            case "Final":
                DesactivarCasa();
                break;
        }
    }

    void ActivarCasa(){
        for (int i=0; i<luces.Length; i++){
                luces[i].GetComponentInChildren<Light>().color = new Color(0.8301f, 0.6453f, 0.6453f, 1f);
        }
        llaves = 0;
        luzSolar.GetComponentInChildren<Light>().color = new Color(0.6603f, 0.6254f, 0.6254f, 1f);
        puertaPrincipal[0].GetComponent<AbrirPuerta>().Estado();
        puertaPrincipal[1].GetComponent<AbrirPuerta>().Estado();
        enemigo.SetActive(true);
        final.SetActive(true);
        casaActivada = true;
        sounds.SFX_Sounds[1].Play();
        Debug.Log("Que comience el juego."); 
        comienzo.SetActive(false);       
    }

    void DesactivarCasa(){
        enemigo.SetActive(false);
        casaActivada = false;
        sounds.SFX_Sounds[0].Stop();
        sounds.SFX_Sounds[1].Stop();
        sounds.SFX_Sounds[5].Play();
        luzSolar.GetComponentInChildren<Light>().color = Color.white;

        Debug.Log("Juego terminado. Felicitaciones!");
        final.SetActive(false);
    }

    void Reset(){
        if (cordura <= 0){
            SceneManager.LoadScene("House");
        }
    }
}