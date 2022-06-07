using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour
{

    public float jumpforce = 5;
    public float lifeforce = 100;

    public float speed;
    public bool grounded;
    public LayerMask groundLayers;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.1f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // get input from left/right arrow keys
        Vector2 vel = rb2d.velocity;
        float horizontalInput = Input.GetAxis("Horizontal") * speed;
        vel.x = horizontalInput;

        jumpforce = lifeforce / 20;

        UpdateGrounding();

        // get input from spacebar
        bool inputJump = Input.GetKeyDown(KeyCode.Space);
        if (inputJump && grounded)
        {
            vel.y = jumpforce;
        }

        rb2d.velocity = vel;
    }

    private bool UpdateGrounding()
    {

        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;


        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundLayers);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector3.down, groundRayLength * 2, groundLayers);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector3.down, groundRayLength * 2, groundLayers);


        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * groundRayLength * 2, Color.red);



        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        return grounded;

    }
}
