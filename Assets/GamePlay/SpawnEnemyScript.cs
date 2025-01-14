using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    public GameObject plant;
    public int CountZombieOnMap = 15;
    public int CountPlantsOnMap = 5;
    private readonly Dictionary<string, int> countEnemy = new() { { "Zombie", 0 }, { "Plant", 0 } };
    private int x = 30;
    private int y = 16;


    void Update()
    {
        SpawnZombie();
        SpawnPlant();
    }

    private void SpawnZombie()
    {
        if (countEnemy["Zombie"] < CountZombieOnMap)
            Instantiate(zombie, GetPosition(), transform.rotation);
        countEnemy["Zombie"] = GameObject.FindGameObjectsWithTag("Zombie").Length;
    }
    private void SpawnPlant()
    {
        if (countEnemy["Plant"] < CountPlantsOnMap)
            Instantiate(plant, GetPosition(), transform.rotation);
        countEnemy["Plant"] = GameObject.FindGameObjectsWithTag("Plant").Length;
    }

    private Vector3 GetPosition()
    {
        var radius = Random.Range(Mathf.Sqrt(x * x + y * y) + 2, x * 2.5f);
        var rotation = Random.rotation.eulerAngles.z;
        return player.transform.position + new Vector3(
            Mathf.Cos(rotation * Mathf.PI / 180) * radius,
            Mathf.Sin(rotation * Mathf.PI / 180) * radius, 5);
    }
}
