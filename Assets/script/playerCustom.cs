using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCustom : MonoBehaviour
{
    public GameObject player;
    private MeshFilter meshFilter;
    public Mesh[] mesh = new Mesh[3];
    public Material[] material = new Material[4];
    public Color[] colors;
    public Color defaultColor;
    private Color secondColor;
    private float[] hsvColor = new float[3];
    public Animator anim;
    public int[] model = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = player.GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void meshChanger(Mesh _mesh)
    {
        meshFilter.mesh = _mesh;
    }
    public void colorChanger(int a)
    {

        material[1].color = colors[a];
        secondColor = material[1].color;
        Color.RGBToHSV(secondColor, out hsvColor[0], out hsvColor[1], out hsvColor[2]);
        hsvColor[0] -= 0.05f;
        hsvColor[1] -= 0.3f;
        hsvColor[2] -= 0.5f;
        material[3].color = Color.HSVToRGB(hsvColor[0], hsvColor[1], hsvColor[2]);
    }
    public void select()
    {
        anim.Play("color to model");
    }
    public void back()
    {
        material[1].color = defaultColor;
        material[3].color = defaultColor;
        anim.Play("color to model");
        model[0]= 0;
        model[1]= 0;
        model[2]= 0;
    }
    public void selectModel(int models)
    {
        if(model[models]==0)
        {
            model[0]= 0;
            model[1]= 0;
            model[2]= 0;
            model[models] += 1;
            //defaultMaterial();
        } else if(model[models]==1)
        {
            anim.Play("model to color");
        }
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
    public void play()
    {
        SceneManager.LoadScene(2);
    }
}
