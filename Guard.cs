using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public GameManager cGameManager;
	public GameObject goMountPoint;

	public float fReloadTime;

	public bool bCanFire;
	public GameObject AI;

	public GameObject goPlayer;


	public AudioSource aGunFire;

	void Start()
	{
		bCanFire = true;
		cGameManager = GameObject.Find ("_GameManager").GetComponent<GameManager> ();
		cGameManager.ObjectsToClean.Add (gameObject);
		goPlayer = GameObject.Find ("GorillaWalk");



	}

	//Check for dammage
	void OnCollisionEnter (Collision collision)
	{

		if(collision.gameObject.tag=="HurtsAI")
		{

			cGameManager.ObjectsToClean.Remove(gameObject);
			Destroy(gameObject);
			cGameManager.iScore++;

			goPlayer.GetComponent<ApeController>().aBananaSplat.Play ();
		}
	}


	public void FireTranq()
	{
		if(bCanFire == true)
		{

		aGunFire.Play ();
		Instantiate (cGameManager.cPrefabs.goTranq, goMountPoint.transform.position, gameObject.transform.rotation);
		bCanFire = false;
		StartCoroutine(ReloadWeapon());
		}
	}



	void FixedUpdate()
	{
//		if (cGameManager.bGameStillGoing () && bCanFire) {
//			Vector3 fwd = transform.TransformDirection (Vector3.forward);
//			RaycastHit hit = new RaycastHit();
//			if (Physics.Raycast(gameObject.transform.position, transform.forward, out hit, 30 ))
//			
//			{
//
//				
//				if(hit.collider.gameObject.name == "GorillaWalk" || hit.collider.gameObject.tag == "Player")
//				{
//					Debug.Log("1");
//
//					FireTranq();
//				}
//			}
//		}

		if (gameObject.transform.position.y < 1) 
		{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x,1,gameObject.transform.position.z);

		}

		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude != 0f && !gameObject.GetComponent<Animation>().IsPlaying("Take 001") )
		{
			gameObject.GetComponent<Animation>().Play("Take 001");

		}

		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude == 1f && gameObject.GetComponent<Animation>().IsPlaying("Take 001") )
		{
			gameObject.GetComponent<Animation>().Stop ();
			
		}
	}


	public IEnumerator ReloadWeapon()
	{
		if(cGameManager.bGameStillGoing())
		{


			yield return new WaitForSeconds(fReloadTime);
			bCanFire = true;

		}
	}
}
