using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float musicVolume;
    public float sfxVolume;
    public AudioSource music;
    public AudioSource[] sfx;
    public enemySpawner spawner;
    private AudioSource[] enemySfx = new AudioSource[11];
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        int j = 0;
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolume = PlayerPrefs.GetFloat("SfxVolume");

        music.volume *= musicVolume;

        while(j<spawner.enemy.Length)
        {
            enemySfx[j] = spawner.enemy[j].GetComponent<AudioSource>();
            enemySfx[j].volume *= sfxVolume;
            j++;
        }

        while(i<sfx.Length)
        {
            sfx[i].volume *= sfxVolume;
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
