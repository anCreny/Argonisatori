using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{

    public int Number { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Number = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        Number = UnityEngine.Random.Range(0, 255);
    }
}
