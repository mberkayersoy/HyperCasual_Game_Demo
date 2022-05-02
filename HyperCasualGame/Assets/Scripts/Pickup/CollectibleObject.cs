using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    bool isCollected;
    int index;
    public Collector collector;
    private void Start() 
    {
        isCollected = false;
    }
    private void Update() 
    {
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Collector")
        {
            Destroy(gameObject);
        }
    }
}
