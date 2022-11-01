using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public void Usar() {
        Destroy(this.gameObject);
    }
}