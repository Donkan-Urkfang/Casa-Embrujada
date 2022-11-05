
using UnityEngine;

public class Interactuables : MonoBehaviour
{
    // Carga el script del Jugador
    public MoverObjetos script;

    // Metodo para comprobar que objeto es y su accion
    public void Usar() {
        GameObject go = this.gameObject;
        switch (go.tag){
            case "Recoger":
                if (go.name == "Martillo"){
                    script.martillo = true;
                    Destroy(gameObject);
                }
                if (go.name == "Llave" && script.martillo){
                    script.llaves += 1;
                    Destroy(gameObject);
                }
                break;

            case "Destruir":
                if (script.martillo) {
                    Destroy(gameObject);
                }
                break;

            case "Animar":
                Animator anim = go.GetComponent<Animator>();
                anim.SetInteger("Activar", 1);
                Debug.Log(anim);
                break;
            
            case "Interactuar":
                go.transform.GetComponent<AbrirPuerta>().Estado();
                break;

            case "PuertaPrincipal":
                if (script.llaves == 4){
                    go.transform.GetComponent<AbrirPuerta>().Estado();
                }
                break;

            default:
                Debug.Log("ERROR");
                break;
        }  
    } 
}
