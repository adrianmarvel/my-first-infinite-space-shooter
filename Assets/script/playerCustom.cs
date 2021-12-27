using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCustom : MonoBehaviour
{
    public GameObject player;
    private MeshFilter meshFilter;
    public Mesh[] mesh = new Mesh[3];
    public Material[] material = new Material[4];
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = player.GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mesh1()
    {
        meshFilter.mesh = mesh[0];
    }
    public void mesh2()
    {
        meshFilter.mesh = mesh[1];
    }
    public void mesh3()
    {
        meshFilter.mesh = mesh[2];
    }
    public void color(Material mat, Color col)
    {
        mat.color = col;
    }
}
