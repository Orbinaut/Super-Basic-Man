using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public AudioSource jumpSound;
    public AudioSource landSound;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            jump = true;
            jumpSound.Play();
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
        landSound.Play();
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
