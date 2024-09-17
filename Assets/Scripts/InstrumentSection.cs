using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent.gameObject.GetComponent<Scorer>().CheckIndicator())
        {
            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("Miss");
        }
        Destroy(collision.gameObject);
    }
}
