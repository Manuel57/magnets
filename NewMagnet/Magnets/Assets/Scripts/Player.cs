using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Anziehung
{

    public static int JumpSpeed = 30;

    [SerializeField] private MagnetAction pos;
    [SerializeField] private MagnetAction neg;
    public Vector2 Movement { get; set; }


    public bool allowJump = true;

    public bool PosUp { get; set; } = true;
    public bool PlatformTouched { get; set; } = true;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        PositionManager.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        if (Movement == null || Movement.magnitude == 0)
        {
            return;
        }
        float delta = Time.deltaTime * 3;

        transform.position = new Vector3(transform.position.x + Movement.x * delta, transform.position.y, transform.position.z);


        Movement = Vector2.zero;

    }

    public void Switch(Player other)
    {
        PosUp = !PosUp;
        Enabled = !Enabled;
    }



    public void Move(Vector2 dir)
    {
        Movement = dir;
    }

    public void Left(Vector2 dir)
    {
        Movement = dir;
    }

    public void Left()
    {
        Left(Vector2.left);
    }
    public void Right(Vector2 dir)
    {
        Movement = dir;
    }
    public void Right()
    {
        Right(Vector2.right);
    }

    public void Jump(Player other)
    {
        if (allowJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            allowJump = false;
            PlatformTouched = true;
        }
    }


    private bool gt = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.collider.tag.Equals("platform") || collision.collider.tag.Equals("brick"))
        {
            allowJump = true;
        }



    }

}
