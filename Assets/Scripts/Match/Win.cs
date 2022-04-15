using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    private LayerMask Allies;
    private LayerMask Player;
    private LayerMask Enemies;
    private float currentPlayerCount;
    private float enemyCount;
    private float allyCount;
    private GameObject[] allies;
    private GameObject[] enemies;
    private float originalPlayerCount;
    void Start()
    {
        Player = LayerMask.GetMask("Player");
        Allies = LayerMask.GetMask("Allies");
        Enemies = LayerMask.GetMask("Enemies");
        //get all gameobjects that are named Player
        allies = GameObject.FindGameObjectsWithTag("Ally");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentPlayerCount = originalPlayerCount = allies.Length + enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (originalPlayerCount > currentPlayerCount)
        {
            allies = GameObject.FindGameObjectsWithTag("Ally");
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if (allies.Length == 0)
        {
            Debug.Log("Enemies Win");
        }
        if (enemies.Length == 0)
        {
            Debug.Log("Allies Win");
        }
        currentPlayerCount = allies.Length + enemies.Length;
    }
}
