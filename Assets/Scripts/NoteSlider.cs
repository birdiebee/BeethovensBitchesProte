using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NoteSlider : MonoBehaviour
{
    private Transform destinationTransform;
    private bool hasDestination = false;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasDestination)
        {
            float step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, destinationTransform.position, step);
        }
    }

    public void SetDestination(Transform destination, float noteSpeed)
    {
        destinationTransform = destination;
        speed = noteSpeed;
        hasDestination = true;
    }
}
