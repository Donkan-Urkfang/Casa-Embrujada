using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject hudInGame;
    public GameObject hudPausa;
    public Jugador scriptJugador;
    public bool pausa;
    public Image martilloIMG;
    public Image llaveIMG;
    public Image muerte;
    public TextMeshProUGUI textoLlaves;
    public Slider barraDeCordura;
    public GameObject audioManager;

    IEnumerator Iconos(Image elemento)
    {
		for (int i=0; i<100; i++) {
            elemento.color = new Color(1f, 1f, 1f, (i/100f));
        	yield return new WaitForSeconds(0.05f);
		}
    }

    public void ElementosHUD(string elemento){
        switch (elemento) {
            case "Martillo":
                StartCoroutine(Iconos(martilloIMG));
                break;
            case "Llave":
                StartCoroutine(Iconos(llaveIMG));
                break;
        }
    }

    public void CantidadDeLlaves(int llaves, int llavesTotales){
        textoLlaves.text = llaves + "/" + llavesTotales;
    }

    public void Cordura(float cordura){
        barraDeCordura.value = cordura / 100;
        muerte.color = new Color(0f,0f,0f, -(cordura/100-1));
    }

    public void Pausa(){
            pausa = !pausa;
    }

    void Estado(){
        if (Input.GetKeyDown(KeyCode.P)){
            Pausa();
        }
        if (pausa){
            hudInGame.SetActive(false);
            hudPausa.SetActive(true);

            muerte.color = new Color(0f,0f,0f, 0.5f);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        } else {
            if (scriptJugador.casaActivada == true){
                hudInGame.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            hudPausa.SetActive(false);
            muerte.color = new Color(0f,0f,0f, 0f);
            Time.timeScale = 1;
        }
    }

    private void Update() {
        Estado();
    }
}
