using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;
    public ParticleSystem particle;
    Vector3 velocity;

    public float speed = 12f;
    public float gravity = -20;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    
    bool isGrounded;


    private void Start()
    {
        particle.GetComponent<ParticleSystem>();
        particle.Stop();
    }




    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }




        // Particles for running

        if(isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            particle.Play();
        }

        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            particle.Stop();
        }

        
    }
}