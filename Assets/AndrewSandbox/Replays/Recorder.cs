using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [Header("Prefab to INstantiate")]
    [SerializeField] private GameObject replayObjectPrefab;
    public Queue<ReplayData> recordingQueue { get; private set; }

    private bool isDoingReplay = false;
    private Recording recording;
    private void Awake()
    {
        recordingQueue = new Queue<ReplayData>();
    }


    private void Update()
    {
        ListenForInput();

        if (!isDoingReplay)
        {
            return;
        }

        bool hasMoreFrames = recording.PlayNextFrame();

        if(!hasMoreFrames)
        {
            // Don't necessarily want this
            RestartReplay();
        }
    }

    public void RecordReplayFrame(ReplayData data)
    {
        recordingQueue.Enqueue(data);
        // Debug.Log("Recorded data: " + data.position + " // " + data.rotation);
    }

    private void StartReplay()
    {
        isDoingReplay = true;
        recording = new Recording(recordingQueue);
        recordingQueue.Clear();
        recording.InstantiateReplayObject(replayObjectPrefab);

    }

    private void RestartReplay()
    {
        isDoingReplay = true;
        recording.RestartFromBeginning();
    }

    private void Reset()
    {
        isDoingReplay=false;
        recordingQueue.Clear();
        recording.DestroyReplayObjectIfExists();
        recording = null;
    }

    public void ListenForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartReplay();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Reset();
        }
    }
}
