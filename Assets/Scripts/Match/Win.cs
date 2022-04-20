using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    private LayerMask Allies;
    private GameObject Player;
    private LayerMask Enemies;
    private float currentPlayerCount;
    private float enemyCount;
    private float allyCount;
    private GameObject[] allies;
    private GameObject[] enemies;
    private float originalPlayerCount;
    void Start()
    {
        Player = GameObject.Find("Player");
        Allies = LayerMask.GetMask("Allies");
        Enemies = LayerMask.GetMask("Enemies");
        //get all gameobjects that are named Player
        allies = GameObject.FindGameObjectsWithTag("Allies");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentPlayerCount = originalPlayerCount = allies.Length + enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        allies = GameObject.FindGameObjectsWithTag("Allies");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Allies: " + allies.Length);
        Debug.Log("Enemies: " + enemies.Length);
        currentPlayerCount = allies.Length + enemies.Length;
        if (allies.Length == 0)
        {
            Debug.Log("Enemies Win");

        }
        if (enemies.Length == 0)
        {
            Debug.Log("Allies Win");
            Player.GetComponent<PlayerUi>().Victory();
        }
        currentPlayerCount = allies.Length + enemies.Length;
    }
}
