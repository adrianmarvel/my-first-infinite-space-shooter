using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    public float music;
    public float sfx;
    public int difficuty = 2;
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource musicSource;
    public Toggle[] difficulty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        musicSource.volume = musicSlider.value;
    }

    public void easy()
    {
        difficulty[0].isOn = true;
        difficulty[1].isOn = false;
        difficulty[2].isOn = false;
    }
    public void medium()
    {
        difficulty[0].isOn = false;
        difficulty[2].isOn = false;
        difficulty[1].isOn = true;
    }
    public void hard()
    {
        difficulty[0].isOn = false;
        difficulty[1].isOn = false;
        difficulty[2].isOn = true;
    }
}
