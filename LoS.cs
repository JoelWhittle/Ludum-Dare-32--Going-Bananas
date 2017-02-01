using UnityEngine;
using System.Collections;

public class LoS : MonoBehaviour {

	public GameObject Owner;


	void OnTriggerEnter (Collider collision)
	{
		
		if(collision.gameObject.tag=="Player")
		{
			
		if(Owner.GetComponent<Guard>().bCanFire)
			{
			
			Owner.GetComponent<Guard>().FireTranq();

			}
		}
	}


}
