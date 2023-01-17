using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;


    Collider2D attackCollider;


    private void Start(){
        attackCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collider2D opponent){
        if (opponent.gameObject.tag == "Player"){
            //deals damage
            PlayerHealth playerEntity = opponent.GetComponent<PlayerHealth>();
            if (playerEntity != null){
                playerEntity.hp -=damage;
            }
        }
    }
}
