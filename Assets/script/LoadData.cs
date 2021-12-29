using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public GameObject player;
    public Mesh[] meshModel = new Mesh[3];
    private MeshFilter playerModel;
    public int model;
    public Material[] playerMat = new Material[4];
    public Material bulletMat;
    public Color color1;
    public Color color2;
    // Start is called before the first frame update
    void Start()
    {
        playerModel = player.GetComponent<MeshFilter>();
        LoadPlayer();
        if(model == 1)
        {
            playerModel.mesh = meshModel[0];
        }else if(model == 2)
        {
            playerModel.mesh = meshModel[1];
        }else if(model == 3)
        {
            playerModel.mesh = meshModel[2];
        }

        playerMat[1].color = color1;
        playerMat[3].color = color2;

        bulletMat.SetColor("_EmissionColor", color1*4);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        model = data.model;

        color1.r = data.color1[0];
        color1.g = data.color1[1];
        color1.b = data.color1[2];

        color2.r = data.color2[0];
        color2.g = data.color2[1];
        color2.b = data.color2[2];
    }
}
