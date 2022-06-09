using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlatformerController2D : Controller2D
{
    public float jumpforce;
    public float lifeforce = 100;
    public float lifeForceLossSpeed = 0.01f;
    public float poisondamage = 10;
    private float inputX;
    private bool gameOver = false;
    public Sprite[] spriteArray;

    private SpriteRenderer sRenderer;

    public HealthStatus hb;

   

    public override void Start()
    {
        base.Start();
        sRenderer = GetComponent<SpriteRenderer>();
        hb.SetMaxHealth(100);
        
        //HeartsUI.SetLives(lives);
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal") * speed;
        Vector2 vel = rb2d.velocity;
        vel.x = inputX;
        relativeVelocity = vel;

        UpdateGrounding();

        lifeforce -= lifeForceLossSpeed;
        hb.SetHealth(lifeforce);
        jumpforce = Mathf.Sqrt(lifeforce);

        if (lifeforce >= 75 && lifeforce <= 100)
        {
            sRenderer.sprite = spriteArray[0];
        }
        else if (lifeforce >= 50 && lifeforce <= 75)
        {
            sRenderer.sprite = spriteArray[1];

        }
        else if (lifeforce >= 25 && lifeforce <= 50)
        {
            sRenderer.sprite = spriteArray[2];

        }
        else if (lifeforce >= 0 && lifeforce <= 25)
        {
            sRenderer.sprite = spriteArray[3];

        }
        else if (lifeforce <= 0 && gameOver == false)
        {
            sRenderer.sprite = spriteArray[4];
            hb.Die();
            gameOver = true;
        }

        /*
        if (onMovingPlatform != null)
        {
            vel.x += onMovingPlatform.rb2d.velocity.x;
        }
         */
        bool inputJump = Input.GetKeyDown(KeyCode.Space);
        if (inputJump && grounded)
        {
            vel.y = jumpforce;
            relativeVelocity.y = vel.y;
        }

        rb2d.velocity = vel;
    }

    protected override void Hurt(Vector3 impactDirection)
    {
        Debug.Log("Hurt!");

        if (Mathf.Abs(impactDirection.x) > Mathf.Abs(impactDirection.y))
        {
            TakeDamage();
        }
        else
        {
            if (impactDirection.y > 0.0f)
            {
                TakeDamage();
            }
           
            Vector2 vel = rb2d.velocity;
            vel.y = jumpforce;
            rb2d.velocity = vel;
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Damage taken!");

        //if (invulnerable)
        //{
        //    return;
        //}
       
        lifeforce -= poisondamage;
        hb.SetHealth(lifeforce);

        //HeartsUI.RemoveHeart();
        if (lifeforce <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //StartCoroutine(Invulnerability(1));
    }

    public void CollectCoin()
    {
        Debug.Log("Coin collected!");
        if (lifeforce < 75)
        {
            lifeforce += 25;

        }
        else
        {
            lifeforce = 100;
        }
        hb.SetHealth(lifeforce);
    }

    //IEnumerator Invulnerability(float time)
    //{
    //    invulnerable = true;
    //    for (int i = 0; i < time / 0.2f; i++)
    //    {
    //        sRenderer.color = Color.red;
    //        yield return new WaitForSeconds(0.1f);
    //        sRenderer.color = Color.white;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    invulnerable = false;
    //}
}
