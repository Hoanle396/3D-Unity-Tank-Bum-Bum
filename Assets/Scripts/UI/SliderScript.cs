using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private AudioSource audio;
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => {
            audio.volume = v / 100;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
