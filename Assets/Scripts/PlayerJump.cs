using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Singleton<PlayerJump>
{
    #region Varibles
    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float forceX, forceY, thresholdX = 7.0f, thresholdY = 14.0f;

    private bool setPower, didJump = false;
    #endregion

    #region Main Methods
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPower();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(didJump)
        {
            didJump = false;

            if(collision.tag == "Platform")
            {
                if(GameManager.Instance != null)
                {
                    GameManager.Instance.CreateNewPlatfromAndLerp(collision.transform.position.x);
                }
            }

            if(collision.tag == "Death")
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region Unity Utilities
    void SetPower ()
    {
        if (setPower)
        {
            forceX += thresholdX * Time.deltaTime;
            forceY += thresholdY * Time.deltaTime;

            if (forceX > 6.5f)
            {
                forceX = 6.5f;
            }

            if (forceY > 13.5f)
            {
                forceY = 13.5f;
            }
        }
       
    }

    public void SetPower (bool setPower)
    {
        this.setPower = setPower;

        if(!setPower)
        {
            Jump();
        }
    }

    void Jump ()
    {
        myBody.velocity = new Vector2(forceX, forceY);

        forceX = forceY = 0f;

        didJump = true;
    }
    #endregion
}
