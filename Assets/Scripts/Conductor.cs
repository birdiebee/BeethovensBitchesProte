using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float bpm;
    public float secPerBeat;
    [SerializeField]
    private int beatsPerSet;
    private int beatCounter = 0;
    public float audioPos;
    public float beatPos;
    private float audioTimeElapsed;
    private int lastBeat = 0;
    AudioSource audioSource;
    private float beatOffset;
    public static Conductor instance;
    private float lastAudioPos = 0.0f;
    private float lastBeatPos = 0.0f;
    private double lastDSP = 0.0f;
    [SerializeField]
    private List<GameObject> keys;
    private bool needSpawn = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        secPerBeat = 60.0f / bpm;
        beatOffset = secPerBeat;
        audioTimeElapsed = (float)AudioSettings.dspTime;
        lastDSP = AudioSettings.dspTime;
        audioSource.Play();
    }

    void Update()
    {
        if(lastDSP != AudioSettings.dspTime)
        {
            lastDSP = AudioSettings.dspTime;
        }
        if(needSpawn)
        {
            needSpawn = false;
            InitializeRandomIndicator();
        }
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        lastAudioPos = audioPos;
        audioPos = (float)(AudioSettings.dspTime - audioTimeElapsed - beatOffset);
        lastBeatPos = beatPos;
        beatPos = audioPos / secPerBeat;
        if ((int)beatPos > lastBeat)
        {
            lastBeat = (int)beatPos;
            if (++beatCounter > beatsPerSet)
            {
                needSpawn = true;
                beatCounter = 0;
            }
            else beatCounter++;
        }
    }
    
    private void InitializeRandomIndicator()
    {
        int index = Random.Range(0, keys.Count);
        keys[index].GetComponent<Scorer>().SpawnIndicator();
    }
}
