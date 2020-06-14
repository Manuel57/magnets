using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public bool swap { get; set; } = false;
    public bool lastIn { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(worldPosition);

        if (Input.GetMouseButtonDown(0))
        {

            if (worldPosition.x > -3 && worldPosition.x < 3 && worldPosition.y > -1.5 && worldPosition.y < 1.5)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (worldPosition.x > -3 && worldPosition.x < 3 && worldPosition.y > -1.5 && worldPosition.y < 1.5)
        {
            if (!lastIn)
            {
                swap = !swap;
                GetComponent<Animator>().SetBool("swap", swap);
                lastIn = true;
            }

        }
        else
        {
            if (lastIn)
            {
                swap = !swap;
                GetComponent<Animator>().SetBool("swap", swap);
                lastIn = false;
            }

        }


    }
}
