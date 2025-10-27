using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{

    public Transform target;
    float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
