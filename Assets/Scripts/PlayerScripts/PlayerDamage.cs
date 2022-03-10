using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDamage : MonoBehaviour
{

    // player health
    public int playerHealth;
    public int playerDamage;

    public bool isBlocking = false;
    
    
    [SerializeField]
    TextMeshProUGUI PlayerHealthValue;

    
        
    private float TimeV = 0;
    private bool canbehit = true;
    public GameObject DeathCube;
    private Camera mainCamera;
    void OnCollisionEnter(Collision other)
    {
       // functions relating to if the player has collided with objects named eattack or boss, objects that would damage the player.
        if (other.gameObject.name.Contains("eattack"))  {
            hit();
             Debug.Log("Player hit");
        }
        else if (other.gameObject.name.Contains("boss"))
        {
            hit();
            Debug.Log("Player hit");
        }
    }
    private void Hitcooldown()
    {
        // a small timer function that sets if the player can be hit one second after TimeV is set to 0
        TimeV = TimeV + Time.deltaTime;
        if(TimeV > 1)
        {
            canbehit = true;
            //TimeV = 0;
        }
    }
    private void hit()
    {
        // a hit function that lowers the playerhealth, resets the hitcooldown timeV variable to 0 and if the palyerhealth is low enough calls the die function
        if (canbehit == true)
        {
            playerHealth--;
            canbehit = false;
            TimeV = 0;

            if (playerHealth == 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        // destroys the playerand spawns cubes in their place, as well as setting the cameras parent in the game to be nothing so the camera doesnt get deleted along with the player.
        Instantiate(DeathCube, transform.position, transform.rotation);
        mainCamera.transform.SetParent(null);
        Destroy(gameObject);
    }

    private void BlockingCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canbehit = false;
            isBlocking = true;

        }
        else
        {
            isBlocking = false;
        }
    }


    void Start()
    {
        // finds the main camera and gets the Playerprefs for damage/health for use within the script
        mainCamera = FindObjectOfType<Camera>();
       
        playerHealth = PlayerPrefs.GetInt("PlayerHealth");
        playerDamage = PlayerPrefs.GetInt("PlayerDamage");
       
    }

    // Update is called once per frame
    void Update()
    {
        BlockingCheck();
        if (isBlocking == false)
        {
            Hitcooldown();
        }
        Debug.Log("Player sending damage" + playerDamage);
        PlayerHealthValue.text = " " + playerHealth;
    }
}
