using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourMovement : MonoBehaviour
{
    public Rigidbody _rb;
    public int MovSpeed; // Speed the Player cube moves at.
    private void keyMovement() // Script to keep track of keydowns, if WASD is pressed adds movement in the Rigidbody in that direction
    {
        if (_rb.velocity.magnitude < 5) {
            if (Input.GetKey(KeyCode.W))
            {
                _rb.AddForce(transform.forward * MovSpeed, ForceMode.Acceleration);
              //  Debug.Log("W key pressed");
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rb.AddForce(transform.right * MovSpeed, ForceMode.Acceleration);
              //  Debug.Log("D key pressed");
            }
            if (Input.GetKey(KeyCode.A))
            {
                _rb.AddForce(-transform.right * MovSpeed, ForceMode.Acceleration);
               // Debug.Log("A key pressed");
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rb.AddForce(-transform.forward * MovSpeed, ForceMode.Acceleration);
               // Debug.Log("S key pressed");
            }
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        keyMovement();
        Mathf.Clamp(MovSpeed, 0, 1);
    
    }
}
