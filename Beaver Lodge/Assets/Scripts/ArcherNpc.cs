using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherNpc : MonoBehaviour
{
    private Animator a;
    public Transform[] destinations;
    private Transform t;
    private NavMeshAgent n;
    private int destPoint;

    private float waitTime;
    public float startWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        t = GetComponent<Transform>();
        n = GetComponent<NavMeshAgent>();
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
            

        if (!n.pathPending && n.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
            
    }

    void GoToNextPoint()
    {
        if (destinations.Length == 0)
            return;

        n.destination = destinations[destPoint].position;
        destPoint = (destPoint + 1) % destinations.Length;
    }

}
