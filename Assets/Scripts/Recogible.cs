using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recogible : MonoBehaviour
{
    public void Usar() {
        Destroy(this.gameObject);
    }
}