using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    private bool playeryTogether = false;

    private int stoss = 40;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update manager");

        if (Input.GetKey(KeyCode.A))
        {
            player1.Left();
            if (playeryTogether) player2.Move(new Vector2(-0.3f,0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            player1.Right();
            if (playeryTogether) player2.Move(new Vector2(0.3f,0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player1.Jump(player2);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2.Left();
            if (playeryTogether) player1.Move(new Vector2(-0.3f,0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player2.Right();
            if (playeryTogether) player1.Move(new Vector2(0.3f,0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player2.Jump(player1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player1.Switch(player2);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player2.Switch(player1);
        }

        if (ArePlayersInMagetArea(4))
        {
            if (player1.PosUp && player2.PosUp || !player1.PosUp && !player2.PosUp)
            {
                playeryTogether = false;

                if (player1.transform.position.y > player2.transform.position.y)
                {

                    player1.ForceTowards(Vector2.up * stoss);
                    if (stoss > 7)
                    {
                        stoss -= 3;
                        player1.allowJump = false;
                    }
                    else
                    {
                        stoss = 7;
                    }
                    player1.PlatformTouched = false;


                }
                else
                {

                    player2.ForceTowards(Vector2.up * stoss);
                    if (stoss > 7)
                    {
                        stoss -= 3;
                        player2.allowJump = false;
                    }
                    else
                    {
                        stoss = 7;
                    }
                    player2.PlatformTouched = false;
                }
            }
            else
            {
                if (player1.transform.position.y > player2.transform.position.y)
                {
                    playeryTogether = true;
                    player1.ForceTowards(Vector2.down * 5);
                    player2.ForceTowards(Vector2.up * 7);

                }
                else
                {
                    playeryTogether = true;

                    player2.ForceTowards(Vector2.down * 5);
                    player1.ForceTowards(Vector2.up * 7);

                }
            }


        }
         if (ArePlayersInMagetArea(6))
        {
            if (player1.PosUp && !player2.PosUp || !player1.PosUp && player2.PosUp)
            {
                if (player1.transform.position.y > player2.transform.position.y)
                {
                    playeryTogether = true;
                    player1.ForceTowards(Vector2.down * 13);
                    player2.ForceTowards(Vector2.up * 11);

                }
                else
                {
                    playeryTogether = true;

                    player2.ForceTowards(Vector2.down * 13);
                    player1.ForceTowards(Vector2.up * 11);

                }
            }
        }
        else
        {
            if (player1.PlatformTouched && player1.transform.position.y > player2.transform.position.y && stoss <= 7)
            {
                stoss = 20;
            }

            if (player2.PlatformTouched && player2.transform.position.y > player2.transform.position.y && stoss <= 7)
            {
                stoss = 20;
            }
            playeryTogether = false;

        }


    }

    private bool ArePlayersInMagetArea(int yD)
    {
        if ((Mathf.Abs(player1.transform.position.x - player2.transform.position.x) < 0.5) &&
            (Mathf.Abs(player1.transform.position.y - player2.transform.position.y) < yD))
        {
            Debug.Log("JETT");
            return true;
        }

        return false;
    }
}
