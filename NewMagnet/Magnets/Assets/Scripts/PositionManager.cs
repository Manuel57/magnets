using UnityEngine;
using UnityEditor;

public class PositionManager : ScriptableObject
{

    public static System.Collections.ArrayList AllPositionObjects = new System.Collections.ArrayList();

    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
    }

    public static System.Collections.ArrayList GetObjectsAt(Vector3 l, Vector3 h)
    {
        var n = new System.Collections.ArrayList();
        foreach (var item in AllPositionObjects)
        {
            Debug.Log((item as MonoBehaviour).tag);
            if ((item as MonoBehaviour).transform.position.x > l.x && (item as MonoBehaviour).transform.position.x < h.x &&
                (item as MonoBehaviour).transform.position.y > l.y && (item as MonoBehaviour).transform.position.y < h.y)
            {
                Debug.Log((item as MonoBehaviour).tag);
                n.Add(item);
            }


        }
        return n;
    }

    public static void Add(Anziehung obj)
    {
        AllPositionObjects.Add(obj);
    }
}