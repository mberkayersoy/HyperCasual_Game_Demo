using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDiamond : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.up * 50 * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Collector")
        {   
            ScoreText.diamondAmount += 1;
            Destroy(gameObject);
        }    
    }
}
