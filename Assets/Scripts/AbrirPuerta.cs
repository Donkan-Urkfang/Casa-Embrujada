using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public ControlDeSonidos sounds;
    public float puertaAbiertaAngulo;
    public float puertaCerradaAngulo = 0.0f;
    public float relentizacion = 3.0f;
    public bool activar;

    public void Check() {
        if (activar){
            Quaternion targetRotation = Quaternion.Euler(0, puertaAbiertaAngulo, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, relentizacion * Time.deltaTime);
        } else {
            Quaternion targetRotation2 = Quaternion.Euler(0, puertaCerradaAngulo, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, relentizacion * Time.deltaTime);
        }
    }
    
    public void Estado() {
        sounds.SFX_Sounds[2].Play();
        activar = !activar;
    }

    public void Update() {
        Check();
    }
}