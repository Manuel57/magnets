using UnityEngine;
using System.Collections;

public class Anziehung : MonoBehaviour
{

    public bool Enabled { get; set; }

    public void ForceTowards(Vector2 vector)
    {
        GetComponent<Rigidbody2D>().AddForce(vector, ForceMode2D.Impulse);
    }
}
