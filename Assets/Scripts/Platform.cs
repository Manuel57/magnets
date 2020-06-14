using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool movingPlatform;
    [SerializeField] private float lowerBound;
    [SerializeField] private float upperBound;
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am a platform");
    }
    bool s = false;
    bool s2 = false;
    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime;

        if (movingPlatform)
        {
            s2 = false;
            if (Vector2.Dot(transform.position, Vector2.up) < lowerBound ||
                Vector2.Dot(transform.position, Vector2.right) < lowerBound ||
                Vector2.Dot(transform.position, Vector2.up) > upperBound ||
                Vector2.Dot(transform.position, Vector2.right) > upperBound)
            {

                if (!s) {
                    direction = -direction;
                    s2 = true;

                }

            }

            transform.position = new Vector3(transform.position.x + direction.x * delta * speed, transform.position.y + speed * direction.y * delta, transform.position.z);
            if (Vector2.Dot(transform.position, Vector2.up) < lowerBound ||
               Vector2.Dot(transform.position, Vector2.right) < lowerBound ||
               Vector2.Dot(transform.position, Vector2.up) > upperBound ||
               Vector2.Dot(transform.position, Vector2.right) > upperBound)
            {
                if (s2)
                {
                    s = true;
                }
            } else
            {
                s = false;
            }

        }
    }
}
