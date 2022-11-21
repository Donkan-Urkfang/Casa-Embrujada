using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Comenzar(){
        SceneManager.LoadScene("House");
    }

    public void Salir(){
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
