using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levels;

    private void Start() {
        for (int i = 0; i < levels.Length; i++) {
            if (Static.Level == i)
                levels[i].SetActive(true);
            else {
                levels[i].SetActive(false);
            }
        }
    }
    private void Update() {
        for (int i = 0; i < levels.Length; i++) {
            if (Static.Level == i)
                levels[i].SetActive(true);
            else {
                levels[i].SetActive(false);
            }
        }
    }
}
