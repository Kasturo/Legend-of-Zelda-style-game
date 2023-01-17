using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public float damage = 3;

    public enum AttackDirection{
        right, left, up, down
    }

    public AttackDirection attackDirection;

    public Transform playerPos;

    Collider2D attackCollider;

    Vector2 attackOffset;

    private void Start(){
        attackCollider = GetComponent<Collider2D>();
        attackOffset = transform.localPosition;
    }

    public void Attack(){
        switch (attackDirection)
        {
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;
            case AttackDirection.up:
                AttackUp();
                break;
             case AttackDirection.down:
                AttackDown();
                break;
        }
    }

    public void AttackRight(){
        attackCollider.enabled= true;
        transform.localPosition = new Vector2(playerPos.position.x+0.2f, playerPos.position.y);
        // new Vector3(attackOffset.x+1, attackOffset.y);
        print("Attack Right");
    }
    public void AttackLeft(){
        attackCollider.enabled = true;
        transform.localPosition =  new Vector2(playerPos.position.x-0.2f, playerPos.position.y);
        // new Vector3(attackOffset.x-1, attackOffset.y);
        print("Attack Left");
    }
    public void AttackUp(){
        attackCollider.enabled = true;
        transform.localPosition =  new Vector2(playerPos.position.x, playerPos.position.y+0.2f);
        // new Vector3(attackOffset.x, attackOffset.y+1);
        print("Attack Up");
    }
    public void AttackDown(){
        attackCollider.enabled = true;
        transform.localPosition =  new Vector2(playerPos.position.x, playerPos.position.y-0.2f);
        // new Vector3(attackOffset.x, attackOffset.y-1);
        print("Attack Down");
    }
    public void StopAttack(){
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D opponent){
        if (opponent.tag == "Enemy"){
            //deals damage
            Enemy enemyMob = opponent.GetComponent<Enemy>();

            if (enemyMob != null){
                enemyMob.Health -= damage;
            }
        }
    }
}
