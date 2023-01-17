using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
        public float MoveSpeed = 1f;
        public Rigidbody2D rb;
        public Animator animator;
        private Transform enemyTarget;
        private bool follow = true;
        public Transform player;
        public EnemyCombat attack;


        void Start(){
            enemyTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        void Update(){
        if (player)
        {
            float distance = Vector2.Distance(enemyTarget.position, transform.position);


            if (distance < 10 && distance > 2)
            {
                follow = true;//makes it move to player direction
            }
            else
            {
                follow = false;//stops its movement since its attacking player
            }
        }
        if (enemyTarget != null && follow == true)//makes it follow again if player moved
        {
            Chase();
        }
        }
        void Chase(){
            //movement vector
            transform.position = Vector2.MoveTowards(transform.position, enemyTarget.position, MoveSpeed * Time.deltaTime);
        }
}
