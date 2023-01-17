using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public int maxHp = 10;

    public HealthBar hpBar;

    public int hp;
    public Animator animator;

    // Start is called before the first frame update

    // public int hp{
    //     set{
    //         hp = value;
    //     }
    //     get{
    //             return hp;
    //         }
    // }
   
    void Start()
    {
        hp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    // Update is called once per frame
    void Update()
    {

        hpBar.SetHp(hp);
        if (hp <=0)
        {
            animator.SetTrigger("playerDeath");
        }
    }

    public void TakeDamage(int incomeDamage){
        hp -= incomeDamage;
    }
}
