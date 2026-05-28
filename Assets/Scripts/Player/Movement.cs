using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance { get; private set; }
    [SerializeField] private float jump = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (GameManager.Instance.GetState() != GameManager.State.Playing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        SoundManager.Instance.PlayWingClip();
    }
}
