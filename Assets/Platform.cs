using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool movingPlatform;
    [SerializeField] private float lowerBound;
    [SerializeField] private float upperBound;
    [SerializeField] private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime ;

        if (movingPlatform)
        {
            if (Vector2.Dot(direction,transform.position) <= lowerBound || Vector2.Dot(direction, transform.position) >= upperBound)
            {
                direction = -direction;
            }

            transform.position = new Vector2(transform.position.x + direction.x * delta, transform.position.y + direction.y * delta);
        }
    }
}
