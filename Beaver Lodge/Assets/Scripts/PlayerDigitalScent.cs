using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDigitalScent : MonoBehaviour
{
    private int currIndex;
    GameObject[] beaverScent;
    float currTime;
    // Start is called before the first frame update
    void Start()
    {
        currIndex = 0;
        beaverScent = new GameObject[20];
        for(int i = 0; i < 20; ++i)
        {
            beaverScent[i] = new GameObject();
            beaverScent[i].AddComponent<BoxCollider>();
            beaverScent[i].AddComponent<Rigidbody>();
            beaverScent[i].GetComponent<Rigidbody>().useGravity = false;
            beaverScent[i].tag = "Scent";
        }
        currTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - 5 < currTime)
            return;

        
        beaverScent[currIndex].transform.position = this.transform.position;
        float height = beaverScent[currIndex].transform.position.y;
        beaverScent[currIndex].transform.Translate(0, -height-5, 0);

        Debug.Log("Adding Digital Scent " + currIndex);
        if (currIndex < 19)
            currIndex++;
        else
            currIndex = 0;
    }

    int inWater()
    {
        //if (this.GetComponent.)

        return 0;
    }
}
