using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialRotation : MonoBehaviour
{
    public Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vector * Time.deltaTime);
    }
}
