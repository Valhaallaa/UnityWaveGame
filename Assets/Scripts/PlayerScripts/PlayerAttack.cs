using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPos;
    public GameObject attack;
    public GameObject projectile;
    public PlayerDamage Player;
    private float TimeV = 5;
    private void playerAttack()
    {
        // used to have the player attack if theyare not playing, left click does a regular attack while right click would fire a ranged ball attack, the regular attack has no cool down while ranged attack has a 5 sec cooldown
        if (Player.isBlocking == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(attack, attackPos.transform.position, transform.rotation);
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (TimeV > 5)
                {
                    Instantiate(projectile, attackPos.transform.position, transform.rotation);
                    TimeV = 0;
                }
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
        playerAttack();
        TimeV = TimeV + Time.deltaTime;
    }
}
