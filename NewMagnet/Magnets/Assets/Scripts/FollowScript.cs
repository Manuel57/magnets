
using UnityEngine;

public class FollowScript : MonoBehaviour
{


    public Transform target1;
    public Transform target2;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x, Mathf.Max(4.8f, (target1.position.y + target2.position.y) / 2), transform.position.z), 0.125f);

        Debug.Log(Mathf.Abs(target1.position.y - target2.position.y));

        GetComponent<Camera>().orthographicSize = 15.2f + Mathf.Max(0, Mathf.Abs(target1.position.y - target2.position.y) - 10);
    }
}
