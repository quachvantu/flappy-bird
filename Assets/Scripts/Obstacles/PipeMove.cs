using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private void Update()
    {
        if (Bird.isAlive)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

    }
}
