using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PunManager : MonoBehaviour {

    private static TextMesh instance;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

   
}