using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tanks;

    void Start()
    {
        tanks[Static.TankIndex].SetActive(true);
    }

}
