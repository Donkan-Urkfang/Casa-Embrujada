using UnityEngine;

public class ControlDeSonidos : MonoBehaviour
{
    public Jugador script;
    public AudioSource []SFX_Sounds;
    public AudioSource []Amb_Sounds;

    private void Start() {

    }

    void ambiente(){
        if (script.adentroDeCasa){
            Amb_Sounds[0].volume = 0.3f;
        } else {
            Amb_Sounds[0].volume = 1f;
        }
    }
    void respiracion(){
        if (script.casaActivada){
            SFX_Sounds[0].volume = 0.7f;
        }
    }

    private void FixedUpdate() {
        ambiente();
        respiracion();
    }
}
