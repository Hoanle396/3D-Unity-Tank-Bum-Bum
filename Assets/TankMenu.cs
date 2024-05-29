using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TankMenu : MonoBehaviour {

    [SerializeField]
    private  GameObject[] tanks;

    private void Start() {
        Static.TankIndex = 0;
        Static.Tank2Index = 0;
    }

    public void onNext() {
        tanks[Static.TankIndex].SetActive(false);
        Static.TankIndex++;
        if (Static.TankIndex == 3)
            Static.TankIndex = 0;
        tanks[Static.TankIndex].SetActive(true);
    }

    public void onPrev() {
        tanks[Static.TankIndex].SetActive(false);
        Static.TankIndex--;
        if (Static.TankIndex == -1)
            Static.TankIndex = 2;
        tanks[Static.TankIndex].SetActive(true);
    }

    public void on2Next() {
        tanks[Static.Tank2Index].SetActive(false);
        Static.Tank2Index++;
        if (Static.Tank2Index == 3)
            Static.Tank2Index = 0;
        tanks[Static.Tank2Index].SetActive(true);
    }

    public void on2Prev() {
        tanks[Static.Tank2Index].SetActive(false);
        Static.Tank2Index--;
        if (Static.Tank2Index == -1)
            Static.Tank2Index = 2;
        tanks[Static.Tank2Index].SetActive(true);
    }
}
