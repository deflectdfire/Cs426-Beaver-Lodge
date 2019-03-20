using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorTrap : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
