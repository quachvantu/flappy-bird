using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }
    public static bool isAlive = true;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (!isAlive)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), 5f * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (isAlive)
        {
            Debug.Log("Bird hit something!");
            isAlive = false;

        }
    }
}
