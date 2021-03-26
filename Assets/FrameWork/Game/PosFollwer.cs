using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosFollwer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tar;

    // Update is called once per frame
    void Update()
    {
        transform.position = tar.position;   
    }
}
