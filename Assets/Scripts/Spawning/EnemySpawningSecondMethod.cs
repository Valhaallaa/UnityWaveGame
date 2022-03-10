using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawningSecondMethod : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyBasic;
    public GameObject EnemyFast;
    public GameObject EnemyTanky;
    public int EnemyCount = 0;
    public int bosscount = 0;
    private int Wave = 1;
    public int LevelNumber;
    //private bool spawning = false;
    private bool Upgrading = false;

    private GameObject spawner1;
    private GameObject spawner2;
    public PlayerDamage Player;

    private GameObject DmgBtn;
    private GameObject hlthBtn;
    public float TimeV = 0;
    private void bosswave()
    {
        // this function is the bosswave, it will get a random number between 1 and 3 every 5 seconds then run a function to spawn an enemy before then restting the timer.
        if(TimeV > 5)
        {
            int Enemytype = Random.Range(1, 3);
            if(Enemytype == 1)
            {
                spawnbasic();
            }
            else if (Enemytype == 2)
            {
                spawnfast();
            }
            else if(Enemytype == 3)
            {
                spawntanky();
            }
            TimeV = 0;

        }
    }
    private void UpgradeChecker()
    {
        //does checks to see if there are any enemies within the level and if the upgrading bool is set to true, if so it would activate the upgrading buttons and let the player choose what too upgrade
        // by calling the functions for whatever the player presses
        if (EnemyCount == 0)
        {
            if (Upgrading == true)
            {
                DmgBtn.SetActive(true);
                hlthBtn.SetActive(true); 
                if (Input.GetKey(KeyCode.Alpha1))
                {
                   IncreaseDamage();
                }
                if (Input.GetKey(KeyCode.Alpha2))
                {
                    IncreaseHealth();
                    
                }
            }
            else
            {
                DmgBtn.SetActive(false);
                hlthBtn.SetActive(false);
            }
           
        }
    
    }
    public void IncreaseHealth()
    {
        // increases the health within the playerdamage script located on the players gameobject then sets the upgrading bool to false disabling upgrades
        Player.playerHealth = Player.playerHealth + 1;
        Upgrading = false;
        PlayerPrefs.SetInt("PlayerHealth", Player.playerHealth);
        
    }
    public void IncreaseDamage()
    {
        // increases the damage within the playerdamage script located on the players gameobject then sets the upgrading bool to false disabling upgrades
        Player.playerDamage = Player.playerDamage + 1;
        Upgrading = false;
        PlayerPrefs.SetInt("PlayerDamage", Player.playerDamage);

    }

    private void WaveChecker()
    {
        // sees if both upgrading and that there are no enemies in the level before standing a new coroutine to spawn in more enemy waves, if it is on the 5th wave it will instead change too the next level
        if (Upgrading == false)
        {
            Debug.Log("Enemy count is " + EnemyCount);
            if (EnemyCount == 0)
            {

                StartCoroutine(SpawnWaves(2));



                if (Wave >= 5)
                {
                    SceneManager.LoadScene(LevelNumber + 1);
                }

            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner1 = GameObject.Find("spawner1");
        spawner2 = GameObject.Find("spawner2");


        //Player = GameObject.Find("Player Cube").GetComponent<PlayerDamage>();
        InvokeRepeating("WaveChecker", 4, 4);
        DmgBtn = GameObject.Find("IncreasedDamage");
        hlthBtn = GameObject.Find("IncreasedHealth");
    }

    private void Update()
    {
        Debug.Log("Wave Number " + Wave);
        Debug.Log("Enemy Count " + EnemyCount);
        Debug.Log("Boss Count " + bosscount);
        Debug.Log("Time Count " + TimeV);
        UpgradeChecker();
        
        if(LevelNumber == 4)
        {
            if (bosscount > 0)
            {
                bosswave();
            }
        }
        TimeV += Time.deltaTime;
    }

    // these functions instantiate the prefabs that contain the enemygame objects, set within the editor
    private void spawnbasic()
    {
        Instantiate(EnemyBasic, spawner1.transform.position, spawner1.transform.rotation);
        Instantiate(EnemyBasic, spawner2.transform.position, spawner2.transform.rotation);


    }
    private void spawnfast()
    {
        Instantiate(EnemyFast, spawner1.transform.position, spawner1.transform.rotation);
        Instantiate(EnemyFast, spawner2.transform.position, spawner2.transform.rotation);


    }
    private void spawntanky()
    {
        Instantiate(EnemyTanky, spawner1.transform.position, spawner1.transform.rotation);
        Instantiate(EnemyTanky, spawner2.transform.position, spawner2.transform.rotation);


    }

    // a coroutine function that checks the levels and waves based off of an int variable before calling the spawn functions
    IEnumerator SpawnWaves(float delay)
    {
        if (LevelNumber == 1)
        {
            if (Wave == 1)
            {
                // Wave 1

                spawnbasic();
                yield return new WaitForSeconds(delay); // 2
                spawnbasic();
                yield return new WaitForSeconds(delay);// 4
                spawnbasic();
                yield return new WaitForSeconds(delay);//6
                spawnbasic();
                yield return new WaitForSeconds(delay);//8
                spawnbasic();
                yield return new WaitForSeconds(delay);//10
                Wave++;
                Upgrading = true;

            }
            else if (Wave == 2)
            {
                // Wave 2
                spawnfast();
                yield return new WaitForSeconds(delay); //2
                spawnfast();
                yield return new WaitForSeconds(delay); //4
                spawnfast();
                yield return new WaitForSeconds(delay); // 6
                spawnfast();
                yield return new WaitForSeconds(delay); // 8
                spawnbasic();
                yield return new WaitForSeconds(delay);// 10
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 3)
            {
                spawnfast();
                yield return new WaitForSeconds(delay); //2
                spawnfast();
                yield return new WaitForSeconds(delay); // 4
                spawnfast();
                yield return new WaitForSeconds(delay); // 6
                spawnfast();
                yield return new WaitForSeconds(delay);// 8
                spawnfast();
                yield return new WaitForSeconds(delay);// 10
                spawnfast();
                yield return new WaitForSeconds(delay);//12
                spawntanky();
                yield return new WaitForSeconds(delay); // 14
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 4)
            {
                spawntanky();
                yield return new WaitForSeconds(delay); //2
                spawnfast();
                yield return new WaitForSeconds(delay); //4
                spawntanky();
                yield return new WaitForSeconds(delay); //6
                spawnfast();
                yield return new WaitForSeconds(delay); //8
                spawntanky();
                yield return new WaitForSeconds(delay); //10
                spawnfast();
                yield return new WaitForSeconds(delay); //12
                spawntanky();
                yield return new WaitForSeconds(delay);//14
                Wave++;
                Upgrading = true;
            }

            }
        if (LevelNumber == 2)
        {
            if (Wave == 1)
            {
                spawnbasic(); //2
                yield return new WaitForSeconds(delay);
                spawnbasic();//4
                yield return new WaitForSeconds(delay);
                spawnbasic();//6
                yield return new WaitForSeconds(delay);
                spawnbasic();//8
                yield return new WaitForSeconds(delay);
                spawnbasic();//10
                yield return new WaitForSeconds(delay);
                spawnbasic();//12
                yield return new WaitForSeconds(delay);
                spawnbasic();//14
                yield return new WaitForSeconds(delay);
                spawntanky();//16
                yield return new WaitForSeconds(delay);
                spawntanky();//18
                yield return new WaitForSeconds(delay);
                spawntanky();//20
                Wave++;
                Upgrading = true;
            }
            else if(Wave == 2)
            {
                spawnfast(); // 2
                yield return new WaitForSeconds(delay);
                spawnfast();// 4
                yield return new WaitForSeconds(delay);
                spawnfast();// 6
                yield return new WaitForSeconds(delay);
                spawnfast(); // 8
                yield return new WaitForSeconds(delay);
                spawnfast();// 10
                yield return new WaitForSeconds(delay);
                spawnfast(); // 12
                yield return new WaitForSeconds(delay);
                spawnfast();// 14
                yield return new WaitForSeconds(delay);
                spawnfast();// 16
                yield return new WaitForSeconds(delay);
                spawnbasic(); // 18
                yield return new WaitForSeconds(delay);
                spawnbasic(); // 20
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 3)
            {
                spawntanky(); //2
                yield return new WaitForSeconds(delay);
                spawntanky();  // 4
                yield return new WaitForSeconds(delay);
                spawntanky(); // 6
                yield return new WaitForSeconds(delay);
                spawntanky();  // 8
                yield return new WaitForSeconds(delay);
                spawntanky(); //10
                yield return new WaitForSeconds(delay);
                spawnfast(); // 12
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 4)
            {
                spawnfast(); // 2
                yield return new WaitForSeconds(delay);
                spawnfast();// 4
                yield return new WaitForSeconds(delay);
                spawnfast();// 6
                yield return new WaitForSeconds(delay);
                spawnfast(); // 8
                yield return new WaitForSeconds(delay);
                spawnfast();// 10
                yield return new WaitForSeconds(delay);
                spawnfast(); // 12
                yield return new WaitForSeconds(delay);
                spawnfast();// 14
                yield return new WaitForSeconds(delay);
                spawnfast();// 16
                yield return new WaitForSeconds(delay);
                spawntanky(); //18
                yield return new WaitForSeconds(delay);
                spawntanky();  // 20
                yield return new WaitForSeconds(delay);
                spawntanky(); // 22
                yield return new WaitForSeconds(delay);
                spawntanky();  // 24
                yield return new WaitForSeconds(delay);
                spawntanky(); //26
                Wave++;
                Upgrading = true;
            }
        }
        if (LevelNumber == 3)
        {
            if(Wave == 1)
            {
                spawnbasic(); 
                yield return new WaitForSeconds(delay); // 2
                spawnbasic();
                yield return new WaitForSeconds(delay); // 4
                spawnbasic();
                yield return new WaitForSeconds(delay); // 6
                spawnfast();
                yield return new WaitForSeconds(delay); // 8
                spawntanky();
                yield return new WaitForSeconds(delay); // 10
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 2)
            {
                spawnfast();
                yield return new WaitForSeconds(delay); // 2
                spawnfast();
                yield return new WaitForSeconds(delay); // 4
                spawnfast();
                yield return new WaitForSeconds(delay); // 6
                spawntanky();
                yield return new WaitForSeconds(delay); // 8
                spawntanky();
                yield return new WaitForSeconds(delay); // 10
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 3)
            {
                spawnfast();
                yield return new WaitForSeconds(delay); // 2
                spawnfast();
                yield return new WaitForSeconds(delay); // 4
                spawnfast();
                yield return new WaitForSeconds(delay); // 6
                spawntanky();
                yield return new WaitForSeconds(delay); // 8
                spawntanky();
                yield return new WaitForSeconds(delay); // 10
                spawntanky();
                yield return new WaitForSeconds(delay); // 12
                spawntanky();
                yield return new WaitForSeconds(delay); // 14
                Wave++;
                Upgrading = true;
            }
            else if (Wave == 4)
            {
                spawnfast();
                yield return new WaitForSeconds(delay); // 2
                spawntanky();
                yield return new WaitForSeconds(delay); // 4
                spawntanky();
                yield return new WaitForSeconds(delay); // 6
                spawntanky();
                yield return new WaitForSeconds(delay); // 8
                spawntanky();
                yield return new WaitForSeconds(delay); // 10
                spawntanky();
                yield return new WaitForSeconds(delay); // 12
                Wave++;
                Upgrading = true;
            }
        }
        }

}
