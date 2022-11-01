
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
                break;

            case "Destruir":
                if (script.martillo) {
                    Destroy(gameObject);
                }
                break;

            case "animar":
                break;
        }  
    } 
}
