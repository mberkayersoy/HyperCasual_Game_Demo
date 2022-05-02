using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObject : MonoBehaviour
{
    public void Cut(Transform cutter)
    {
        if (cutter.transform.position.x < gameObject.transform.position.x)
        {
            // left
            float y = transform.localScale.y;
            y -= transform.position.x;
            float distance = y + cutter.position.x;
            Debug.Log("dist : " + distance);
            if (distance / 2 > 0)
            {
                print("cut left");
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - distance / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + distance / 2, transform.position.y, transform.position.z);
                // gameObject.SetActive(false);
                GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                
                piece.transform.localScale = new Vector3(transform.localScale.x, distance / 2, transform.localScale.z);
                piece.transform.rotation = transform.rotation;
                piece.transform.position = new Vector3(-(y - piece.transform.localScale.y), transform.position.y, transform.position.z);
                piece.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
                piece.AddComponent<Rigidbody>();

            }
        }
        else //if (cutter.transform.position.x > gameObject.transform.position.x)
        {
            float y = transform.localScale.y;
            y += transform.position.x;
            float distance = y - cutter.position.x;
            Debug.Log("dist : " + distance);

            if (distance / 2 > 0)
            {
                print("cut right");
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - distance / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - distance / 2, transform.position.y, transform.position.z);

                GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                piece.transform.localScale = new Vector3(transform.localScale.x, distance / 2, transform.localScale.z);
                piece.transform.rotation = transform.rotation;
                piece.transform.position = new Vector3(y - piece.transform.localScale.y, transform.position.y, transform.position.z);
                piece.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
                piece.AddComponent<Rigidbody>();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Barrier")
        {
            print("collector");
            Cut(other.gameObject.transform);
        }
    }
}