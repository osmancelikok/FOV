using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    PlayerCollider pc;
    public int SumArray;
    public int SumArrayOld;

    void Start()
    {
      pc = FindObjectOfType<PlayerCollider>();
      SumArray = pc.SumArray;
      SumArrayOld = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
