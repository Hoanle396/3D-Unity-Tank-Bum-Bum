using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2UI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tanks;

    void Start() {
        for(int i =0; i<tanks.Length;i++) {
            if (i == Static.Tank2Index) {
                tanks[i].SetActive(true);
            } else {
                tanks[i].SetActive(false);
            }
        }
    }

}
