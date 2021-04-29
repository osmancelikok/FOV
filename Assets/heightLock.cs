using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightLock : MonoBehaviour
{
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 c = transform.position;
        transform.position = new Vector3(c.x, height, c.z);
    }
}
