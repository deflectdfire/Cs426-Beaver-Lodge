using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CirclePath : MonoBehaviour
{
    public Transform[] points;
    private Transform t;
    private NavMeshAgent n;
    private Animator a;
    private int destPoint;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        n = GetComponent<NavMeshAgent>();
        a = GetComponent<Animator>();
    }

    // Update is called once per framse
    void FixedUpdate()
    {
        if (!n.pathPending && n.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        n.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}