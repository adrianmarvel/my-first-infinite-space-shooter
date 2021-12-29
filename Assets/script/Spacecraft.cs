using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour
{
    public int model;
    private playerCustom data;
    public Color color1;
    public Color color2;
    public float[] fColor1 = new float[3];
    public float[] fColor2 = new float[3];
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<playerCustom>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.model[0]==1)
        {
            model = 1;
        } else if(data.model[1]==1){
            model = 2;
        } else if(data.model[2]==1){
            model = 3;
        }

        color1 = data.material[1].color;
        color2 = data.material[3].color;

        fColor1[0] = color1.r;
        fColor1[1] = color1.g;
        fColor1[2] = color1.b;

        fColor2[0] = color2.r;
        fColor2[1] = color2.g;
        fColor2[2] = color2.b;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
}
