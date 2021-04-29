using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fovChecker : MonoBehaviour
{
    public Material[] materials;
    private bool c_point;
    private Camera[] cameras;
    private GameObject _point;
    private int count, _count;
    private Vector3[] sc;
 
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        cameras = new Camera[3];
        for (int i = 0; i < 3; i++)
        {
            // cameras[i] = GameObject.Find(System.String.Format("cam_{0}", i+1)).GetComponent<Camera>();
            cameras[i] = GameObject.FindGameObjectWithTag(System.String.Format("Camera{0}", i + 1)).GetComponent<Camera>();

        }
        _point = GameObject.Find("_point");
        float plank = transform.localScale.x * .25f;
        _count = 0;
        sc[1] = transform.localScale + new Vector3(-plank * 1, 0f, -plank * 1); //0 to 1
        sc[2] = transform.localScale + new Vector3(-plank * 2, 0f, -plank * 2); //1 to 2
        sc[3] = transform.localScale + new Vector3(-plank * 3, 0f, -plank * 3); //2 to 3
        sc[0] = transform.localScale;

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }

    // Update is called once per frame
    void Fixedupdate()
    {
        count = 0;
        for (int i = 0; i < 3; i++)
        {
            c_point = cameras[i].canSee(_point.transform.position);
            count += (c_point ? 1 : 0);
        }
        if(count != _count) {
            rend.sharedMaterial = materials[count];
            transform.localScale = sc[count];
        }
        _count = count;
    }

}
public static class CameraExtensions
{
    public static bool canSee(this Camera cam, Vector3 inp)
    {
        Vector3 cp = cam.WorldToViewportPoint(inp);
        if (cp.x <= 1.0f && cp.x >= 0.0f)
        {
            if (cp.y <= 1.0f && cp.y >= 0.0f)
            {
                if (cp.z > 0.0f && cp.z < cam.nearClipPlane)
                {
                    return true;
                }
            }
        }
        return false;
    }
}