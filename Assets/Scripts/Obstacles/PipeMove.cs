using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private void Update()
    {
        if (GameManager.Instance.GetState() == GameManager.State.Playing)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
