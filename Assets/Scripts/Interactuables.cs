
using UnityEngine;

public class Interactuables : MonoBehaviour
{
    // Carga el script del Jugador
    public Jugador jugadorScript;
    public HUD hudScript;
    public ControlDeSonidos sounds;

    // Metodo para comprobar que objeto es y su accion
    public void Usar() {
        GameObject go = this.gameObject;
        switch (go.tag){
            case "Recoger":
                if (go.name == "Martillo" && jugadorScript.casaActivada){
                    jugadorScript.martillo = true;
                    hudScript.ElementosHUD(go.name);
                    Destroy(gameObject);
                }
                if (go.name == "Llave" && jugadorScript.martillo){
                    hudScript.ElementosHUD(go.name);
                    jugadorScript.llaves += 1;
                    hudScript.CantidadDeLlaves(jugadorScript.llaves, jugadorScript.llavesTotales);
                    sounds.SFX_Sounds[3].Play();
                    Destroy(gameObject);
                }
                break;
                
            case "Interactuar":
                go.transform.GetComponent<AbrirPuerta>().Estado();
                break;

            case "PuertaPrincipal":
                if (jugadorScript.llaves == 4){
                    go.transform.GetComponent<AbrirPuerta>().Estado();
                }
                break;

            case "Interruptor":
                if (go.name == "Sala") {
                    sounds.SFX_Sounds[4].Play();
                    if (jugadorScript.lucesEstadoSala == false){
                    jugadorScript.lucesEstadoSala = true;
                    } else {
                        jugadorScript.lucesEstadoSala = false;
                    }
                    jugadorScript.EstadoLuces(go.name);
                      
                }
                if (go.name == "Baño") {
                    sounds.SFX_Sounds[4].Play();
                    if (jugadorScript.lucesEstadoBaño == false){
                    jugadorScript.lucesEstadoBaño = true;
                    } else {
                        jugadorScript.lucesEstadoBaño = false;
                    }
                    jugadorScript.EstadoLuces(go.name);
                }
                if (go.name == "Pieza") {
                    sounds.SFX_Sounds[4].Play();
                    if (jugadorScript.lucesEstadoPieza == false){
                    jugadorScript.lucesEstadoPieza = true;
                    } else {
                        jugadorScript.lucesEstadoPieza = false;
                    }
                    jugadorScript.EstadoLuces(go.name);
                }

                break;
                
            default:
                Debug.Log("ERROR");
                break;
        }
        
    } 
}
