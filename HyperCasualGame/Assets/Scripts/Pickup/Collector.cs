using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public static int length;

    /*public void Barrier()
    {
        length--;
    }*/
     void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Pickup")
        {
            /*GameObject collector = GameObject.Find("Collector");
            length++;
            other.gameObject.GetComponent<CollectibleObject>().Collected();
            other.gameObject.GetComponent<CollectibleObject>().SetIndex(length);
            other.gameObject.transform.parent = collector.transform;
            other.gameObject.tag = "Collector";*/
            //other.AddComponent<Collector>();
            transform.localScale = new Vector3(gameObject.transform.localScale.x , gameObject.transform.localScale.y + 0.009f, 
            gameObject.transform.localScale.z);
        }
    }
    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "Finish")
        {
            print("pipe");
        }
        
        /*if (other.gameObject.tag == "Barrier")
        {
            print("barrier");
            GetComponentInParent<Animator>().SetTrigger("Failed");
        }*/
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.tag == "Pipe")
        {
            GetComponentInParent<Animator>().SetTrigger("isHanging");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Pipe")
        {
            GetComponent<Animator>().SetTrigger("Push");
        }
    }


    public int GetLength()
    {
        return length;
    }
    public int SetLength()
    {
        return length++;
    }

}
