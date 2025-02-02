using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestBroken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 1; i <= 13; i++)
            {
                Animator pd = transform.GetChild(i - 1).GetComponent<Animator>();
                string t = i.ToString();
                Debug.Log("立方体_cell_0"+t+"|Action_001");
                pd.Play(t);
            }
        }
        
    }
}
