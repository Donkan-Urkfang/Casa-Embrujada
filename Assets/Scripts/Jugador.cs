using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float cordura = 100f;
    public Transform enemigo;

    void Cordura(){
        if (cordura>100){
            if (Vector3.Distance(transform.position, enemigo.transform.position) < 2.5f) {
                cordura -= 0.1f * Time.deltaTime;
                Debug.Log(cordura);
            }            
        }
    }

    private void Update() {
        Cordura();
    }

}
