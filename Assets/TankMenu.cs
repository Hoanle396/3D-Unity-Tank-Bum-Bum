using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TankMenu : MonoBehaviour {

    [SerializeField]
    private  GameObject[] tanks;

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
}
