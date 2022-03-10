using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathForce : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject target;
    private float TimeV = 0;
    private Vector3 scaleChange;
    private void ApplyForce()
    {
        // a function used to set the objects spawned when an enemy or player dies to add a force too them to make them try and 'explode' as well as remove their parents so they will act independently olf each other
        transform.SetParent(null);
        _rb.AddForce(-transform.forward * 2, ForceMode.Impulse);
        _rb.AddForce(transform.up * 4, ForceMode.Impulse);
        
    }
    private Vector3 pushBackDir(Vector3 pos1, Vector3 pos2)
    {
        // an unused function ment to make them move backwards
        return (pos2 - pos1).normalized;
    }
    private void shrink()
    {
        // a function that will after 3 seconds begin to shrink the gameobjects down until they are small enough it will delete them
        TimeV = TimeV + Time.deltaTime;
        if (TimeV > 3)
        {
            scaleChange = new Vector3(-0.5f, -0.5f, -0.5f);
            transform.localScale += scaleChange * Time.deltaTime;
            if(transform.localScale.x < 0.1f)
            {
                Destroy(gameObject);
            }
            if (transform.localScale.y < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.Find("Player Cube");
        _rb = GetComponent<Rigidbody>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        shrink();
    }
}
