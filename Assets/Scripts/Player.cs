﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Liikemuuttujat
    public Rigidbody playerBody;
    public Animator playerAnimator;
    private Vector3 targetVector;
    private Vector3 inputVector;
    private float inputX;
    private float inputZ;
    private bool jump;
    public float jumpSpeed;
    public float moveSpeed;

    // Pelaajan terveys
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Yhteys pelaajan Rigidbodyyn
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        jump = false;
        playerAnimator.SetFloat("Speed", 0f);
        //playerAnimator.SetBool("sideWalk", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            playerAnimator.SetFloat("Speed", 0f);
            playerAnimator.SetBool("sideWalk", false);
        }

        if (Input.GetAxis("Horizontal") > 0 ||  Input.GetAxis("Horizontal") < 0)
        {
            playerAnimator.SetFloat("Speed", 0.2f);
            playerAnimator.SetBool("sideWalk", true);
            
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            playerAnimator.SetFloat("Speed", 0.2f);
            
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            playerAnimator.SetBool("IsGrounded", false);
        }

        if (!Input.GetButtonDown("Jump"))
        {
            playerAnimator.SetBool("IsGrounded", true);
        }

        // Hahmon liike
        inputVector = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, playerBody.velocity.y, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        targetVector = transform.position + inputVector;

        playerBody.MovePosition(targetVector); // siirrytään haluttuun suuntaan

    }

    private void FixedUpdate() // tapahtuu 50 framen välein
    {
        // tarkistetaan ollaanko hypätty
        playerBody.velocity = inputVector;
        if (jump && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jump = false;

        }
    }

    // Maatarkistus Raycastingin avulla
    private bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, distance);
    }
    
}
