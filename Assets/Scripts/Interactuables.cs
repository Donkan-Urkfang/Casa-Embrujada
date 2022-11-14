
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

            case "Interruptor":
                if (go.name == "Sala") {
                    sounds.SFX_Sounds[4].Play();
                    if (script.lucesEstadoSala == false){
                    script.lucesEstadoSala = true;
                    } else {
                        script.lucesEstadoSala = false;
                    }
                    script.EstadoLuces(go.name);
                      
                }
                if (go.name == "Baño") {
                    sounds.SFX_Sounds[4].Play();
                    if (script.lucesEstadoBaño == false){
                    script.lucesEstadoBaño = true;
                    } else {
                        script.lucesEstadoBaño = false;
                    }
                    script.EstadoLuces(go.name);
                }
                if (go.name == "Pieza") {
                    sounds.SFX_Sounds[4].Play();
                    if (script.lucesEstadoPieza == false){
                    script.lucesEstadoPieza = true;
                    } else {
                        script.lucesEstadoPieza = false;
                    }
                    script.EstadoLuces(go.name);
                }

                break;
                
            default:
                Debug.Log("ERROR");
                break;
        }
        
    } 
}
