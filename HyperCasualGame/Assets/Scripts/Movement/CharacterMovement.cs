using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Transform topPoint;
    [SerializeField] Transform bottomPoint;
    public GameObject character;
    public GameObject root;
    [SerializeField] float speed = 1;
    Rigidbody rb;
    Vector3 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //root.transform.position += new Vector3(0, 0.1f, 0);
        }   

        if (Input.GetMouseButton(0))
        {
            root.transform.localRotation = Quaternion.Euler(0, 90, -180);
            //root.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
            GetComponent<Animator>().SetTrigger("Climb");     
        }

        else
        {   
            /*if (IsGrounded())
            character.transform.localPosition -= new Vector3(0,1,0) * Time.deltaTime;*/
            
            //root.transform.position -= new Vector3(0, 0.5f, 0);
            root.transform.localRotation = Quaternion.Euler(90, 0, -90);
            //root.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Animator>().SetTrigger("Push");
            //character.transform.Translate(Vector3.down * Time.deltaTime * 0.1f);
        }
        if (!IsGrounded())
        {
            GetComponent<Animator>().SetTrigger("Hang");
        }
        else
        {   
            GetComponent<Animator>().SetTrigger("Push");
        }

    }

    private void FixedUpdate() 
    {
        Movement();
    }

    private void Movement()
    {
        rb.AddForce(speed * transform.forward, ForceMode.Force);
    }

    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundChecker>().isGrounded;
    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Finish")
        {
            speed = 0;
            root.SetActive(false);
            GetComponent<Animator>().SetTrigger("Finish");
        }

        if (other.gameObject.tag == "Barrier")
        {   
            GetComponent<Animator>().SetTrigger("Failed");
        }
    }

}
