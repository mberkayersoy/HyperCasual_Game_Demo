using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	public float followSpeed = 2f;
	public Vector3 distance;
	private void LateUpdate() 
	{
		transform.position = Vector3.Lerp(transform.position, target.transform.position + distance, followSpeed * Time.deltaTime);
	}
}
