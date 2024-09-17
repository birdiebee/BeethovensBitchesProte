using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform Jpos;
    [SerializeField]
    private Transform Epos;
    [SerializeField]
    private Transform Fpos;
    [SerializeField]
    private Transform Ipos;
    [SerializeField]
    private GameObject notePrefab;
    [SerializeField]
    private float noteSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            SpawnNote(Jpos);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnNote(Epos);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnNote(Fpos);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnNote(Ipos);
        }
    }

    private void SpawnNote(Transform destination)
    {
        GameObject note = Instantiate(notePrefab, transform);
        note.GetComponent<NoteSlider>().SetDestination(destination, noteSpeed);
    }
}
