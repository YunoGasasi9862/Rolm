using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgrounds : MonoBehaviour
{
    private float length;
    private Camera pos;
    private float startPos;
    [SerializeField] float parallexEffect;
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;
        pos = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float temp= (pos.transform.position.x * (1 - parallexEffect));

        float distance = pos.transform.position.x * (parallexEffect);
        transform.position = new Vector3(distance + startPos, transform.position.y, transform.position.z);  //for parallex

        if(temp > startPos + length)
        {
            startPos += 1.89f*length;
        }
    }
}
