using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;

public class Player : MonoBehaviour
{

    
    //CharacterController characterController;

    //public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    //public float gravity = 20.0f;

    //private Vector3 moveDirection = Vector3.zero;

    //void Start()
    //{
    //    characterController = GetComponent<CharacterController>();
    //}

    //void Update()
    //{
    //if (characterController.isGrounded)
    //{
    //    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    //    moveDirection *= speed;

    //    if (Input.GetButton("Jump"))
    //    {
    //        moveDirection.y = jumpSpeed;
    //    }
    //}

    //    moveDirection.y -= gravity * Time.deltaTime;

    //    characterController.Move(moveDirection * Time.deltaTime);
    //}

    
    /* void Update()
    {

       
        if (_characterController.isGrounded)
        {
        
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
 
            
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        _characterController.Move(moveDirection * Time.deltaTime);

        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

    }*/

   
    public float speed = 1.0F;
    public float run = 1.7F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 105.0F;
    private Vector3 moveDirection = Vector3.zero;

    private Animator _animator;
    private CharacterController _characterController;



    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }
     void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (z < 0)
            z = 0;
        
        transform.Rotate(0,x * rotateSpeed * Time.deltaTime, 0);


        if (_characterController.isGrounded)
        {

            bool move = (z > 0) || (x != 0);
            
            _animator.SetBool("walk", move);

            moveDirection = Vector3.forward * z;
            moveDirection = transform.TransformDirection((moveDirection));
            moveDirection *= speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {

                _animator.SetBool("run", move);

                moveDirection = Vector3.forward * z;
                moveDirection = transform.TransformDirection((moveDirection));
                moveDirection *= run;

            }
            else
            {
                _animator.SetBool("run", false);
            }
            
            if (Input.GetKey(KeyCode.Space))
            {

                _animator.SetBool("jump", true);

                moveDirection.y = jumpSpeed;

            }
            else
            {
                _animator.SetBool("jump", false);
            }
        
                
            

        }
        moveDirection.y -= gravity * Time.deltaTime;

        _characterController.Move(moveDirection * Time.deltaTime);
        
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("attack1");
        }

    }
     
     private int Attack1 = Animator.StringToHash("Base Layer.Attack1");

     public bool IsAttacking
     {
         get
         {
             AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
             if (stateInfo.fullPathHash == Attack1)
             {
                 return true;
             }
             return false;
         }
     }
     

    
    
}