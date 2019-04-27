using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Liikemuuttujat
    [SerializeField]
    public Rigidbody playerBody;
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
        playerBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, playerBody.velocity.y, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        targetVector = transform.position + inputVector;

        playerBody.MovePosition(targetVector);

    }

    private void FixedUpdate() // tapahtuu 50 framen välein
    {
        playerBody.velocity = inputVector;
        if (jump && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jump = false;

        }
    }

    // tarkistetaan onko pelaaja maassa Raycastingin avulla
    private bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, distance);
    }
    
}
