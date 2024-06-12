using System;
using UnityEngine;

public class MoedaSpawn : MonoBehaviour
{
    public GameObject moedaPrefab;
    public Transform[] spawnPoints;
    public int totalCoins = 10;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Obtém a posição do ponto de spawn
            Vector3 spawnPosition = spawnPoint.position;
            // Define a profundidade do eixo Z
            spawnPosition.z = -0.2f;

            Instantiate(moedaPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

















