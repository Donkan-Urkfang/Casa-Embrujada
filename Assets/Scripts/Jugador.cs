using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    //Empieza el juego
    public bool casaActivada;
    // Variables de Objetos recogidos
    public bool martillo;
    public int llaves;


    public float cordura = 100f;
    public Transform enemigo;


    //Interactuar

    public Transform camara;
    public float distanciaRaycast;

    private void Update() {
        Cordura();
    } 

    private void FixedUpdate() {
        Raycast();
    }


    void Cordura(){
        if (casaActivada){
            if (cordura>0f){
                if (Vector3.Distance(enemigo.transform.position, transform.position) < 1f) {
                    cordura -= 2f * Time.deltaTime;
                } else if (Vector3.Distance(enemigo.transform.position, transform.position) < 3f) {
                    cordura -= 1f * Time.deltaTime;
                } else if (Vector3.Distance(enemigo.transform.position, transform.position) < 7f) {
                    cordura -= 0.5f * Time.deltaTime;
                }        
            } else if (cordura<=0f){
                Reset();
            }
        }
    }

    void Raycast(){
        Debug.DrawRay(camara.position, camara.forward * distanciaRaycast, Color.red);
        if (Input.GetKeyDown(KeyCode.E)){
            RaycastHit golpe;
            if (Physics.Raycast(camara.position, camara.forward, out golpe, distanciaRaycast, LayerMask.GetMask("Interactuable"))) {
                golpe.transform.GetComponent<Interactuables>().Usar();
                Debug.Log(golpe.transform);
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

    void Reset(){
        if (cordura <= 0){
            SceneManager.LoadScene("House");
        }
    }
}