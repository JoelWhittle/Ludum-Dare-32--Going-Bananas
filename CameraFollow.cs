using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;


	void FixedUpdate()
	{

		gameObject.transform.position = new Vector3 (target.transform.position.x,gameObject.transform.position.y,target.transform.position.z);

	}
}
