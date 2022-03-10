using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAttackBh : MonoBehaviour
{
    
    float TimeV = 0;
    [SerializeField]
    public bool isSphere;
    private void endAttack()
    {
        // a function used to delete the object that is spawned in while attacking, changed depending on if the objects is a sphere or not.
        TimeV = TimeV + Time.deltaTime;
        if (isSphere) {
            if (TimeV > 0.4)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (TimeV > 0.2)
            {
                Destroy(gameObject);
            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endAttack();
    }
}
