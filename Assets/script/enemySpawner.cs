using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[11];
    private Animator[] anim = new Animator[11];
    private int i;
    private int x;
    public float counter;
    public int phase;
    private bool loop = true;
    
    // Start is called before the first frame update
    void Start()
    {
        while(i<enemy.Length)
        {
            anim[i] = enemy[i].GetComponent<Animator>();
            i++;
        }

        anim[0].Play("movement 1");
        anim[1].Play("movement 2");        
    }

    void Update()
    {
        while(enemy[x] == null && enemy[x+1] == null && loop == true)
        {
            enemy[x+2].SetActive(true);
            enemy[x+3].SetActive(true);

            anim[x+2].Play("movement "+(x+3).ToString());
            anim[x+3].Play("movement "+(x+4).ToString());

            x = x + 2;

            if(x==4)
            {
                phase++;
                loop = false;
            }
        }

        if(enemy[4] == null && enemy[5] == null)
        {
            i = 6;
            x = 7;
            while(i<=10 && phase <= 6)
            {
                enemy[i].SetActive(true);
                anim[i].Play("movement "+(i+1).ToString());
                i++;
                phase++;
            }            
        }

        if(enemy[6] == null && enemy[7] == null && enemy[8] == null && enemy[9] == null && enemy[10] == null && phase == 7)
        {
            phase++;
        }

       
    }
}
