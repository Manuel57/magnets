using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;


public class Metal : MonoBehaviour
{


    [SerializeField] private Vector3 fieldSize = new Vector3(5,50); 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var items = PositionManager.GetObjectsAt(transform.position - fieldSize, transform.position + fieldSize);

        foreach (Anziehung item in items)
        {
            Debug.Log("TAG:  " + item.tag);
            if(item.Enabled)
            item.ForceTowards((transform.position-item.transform.position).normalized * 3);

        }
    }
}
