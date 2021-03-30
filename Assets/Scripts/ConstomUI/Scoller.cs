using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoller : MonoBehaviour
{
    [SerializeField]
    private int Height = 2160;
    private Vector3 pos;
    private RectTransform t;
    // Start is called before the first frame update
    void Start()
    {
        t = (RectTransform)transform;
        pos = t.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.y < Height) {
            pos.y += 0.2f;
        }
        t.anchoredPosition = pos;
    }
}
