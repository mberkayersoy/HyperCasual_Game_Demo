using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject tryAgain;
    public GameObject nextLevel;
    public GameObject score;

    private void Update() 
    {
        if (gameObject.transform.position.y < 1)
        { 
            tryAgain.SetActive(true);
            score.SetActive(false);
                   
        }
        
    }
    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "Finish")
        {
            nextLevel.SetActive(true);
            score.SetActive(false);
        }

        if (gameObject.transform.position.y < 1 || other.gameObject.tag == "Barrier")
        { 
            tryAgain.SetActive(true);
            score.SetActive(false);       
        }

    }
}
