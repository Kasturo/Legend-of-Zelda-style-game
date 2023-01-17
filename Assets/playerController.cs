    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour {

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;//movement import
    Rigidbody2D rb;
    public Animator animator;
    public SwordAttack playerAttack;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public SpriteRenderer spriteRender;

    public bool faceX;
    public bool faceY;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


    //used for anything concerning physics 
    private void FixedUpdate(){
        //if movement input is not zero, try to move
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);

            //slide mechanic for collsion
            if (!success){
                success = TryMove(new Vector2(movementInput.x, 0)); //x direction
                if (!success){
                    success = TryMove(new Vector2(0, movementInput.y));//y direction
                }
            }
            animator.SetFloat("MovementX", movementInput.x);
            animator.SetFloat("MovementY", movementInput.y);
        }
        animator.SetFloat("Speed", movementInput.sqrMagnitude);

        if (movementInput.x<0)
        {
            playerAttack.attackDirection = SwordAttack.AttackDirection.left;
            faceX = false;
        }
        else if(movementInput.x>0)
        {
            playerAttack.attackDirection = SwordAttack.AttackDirection.right;
            faceX = true;
        }
        else if(movementInput.y > 0)
        {
            playerAttack.attackDirection = SwordAttack.AttackDirection.up;
            faceY = true;
        }
        else if (movementInput.y < 0)
        {
            playerAttack.attackDirection = SwordAttack.AttackDirection.down;
            faceY = false;
        }
    }
    
    private bool TryMove(Vector2 direction){
        //checks for collisions
        int count = rb.Cast(
            movementInput,//represents direction from body to search for collisiions
            movementFilter,//determines where a collisions can occur 
            castCollisions,//list of collision to store the collisions found into  after Cast is done
            //moveSpeed * Time.fixedDeltaTime{magnitude of vector
            moveSpeed * Time.fixedDeltaTime + collisionOffset); 

        if(count == 0){
            //direction of vector
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime); 
            //when u have unity game and ahve fixed update, 
            //there is set setting where every second there
            // is a fixed number of frames where physics updates takes place
            return true;
            }
        else {
            return false;
        }
     }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(){
        playerAttack.Attack();
        if (faceX == true){
            animator.SetBool("faceRight", faceX);
            animator.SetTrigger("AttackAnimations");
        }
        else if (faceX == false){
            animator.SetBool("faceRight", faceX);
            animator.SetTrigger("AttackAnimations");
        }

        StartCoroutine(waitSec(0.5f));
    }

    public IEnumerator waitSec(float sec){
        yield return new WaitForSeconds(sec);
        playerAttack.StopAttack();
    }
}
