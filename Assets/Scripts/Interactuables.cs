
using UnityEngine;

public class Interactuables : MonoBehaviour
{
    // Carga el script del Jugador
    public Jugador script;
    public ControlDeSonidos sounds;

    // Metodo para comprobar que objeto es y su accion
    public void Usar() {
        GameObject go = this.gameObject;
        switch (go.tag){
            case "Recoger":
                if (go.name == "Martillo" && script.casaActivada){
                    script.martillo = true;
                    Destroy(gameObject);
                }
                if (go.name == "Llave" && script.martillo){
                    script.llaves += 1;
                    sounds.SFX_Sounds[3].Play();
                    sounds.SFX_Sounds[1].Play();
                    Destroy(gameObject);
                }
                break;
                
            case "Interactuar":
                go.transform.GetComponent<AbrirPuerta>().Estado();
                break;

            case "PuertaPrincipal":
                if (script.llaves == 4){
                    go.transform.GetComponent<AbrirPuerta>().Estado();
                }
                break;
                
            case "Trigger":
                if (go.name == "Comienza") {
                    script.casaActivada = true;
                    script.llaves = 0;
                    go.transform.GetComponent<ActivarCasa>().Activar();
                }
                break;
                
            default:
                Debug.Log("ERROR");
                break;
        }
        
    } 
}
