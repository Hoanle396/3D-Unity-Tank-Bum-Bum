using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Map : MonoBehaviour
{
    Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.yellow;
    }
}
