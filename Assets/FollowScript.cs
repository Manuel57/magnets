using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{


    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position =
           Vector2.Lerp(
                transform.position, target.transform.position + offset, smoothSpeed);

        transform.LookAt(target);
    }
}
