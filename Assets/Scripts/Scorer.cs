using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public GameObject indicatorPrefab;
    private GameObject currIndicator;
    [SerializeField]
    private GameObject key;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnIndicator()
    {
        if(currIndicator == null)
        {
            currIndicator = Instantiate(indicatorPrefab, transform);
            currIndicator.transform.position = key.transform.position;
        }
    }

    public bool CheckIndicator()
    {
        if (currIndicator != null) return currIndicator.GetComponent<Indicator>().GetGreen();
        return false;
    }
}
