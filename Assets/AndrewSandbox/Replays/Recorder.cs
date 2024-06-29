using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [Header("Prefab to Instantiate")]
    [SerializeField] private GameObject replayObjectPrefab;
    public Queue<ReplayData> recordingQueue { get; private set; }
    public List<Recording> listOfRecordings { get; private set; }
    public PrototypeInteractionCollider interactionCollider;

    // private bool isDoingReplay = false;
    private Recording recording;

    private List<bool> isDoingReplay;
    private List<GameObject> replayGameObjects;
    private Vector3 originalPosition;

    private void Awake()
    {
        listOfRecordings = new List<Recording>();
        recordingQueue = new Queue<ReplayData>();
        replayGameObjects = new List<GameObject>();
        isDoingReplay = new List<bool>();
        originalPosition = transform.position;
    }


    private void Update()
    {
        ListenForInput();
        DestroyReplay();
        if (listOfRecordings.Count > 0)
        {
            UpdateAllEchoes(listOfRecordings);
        }
    }

    public void RecordReplayFrame(ReplayData data)
    {
        recordingQueue.Enqueue(data);
        // Debug.Log("Recorded data: " + data.position + " // " + data.rotation);
    }

    private void StartReplay(int whichRecording)
    {
        isDoingReplay.Add(true);
        recording = new Recording(recordingQueue);
        recordingQueue.Clear();
        recording.InstantiateReplayObject(replayObjectPrefab);
        listOfRecordings.Add(recording);
        transform.position = originalPosition;
    }

    private void RestartReplay(Recording currentRecording, int whichRecording)
    {
        isDoingReplay[whichRecording] = true;
        currentRecording.RestartFromBeginning();
    }

    private void Reset(int whichReplay)
    {
        isDoingReplay[whichReplay] = false;
        recordingQueue.Clear();
        recording.DestroyReplayObjectIfExists();
        recording = null;
    }

    public void ListenForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartReplay(isDoingReplay.Count);
        }
    }

    public void UpdateAllEchoes(List<Recording> echoes)
    {
        int counter = 0;

        foreach (Recording echo in echoes)
        {
            if (echo.replayObject != null)
            {
                if (!isDoingReplay[counter])
                {
                    counter++;
                    continue;
                }

                bool hasMoreFrames = echo.PlayNextFrame();

                if (!hasMoreFrames)
                {
                    // Don't necessarily want this
                    RestartReplay(echo, counter);
                }
            }


            counter++;
        }
    }

    void DestroyReplay()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Pressed Q");
            GameObject currentReplay = null;

            if (interactionCollider.interactionCandidate != null)
            {
                Debug.Log("Found a thing");
                if (interactionCollider.interactionCandidate.GetComponent<ReplayObject>() != null)
                {
                    Debug.Log("Found Replay Object");
                    Debug.Log(interactionCollider.interactionCandidate.name);
                    currentReplay = interactionCollider.interactionCandidate;
                }
                else
                {
                    Debug.Log("Did not find Replay Object but deeper");
                    Debug.Log(interactionCollider.interactionCandidate.name);
                    return;
                }
            }
            else
            {
                Debug.Log("Did not find Replay Object");
                return;
            }

            Debug.Log("Made it here");
            Debug.Log("    " + interactionCollider.interactionCandidate.name);

            Destroy(interactionCollider.interactionCandidate);

            int counter = 0;

            foreach (Recording echo in listOfRecordings)
            {
                Debug.Log(counter);
                if (echo.replayObject == currentReplay)
                {
                    Destroy(echo.replayObject);
                    listOfRecordings.RemoveAt(counter);
                    isDoingReplay.RemoveAt(counter);
                    return;
                }

                counter++;
            }
            Debug.Log("Did not find the correct echo");
        }

    }
}
