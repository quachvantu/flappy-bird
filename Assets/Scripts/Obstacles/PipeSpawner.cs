using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipeSpawner;
    private float spawnInterval = 1.5f;
    private float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            float randomY = Random.Range(-2f, 2f);
            Instantiate(pipeSpawner, new Vector3(10f, randomY, 0f), Quaternion.identity);
            timer = 0f;
        }
    }
}
