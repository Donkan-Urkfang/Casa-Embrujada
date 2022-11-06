using UnityEngine;

public class DesactivarCasa : MonoBehaviour
{
    public GameObject fantasma;
    public Jugador casa;
    public ControlDeSonidos sounds;

    private void OnTriggerEnter(Collider other) {
        fantasma.SetActive(false);
        casa.casaActivada = false;
        sounds.SFX_Sounds[0].Stop();
        sounds.SFX_Sounds[1].Stop();
        sounds.SFX_Sounds[5].Play();
        Debug.Log("Juego terminado. Felicitaciones!");
    }
}
