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
    public int llavesTotales;

    public float cordura = 100f;
    public float distanciaRaycast;
    private float parpadeo = 10f;
    private float IntencidadLinternaEstandar;
    private float IntencidadLucesEstandar;
    public bool lucesEstadoSala;
    public bool lucesEstadoBaño;
    public bool lucesEstadoPieza;
    public HUD hudScript;
    public GameObject hud;
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
                if (luces[x].GetComponentInChildren<Light>().intensity > 0f) {
                    luces[x].GetComponent<Renderer>().material.SetColor ("_Emission", Color.white);
                } else {
                    luces[x].GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
                }
            }
        	yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
		}
        gameObject.GetComponentInChildren<Light>().intensity = IntencidadLinternaEstandar;
        EstadoLuces("Sala");
        EstadoLuces("Baño");
        EstadoLuces("Pieza");
    }

    void DañoFantasma(){
                if (Vector3.Distance(enemigo.transform.position, transform.position) < 1f) {
                    cordura -= 2f * Time.deltaTime;
                } 
                else if (Vector3.Distance(enemigo.transform.position, transform.position) < 3f) {
                    cordura -= 1f * Time.deltaTime;
                } 
                else if (Vector3.Distance(enemigo.transform.position, transform.position) < 7f) {
                    cordura -= 0.5f * Time.deltaTime;
                }
    }
    void Cordura(){
        if (casaActivada){
            if (cordura>70f){
                DañoFantasma();
                IntencidadLinternaEstandar = 12f;
            } 
            else if (cordura>40f){
                DañoFantasma();
                IntencidadLinternaEstandar = 10f;
            } 
            else if (cordura>0f){
                DañoFantasma();
                IntencidadLinternaEstandar = 6f;
            } 
            else if (cordura<=0f){
                Reset();
            }
            hudScript.Cordura(cordura);
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

    public void EstadoLuces(string lugar){
        if (lucesEstadoSala){
            for (int i = 5; i>-1; i--) {
                luces[i].GetComponentInChildren<Light>().intensity = 0f;
                luces[i].GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
                } 
        } else {
            for (int i = 5; i>-1; i--) {
                luces[i].GetComponentInChildren<Light>().intensity = 5f;
                luces[i].GetComponent<Renderer>().material.SetColor ("_Emission", Color.white);
            }
        }

        if (lucesEstadoBaño){
            for (int i = 7; i>5; i--) {
                luces[i].GetComponentInChildren<Light>().intensity = 0f;
                luces[i].GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
                } 
        } else {
            for (int i = 7; i>5; i--) {
                luces[i].GetComponentInChildren<Light>().intensity = 5f;
                luces[i].GetComponent<Renderer>().material.SetColor ("_Emission", Color.white);
            }
        }

        if (lucesEstadoPieza){
            for (int i = 9; i>7; i--) {
                luces[i].GetComponentInChildren<Light>().intensity = 0f;
                luces[i].GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
                } 
        } else {
            for (int i = 9; i>7; i--) {
                luces[i].GetComponentInChildren<Light>().intensity = 5f;
                luces[i].GetComponent<Renderer>().material.SetColor ("_Emission", Color.white);
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
        hud.SetActive(true);
        llaves = 0;
        llavesTotales = 4;
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
        hud.SetActive(false);
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
        
    public void MenuPrincipal(){
            SceneManager.LoadScene("Menu");
    }
}