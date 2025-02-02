using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    public float FixY = -90f;
    public List<Transform> targets = new();
    private bool init = false;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (init == false)
        {
            init = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                targets.Add(transform.GetChild(i).GetChild(0));
            }
        }
        foreach(var tg in targets)
        {
            // -90为了让图形直立
            var t = new Vector3(Camera.main.transform.position.x, FixY, Camera.main.transform.position.z) - tg.transform.position;
            tg.transform.forward = new Vector3(t.x, t.y, t.z);
        }
    }
}
