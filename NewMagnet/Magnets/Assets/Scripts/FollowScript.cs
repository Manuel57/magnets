using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{


    public Transform target1;
    public Transform target2;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3((target1.position.x + target2.position.x)/2, target1.position.y, transform.position.z), 0.125f);
    }
}
