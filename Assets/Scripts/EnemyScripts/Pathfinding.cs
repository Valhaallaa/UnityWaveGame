using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    private GameObject target;
    public NavMeshAgent enemy;

    // an old script used to test pathfinding of the navmesh agents within unity
    private void StartPathfinding() {
        enemy.SetDestination(target.transform.position);
    }
    private void StopPathfinding() {

}
        // Start is called before the first frame update
        void Start()
    {
        target = GameObject.Find("Player Cube");
    }

    // Update is called once per frame
    void Update()
    {
        StartPathfinding();
    }
}
