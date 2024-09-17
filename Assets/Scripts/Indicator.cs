using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetScale;
    private float speed = 1.0f;
    private bool isRed = true;
    private bool isGreen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, Time.deltaTime * speed);
        if (isRed && transform.localScale.x < targetScale.x * 1.5f)
        {
            isRed = false;
            isGreen = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (transform.localScale == targetScale) Destroy(gameObject);
    }

    public bool GetGreen()
    {
        return isGreen;
    }
}
