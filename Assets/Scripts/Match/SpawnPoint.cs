using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private float maxSpawned = 1;
    public bool respawn = false;
    private float spawned = 0;
    public string spawnName;
    public string team;
    public GameObject prefab;
    void Start()
    {
        //create a new spawnResult
        for (int i = 0; i < maxSpawned; i++)
        {
            Spawn();
            spawned++;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        GameObject spawnResult;
        spawnResult = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        spawnResult.name = $"{spawnName}({spawned})";
        spawnResult.tag = team;
        spawnResult.transform.position = spawnPoint.transform.position;
        spawnResult.transform.rotation = spawnPoint.transform.rotation;
    }
}
