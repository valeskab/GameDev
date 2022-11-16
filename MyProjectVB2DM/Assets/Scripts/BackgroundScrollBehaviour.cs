using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollBehaviour : MonoBehaviour
{
    public BoxCollider2D backgroundCollider;
    public Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -2f;

    private void Start()
    {
        backgroundCollider= GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = backgroundCollider.size.x;
        backgroundCollider.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
    }

    private void Update()
    {
        if (transform.position.y < -width)
        {
            Vector2 resetPosition = new Vector2( 0, width * 1.99f);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
