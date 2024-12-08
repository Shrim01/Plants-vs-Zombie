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
    public GameObject plants;
    public int CountZombieOnMap = 15;
    public int CountPlantsOnMap = 15;
    private readonly Dictionary<string, int> countEnemy = new() { { "Zombie", 0 }, { "Plants", 0 } };
    private int x = 12;
    private int y = 6;

    void Start()
    {
    }

    void Update()
    {
        SpawnZombie();
    }

    private void SpawnZombie()
    {
        if (countEnemy["Zombie"] < CountZombieOnMap)
            Instantiate(zombie, GetPosition(), transform.rotation);
        countEnemy["Zombie"] = GameObject.FindGameObjectsWithTag("Zombie").Length;
    }

    private Vector3 GetPosition()
    {
        var radius = Random.Range(Mathf.Sqrt(x * x + y * y) + 2, x * 2.5f);
        var rotation = Random.rotation.eulerAngles.z;
        return player.transform.position + new Vector3(
            Mathf.Cos(rotation * Mathf.PI / 180) * radius,
            Mathf.Sin(rotation * Mathf.PI / 180) * radius, 0);
    }
}
