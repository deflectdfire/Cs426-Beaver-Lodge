using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightTransition : MonoBehaviour
{
    public Light lt;
    public GameObject predator;
    public GameObject fireflies;
    public GameObject lt1;
    public GameObject lt2;
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public GameObject lantern;
    public AudioClip audioMorning;
    public AudioClip audioNight;
    public AudioSource audioSource;
    private float startTime;
    private bool night;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        night = false;
        audioSource.PlayOneShot(audioMorning, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        if (t > 60.0f)
        {
            lt.intensity = 1.0f;
            startTime = Time.time;

            if (night)
            {
                night = false;
                audioSource.Stop();
                audioSource.PlayOneShot(audioMorning, 0.5f);
                lt1.SetActive(false);
                lt2.SetActive(false);
                torch1.SetActive(false);
                torch2.SetActive(false);
                torch3.SetActive(false);
                lantern.SetActive(false);
                fireflies.SetActive(false);
                predator.SetActive(false);
            }
        }
        else if (t > 50.0f)
        {
            lt.intensity = 0.5f;
        }
        else if (t > 30.0f)
        {
            lt.intensity = 0.0f;

            if (!night)
            {
                night = true;
                audioSource.Stop();
                audioSource.PlayOneShot(audioNight, 0.5f);
                predator.SetActive(true);
            }
        }
        else if (t > 20.0f)
        {
            lt.intensity = 0.5f;
            lt1.SetActive(true);
            lt2.SetActive(true);
            torch1.SetActive(true);
            torch2.SetActive(true);
            torch3.SetActive(true);
            lantern.SetActive(true);
            fireflies.SetActive(true);
        }
    }

    bool IsNight()
    {
        return night;
    }
}
