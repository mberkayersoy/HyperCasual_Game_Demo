using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {   print("turnpoint");
            other.transform.rotation = Quaternion.Euler(0, 90, 0);
            other.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
        }

    }
}
