using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    public Transform[] points;
    public GameObject attackWolf;
    public GameObject player;
    private Transform t;
    private NavMeshAgent n;
    private Animator a;
    private int destPoint;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        n = GetComponent<NavMeshAgent>();
        a = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!n.pathPending && n.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        a.SetBool("Run", true);
        n.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            n.isStopped = true;
            a.SetBool("Run", false);
            a.SetTrigger("Attack");
            transform.LookAt(player.transform);
            Invoke("Reset", 1.5f);
        }
    }

    void Reset()
    {
        attackWolf.SetActive(false);
        t.SetPositionAndRotation(new Vector3(177.5f, 0.2f, 248.6f), new Quaternion(0f, 0f, 0f, 0f));
    }
}