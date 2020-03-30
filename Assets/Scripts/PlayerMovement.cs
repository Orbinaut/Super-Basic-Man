using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    [FMODUnity.EventRef]
    public string landSoundEvent;

    [FMODUnity.EventRef]
    public string jumpSoundEvent;

    [FMODUnity.EventRef]
    public string stepSoundEvent;

    float horizontalMove = 0f;
    bool jump = false;

    private FMOD.Studio.EventInstance jumpSound;
    private FMOD.Studio.EventInstance landSound;
    private FMOD.Studio.EventInstance stepSound;

    #endregion

    void Start()
    {
        landSound = FMODUnity.RuntimeManager.CreateInstance(landSoundEvent);
        jumpSound = FMODUnity.RuntimeManager.CreateInstance(jumpSoundEvent);
        stepSound = FMODUnity.RuntimeManager.CreateInstance(stepSoundEvent);
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
            if (controller.m_Grounded)
            {
                jumpSound.start();
            }
        }
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
        landSound.start();
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void Footstep()
    {
        stepSound.start();
    }
}