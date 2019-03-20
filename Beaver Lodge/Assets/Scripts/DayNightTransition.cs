using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightTransition : MonoBehaviour
{
    public Light lt;
    public GameObject predator;
    private float startTime;
    private bool night;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        night = false;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        if (t > 60.0f)
        {
            lt.intensity = 1.0f;
            night = false;
            predator.SetActive(false);
            startTime = Time.time;
        }
        else if (t > 50.0f)
        {
            lt.intensity = 0.5f;
        }
        else if (t > 30.0f)
        {
            lt.intensity = 0.0f;
            night = true;
            predator.SetActive(true);
        }
        else if (t > 20.0f)
        {
            lt.intensity = 0.5f;
        }
    }

    bool IsNight()
    {
        return night;
    }
}
