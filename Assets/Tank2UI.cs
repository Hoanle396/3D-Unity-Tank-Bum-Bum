using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2UI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tanks;

    void Start() {
        tanks[Static.Tank2Index].SetActive(true);
    }

}
