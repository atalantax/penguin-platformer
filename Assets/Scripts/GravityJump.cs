using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityJump : MonoBehaviour
{
    public float fallRate = 2.5f;
    public float lowJump = 2.0f;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += (fallRate - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        } else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb2d.velocity += (lowJump - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
    }
}
