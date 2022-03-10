using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyBasic;
    public GameObject EnemyFast;
    public GameObject EnemyTanky;
    public int LevelNumber;

    public int EnemyCount = 0;
    //private GameObject EnemyChecker = null;
    private int Wave = 1;
    //private bool spawning = true;

    private GameObject spawner1;
    private GameObject spawner2;

   // an old and unused script file that was originally how the enemies were too be spawned in a similar method to the second script file, however this script file doesnt
   // work and causes all enemies to be spawned in at once

    IEnumerator Delay(float i)
    {
        yield return new WaitForSeconds(i);
        // Do stuff;
    }



    private void WaveChecker()
    {
        
        Debug.Log(EnemyCount);
        if (EnemyCount == 0)
        {

            StartWave();
            


            if (Wave >= 5)
            {
                SceneManager.LoadScene(1);
            }
            Wave++;
        }
        
    }
    private void StartWave()
    {
        //spawning = true;
        if (LevelNumber == 1)
        {
            if (Wave == 1)
            {
                Debug.Log("Spawning Wave 1");
                spawnbasic(); // 2
                StartCoroutine(Delay(2));
                spawnbasic(); // 4
                StartCoroutine(Delay(2));
                spawnbasic(); // 6
                StartCoroutine(Delay(2));
                spawnbasic();  // 8
                StartCoroutine(Delay(2));
                spawnbasic(); // 10
                StartCoroutine(Delay(2));
                //spawning = false;
            }
            if (Wave == 2)
            {
                Debug.Log("Spawning Wave 2");
                spawnfast(); // 2
                StartCoroutine(Delay(2));
                spawnfast(); // 4
                StartCoroutine(Delay(2));
                spawnfast(); // 6
                StartCoroutine(Delay(2));
                spawnfast(); // 8
                StartCoroutine(Delay(2));
                spawnbasic(); // 10
                StartCoroutine(Delay(2));
                //spawning = false;
            }
            if (Wave == 3)
            {
                Debug.Log("Spawning Wave 3");
                spawnfast(); // 2
                StartCoroutine(Delay(0.25f));
                spawnfast(); // 4
                StartCoroutine(Delay(0.25f));
                spawnfast(); // 6
                StartCoroutine(Delay(0.25f));
                spawnfast(); // 8
                StartCoroutine(Delay(0.25f));
                spawnfast(); // 10
                StartCoroutine(Delay(0.25f));
                spawnfast(); // 12
                StartCoroutine(Delay(0.25f));
                spawntanky(); // 14
                StartCoroutine(Delay(0.25f));
                //spawning = false;
            }
            if (Wave == 4)
            {
                Debug.Log("Spawning Wave 4");
                spawntanky(); // 2
                StartCoroutine(Delay(0.5f));
                spawnfast(); // 4
                StartCoroutine(Delay(0.5f));
                spawntanky(); // 6
                StartCoroutine(Delay(0.5f));
                spawnfast(); // 8
                StartCoroutine(Delay(0.5f));
                spawntanky(); // 10
                StartCoroutine(Delay(0.5f));
                spawnfast(); // 12
                StartCoroutine(Delay(0.5f));
                spawntanky(); // 14
                StartCoroutine(Delay(0.5f));
                //spawning = false;
            }
        }
        if(LevelNumber == 2)
        {
            if (Wave == 1)
            {
                spawnbasic(); //2
                spawnbasic();//4
                spawnbasic();//6
                spawnbasic();//8
                spawnbasic();//10
                spawnbasic();//12
                spawnbasic();//14
                spawntanky();//16
                spawntanky();//18
                spawntanky();//20

            }
            if (Wave == 2)
            {
                spawnfast(); // 2
                spawnfast();// 4
                spawnfast();// 6
                spawnfast(); // 8
                spawnfast();// 10
                spawnfast(); // 12
                spawnfast();// 14
                spawnfast();// 16
                spawnbasic(); // 18
                spawnbasic(); // 20
            }
            if (Wave == 3)
            {
                spawntanky(); //2
                spawntanky();  // 4
                spawntanky(); // 6
                spawntanky();  // 8
                spawntanky(); //10
                spawnfast(); // 12
            }
            if (Wave == 4)
            {
                spawnfast(); // 2
                spawnfast();// 4
                spawnfast();// 6
                spawnfast(); // 8
                spawnfast();// 10
                spawnfast(); // 12
                spawnfast();// 14
                spawnfast();// 16
                spawntanky(); //18
                spawntanky();  // 20
                spawntanky(); // 22
                spawntanky();  // 24
                spawntanky(); //26
            }
        }
        
    }
   

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

    // Start is called before the first frame update
    void Start()
    {
        spawner1 = GameObject.Find("spawner1");
        spawner2 = GameObject.Find("spawner2");


        //StartWave();
         InvokeRepeating("WaveChecker", 4, 4);
    }

    // Update is called once per frame
    void Update()
    {
       
      
        
    }
}
