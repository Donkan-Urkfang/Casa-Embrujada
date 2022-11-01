using UnityEngine;

public class MoverObjetos : MonoBehaviour
{
    // Variables de Objetos recogidos
    public bool martillo;


    public Transform camara;
    public float distanciaRaycast;

    private void Update() {
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
            case "Bola":
            break;
        }
    }
}
