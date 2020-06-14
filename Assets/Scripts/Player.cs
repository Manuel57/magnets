using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Player : Anziehung
{


    [SerializeField] private GameObject[] spritePosNeg = new GameObject[2];

    public static int JumpSpeed = 40;

    public Vector2 Movement { get; set; }
    public Vector2 Movement2 { get; set; }


    public bool allowJump = true;

    public bool PosUp { get; set; } = true;
    public bool PlatformTouched { get; set; } = true;

    private Animator animator;
    private Animation animation;

    private Vector3 initialScale;
    private Vector3 minScale;

    private bool whileJump = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        PositionManager.Add(this);
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        initialScale = transform.localScale;
        minScale = transform.localScale / 2;
        Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (whileJump)
        {
            Debug.Log("X: " + transform.localScale.y + "  --  " + minScale.y);
            if (transform.localScale.y > minScale.y)
            {
                Debug.Log("CHANGING");
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - initialScale.y / 10);
                transform.position = new Vector3(transform.position.x, transform.position.y - initialScale.y / 100, transform.position.z);

            }
        }
        else
        {
            if (transform.localScale.y < initialScale.y)
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + initialScale.y / 10);
            }
        }
        Debug.Log("update");
        if (Movement == null || Movement.magnitude == 0)
        {
            return;
        }
        float delta = Time.deltaTime * 3;

        transform.position = new Vector3(transform.position.x + Movement.x * delta, transform.position.y, transform.position.z);




        Movement = Vector2.zero;

    }

    public void StartJumping(Player player2)
    {
        if (!allowJump) return;
        whileJump = true;
        Debug.Log("SET TRUE");

        if (spritePosNeg[0].activeSelf)
            spritePosNeg[0].GetComponent<Animator>().SetBool("IsJumping", true);
        if (spritePosNeg[1].activeSelf)
            spritePosNeg[1].GetComponent<Animator>().SetBool("IsJumping", true);
    }

    public void Switch(Player other)
    {
        PosUp = !PosUp;
        Enabled = !Enabled;
      //  spritePosNeg[0].SetActive(PosUp);
      //  spritePosNeg[1].SetActive(!PosUp);

        if (spritePosNeg[0].activeSelf)
            spritePosNeg[0].GetComponent<Animator>().SetBool("PositiveUp", PosUp);
        if (spritePosNeg[1].activeSelf)
            spritePosNeg[1].GetComponent<Animator>().SetBool("PositiveUp", PosUp);
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

        Debug.Log("SET FALSE");
            whileJump = false;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            allowJump = false;
            PlatformTouched = true;
        }
    }


    public void MoveE(Vector2 vector2)
    {
        Movement2 = vector2;
    }

    private bool gt = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.collider.tag.Equals("platform") || collision.collider.tag.Equals("brick"))
        {

            if (spritePosNeg[0].activeSelf) spritePosNeg[0].GetComponent<Animator>().SetBool("IsJumping", false);
            if (spritePosNeg[1].activeSelf) spritePosNeg[1].GetComponent<Animator>().SetBool("IsJumping", false);

            allowJump = true;
        }



    }

}
