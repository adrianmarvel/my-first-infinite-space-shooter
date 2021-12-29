using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public int model;
    public float[] color1;
    public float[] color2;

    public PlayerData (Spacecraft spacecraft)
    {
        model = spacecraft.model;

        color1 = new float[3];
        color1[0] = spacecraft.color1.r;
        color1[1] = spacecraft.color1.g;
        color1[2] = spacecraft.color1.b;

        color2 = new float[3];
        color2[0] = spacecraft.color2.r;
        color2[1] = spacecraft.color2.g;
        color2[2] = spacecraft.color2.b;
    }
}
