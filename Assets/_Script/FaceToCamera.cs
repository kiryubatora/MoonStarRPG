using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    List<Transform> targets = new();

    // Start is called before the first frame update
    void Start()
    {
        foreach(var child in transform.GetComponentsInChildren<Transform>())
        {
            targets.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var tg in targets)
        {
            if(tg.gameObject.CompareTag("MainCamera") 
                || tg.GetComponent<SpriteRenderer>() == null 
                || tg.gameObject.name == "Canvas" 
                || tg.GetComponent<Canvas>()) continue;
            tg.transform.LookAt(new Vector3(Camera.main.transform.position.x, tg.transform.position.y, Camera.main.transform.position.z));             
        }
    }
}
