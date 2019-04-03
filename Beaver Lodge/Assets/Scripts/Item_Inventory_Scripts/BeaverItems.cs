using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverItems : MonoBehaviour
{
    public ItemClass scriptableObjectRepresentation;

    public void Start()
    {

    }

    public void Update()
    {


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}


