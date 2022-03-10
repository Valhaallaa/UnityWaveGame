using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    public NavMeshAgent enemy;
    public GameObject DeathCube;
    private Rigidbody _rb;
    private PlayerDamage _PD;
    private int PlayerDamage;
    private EnemySpawningSecondMethod Spawner;

    private float TimeV;
    private float TimeV2;
    private float TimeV3;
    public float distanceFromTarget = 3f;
    public float AttackTime = 0.5f;

    private int HitCount = 0;
    private bool gettingHit = false;
    public int Health = 5;


    public int Score;
    private PlayerScore Scoreboard;

    private bool hitcooldown;
    public GameObject attackPos;
    public GameObject attack;
    void OnCollisionEnter(Collision other)
    {
        if (hitcooldown == false)
        {
            hitcooldown = true;
            TimeV3 = 0;
            if (gettingHit == false) gettingHit = true;
            {
                if (other.gameObject.name.Contains("pattack"))
                {



                    // reacts to the player hitting the enemie, sending in backward and enabling physics
                    _rb.isKinematic = false;
                    _rb.AddForce(pushBackDir(target.transform.position, other.transform.position) * 5, ForceMode.Impulse);
                    TimeV = 0;
                    gethit();
                    Debug.Log("Hit with player attack");
                    if (HitCount >= Health)
                    {
                        Die();
                    }
                    Destroy(other.gameObject);
                }

            }
            if (other.gameObject.name.Contains("pSphere"))
            {
                _rb.isKinematic = false;
                _rb.AddForce(pushBackDir(target.transform.position, other.transform.position) * 5, ForceMode.Impulse);
                TimeV = 0;
                gethit();
                if (HitCount >= Health)
                {
                    Die();
                }
            }
        }
    }
    private void gethit()
    {
        if (gettingHit == true)
        {
           
            HitCount = HitCount + PlayerDamage;
            
            Debug.Log("Enemy Hit");
        }
        gettingHit = false;
    }
    private void Die()
    {
        
        Instantiate(DeathCube, enemy.transform.position, enemy.transform.rotation);
        Spawner.EnemyCount = Spawner.EnemyCount - 1;
        Scoreboard.IncScore = Scoreboard.IncScore + Score;
        Destroy(gameObject);
    }
    private void Hitcooldown()
    {
        TimeV3 = TimeV3 + Time.deltaTime;
        if (TimeV3 > 0.5)
        {
            hitcooldown = false;
            //TimeV = 0;
        }
    }

        private Vector3 pushBackDir(Vector3 pos1, Vector3 pos2)
    {
        return (pos2 - pos1).normalized;
    }

    private void EnableKinematic() // constantly checking a timer for when to renable the physics, does nothing if its already enabled. used after its hit
    {
        TimeV = TimeV + Time.deltaTime;
        if(TimeV > 1)
        {
            _rb.isKinematic = true;
        }
    }
    private void StartPathfinding() { // starts pathfinding to  go towards the player
        enemy.SetDestination(target.transform.position);
    }
    
    private void StopPathfinding() // stops the pathfinding when close to the player
    {
        float distanceToTarget = Vector3.Distance(enemy.transform.position, target.transform.position);
        if (distanceToTarget < 0.5f)
        {
            enemy.isStopped = true;
          
        }

        if (distanceToTarget >= 0.5f)
        {
            enemy.isStopped = false;
          
        }
    }
    private void Attacking()
    {
        float distanceToTarget = Vector3.Distance(enemy.transform.position, target.transform.position);

        if (distanceToTarget < distanceFromTarget) { 
            TimeV2 = TimeV2 + Time.deltaTime;
           // Debug.Log("Begining attack");
        }

        if (TimeV2 > AttackTime)
            {
            Instantiate(attack, attackPos.transform.position, transform.rotation);
           // Debug.Log("attacking");


            }

    if (distanceToTarget >= 3f) { 
        TimeV2 = 0;
       // Debug.Log("to far to attack");
    }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player Cube");
        _rb = GetComponent<Rigidbody>();
        _PD = GameObject.Find("Player Base").GetComponent<PlayerDamage>();
        Spawner = GameObject.Find("spawner").GetComponent<EnemySpawningSecondMethod>();
        Spawner.EnemyCount = Spawner.EnemyCount + 1;
        Scoreboard = GameObject.Find("Player Base").GetComponent<PlayerScore>();


    }

    // Update is called once per frame
    void Update()
    {
        StartPathfinding();
        StopPathfinding();
        EnableKinematic();
        Attacking();
        Hitcooldown();
        Debug.Log("Enemy sending damage" + _PD.playerDamage);
        PlayerDamage = _PD.playerDamage;
    }
}
