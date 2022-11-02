using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCasa : MonoBehaviour
{
    private bool casa;
    private void OnTriggerEnter(Collider Player) {
        if (Player.CompareTag("Player")){
            casa = true;
        }
    }

    private void Update() {
        
    }
}
