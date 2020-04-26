using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{


    public Transform target1;
    public Transform target2;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, (target1.position.y + target2.position.y) / 2, transform.position.z), 0.125f);
    }
}
