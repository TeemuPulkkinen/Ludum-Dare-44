using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;
    private bool jump;

    private Vector3 inputVector;
    private float inputX;
    private float inputZ;

    private Vector3 targetVector;
    
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * 10f * Time.deltaTime, playerBody.velocity.y, Input.GetAxis("Vertical") * 10f * Time.deltaTime);
        //transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        targetVector = transform.position + inputVector;

        playerBody.MovePosition(targetVector);
        
    }

    private void FixedUpdate() // Called once in 50 frames
    {
        playerBody.velocity = inputVector;
    }
}
