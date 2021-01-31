using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    
    float horizontalMove = 0f;
    bool jump = false;

    public AudioClip[] footstepSounds;
    public AudioSource audioSource;

    private void Start()
    {
        GameObject.FindWithTag("Player").transform.position = GameManager.PlayerPosition;
    }

    void Update()
    {
        /*if(Input.GetKeyDown("l"))
        {
            GameObject.Find("Player").transform.position = GameObject.Find("DebugTeleportMirror").transform.position;
        }*/

        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        animator.SetFloat("HorizontalMovement", Mathf.Abs(horizontalMove));

        animator.SetBool("IsGrounded", controller.m_Grounded);

        if(Input.GetButtonDown("Jump") && !GameManager.IsPlayerFrozen)
        {
            jump = true;
            animator.SetBool("HasJumped", true);
        }

        if(GameManager.IsPlayerFrozen)
        {
            runSpeed = 0f;
            
        }
        if(!GameManager.IsPlayerFrozen)
        {
            runSpeed = 40f;
            
        }
    }

    public void OnLanding()
    {
        animator.SetBool("HasJumped", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void playFootstepSound()
    {
        audioSource.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }
}
