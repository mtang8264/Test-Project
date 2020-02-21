using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 startingPos;
    Vector3 goalPos;

    public float dist;
    public float shakeTime;

    private float startTime;

    private Coroutine shake;

    public enum State {Go, Back};
    public State state;

    void Start()
    {
        startingPos = transform.position;

        goalPos = startingPos + dist * (new Vector3(Random.value, Random.value, Random.value)).normalized;
    }

    void Update()
    {
        if(state == State.Go)
        {
            transform.position = Vector3.Lerp(startingPos, goalPos, 1 - ((startTime + shakeTime - Time.time) / shakeTime));

            if(Time.time >= startTime + shakeTime)
            {
                goalPos = startingPos;
                startingPos = transform.position;
                startTime = Time.time;
                state = State.Back;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(startingPos, goalPos, 1 - ((startTime + shakeTime - Time.time) / shakeTime));
            
            if(Time.time >= startTime + shakeTime)
            {
                startingPos = transform.position;
                goalPos = startingPos + dist * (new Vector3(Random.value, Random.value, Random.value)).normalized;
                startTime = Time.time;
                state = State.Go;
            }
        }
    }
}
