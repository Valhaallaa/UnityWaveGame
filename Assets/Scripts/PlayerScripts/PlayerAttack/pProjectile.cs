using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pProjectile : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject PlayerSphere;
    void OnCollisionEnter(Collision other)
    {
        // upon collision with any object it will spawn in a much larger sphere that the enemy script is checking collisions for and it will then delete itself
        Instantiate(PlayerSphere, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // gets the rigidbody for the gameobject and applies a forward force sending it flying forward.
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * 20, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
