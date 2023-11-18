using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private ChickenClassic chickenClassic;
    [SerializeField] private ChickenFire chickenFire;
    [SerializeField] private PlayerInteractions player;
    
    private bool canSpawn = true;

    private void Update()
    {
        if(Vector2.Distance(player.transform.position,gameObject.transform.position) <= 1 && canSpawn) Spawn();       
    }

    public void Spawn()
    {
        for (int i = 0; i <= Random.Range(1, 2); i++)
        {
                ChickenClassic currentChicken = Instantiate(chickenClassic, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                ChickenFire currnetChicken_fire = Instantiate(chickenFire, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
         canSpawn = false;        
    }   
}
