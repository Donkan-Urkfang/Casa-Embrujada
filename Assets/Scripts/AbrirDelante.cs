using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirDelante : MonoBehaviour
{
    public bool open = false;

    public Vector3 puertaAbiertaAngulo = new Vector3(1f,1f,1f);
    private Transform puertaCerradaAngulo;
    public float velocidad = 1.0f;
    private float startTime;
    private float journeyLenght;

    private void Start() {
        startTime = Time.time;
        puertaCerradaAngulo = transform;
        journeyLenght = Vector3.Distance(puertaCerradaAngulo.position, puertaAbiertaAngulo);
    }

    private void Update() {
        if (open){
            float distanciaRecorrida = (Time.time - startTime) * velocidad;
            float fractionOfJourney = distanciaRecorrida / journeyLenght;
            transform.position = Vector3.Lerp(puertaCerradaAngulo.position, puertaAbiertaAngulo, fractionOfJourney);
        } /* else {
            float distanciaRecorrida = (relentizacion * Time.deltaTime);
            transform.position = Vector3.Lerp(puertaAbiertaAngulo.position, puertaCerradaAngulo.position, distanciaRecorrida);
        } */
    }

}