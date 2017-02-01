using System;
using UnityEngine;
using System.Collections;


	public class ApeController : MonoBehaviour
	{

	public int iHealth;
	public int iMaxHealth;
	public int iMaxSpeed;
	Vector3 AxisInput;
	public float Speed;
	public Rigidbody rb;

	public bool bCanFireBananarang;

	public GameManager cGameManger;
	public GameObject BananarangMount;

	public float fRegenRate;
	public float fTranqRecoveryRate;

	public float fBananarangRegenRate;




	public AudioSource aThrowBanana;
	public AudioSource aGetHurt;
	public AudioSource aBananaSplat;
	public AudioSource aFootsteps;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
		bCanFireBananarang = true;

		StartCoroutine (Regen ());

		iHealth = iMaxHealth;
		Speed = iMaxSpeed;
	}
	void FixedUpdate()
	{

		//Move
		Vector3 AxisInput = (new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")));
		
		rb.AddForce(AxisInput*Speed, ForceMode.VelocityChange ); 


		//rotate ToDo


		gameObject.transform.rotation = Quaternion.LookRotation(gameObject.GetComponent<Rigidbody>().velocity);
		



		//Attacks

		//Bananarang

		if(Input.GetKeyDown(KeyCode.Space) && bCanFireBananarang)
		{
			StartCoroutine(FireBananarang());
		}





		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1f && !gameObject.GetComponent<Animation> ().IsPlaying("Take 001"))
		{
			gameObject.GetComponent<Animation> ().Play ("Take 001");

		}


		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude < 1f && gameObject.GetComponent<Animation> ().IsPlaying("Take 001"))
		{
			gameObject.GetComponent<Animation> ().Stop();
			
		}

			
		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1f && !aFootsteps.isPlaying)
		{
			aFootsteps.Play();

		}
		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude <1f && aFootsteps.isPlaying)
		{
			aFootsteps.Stop ();
			
		}
	}

	//Check for dammage
	void OnCollisionEnter (Collision collision)
		{
	

		if(collision.gameObject.tag=="Tranq")
			{
			cGameManger.ObjectsToClean.Remove(collision.gameObject);
			Destroy(collision.gameObject);
			iHealth --;
			Speed = Speed - collision.gameObject.GetComponent<Tranq>().fSlowStrength;

			aGetHurt.Play();
			}
	}


	public IEnumerator FireBananarang ()
	{
		aThrowBanana.Play ();
		bCanFireBananarang = false;

		GameObject goBananarang = (GameObject)Instantiate (cGameManger.cPrefabs.goBanana, BananarangMount.transform.position,gameObject.transform.rotation);
		yield return new WaitForSeconds (fBananarangRegenRate);
		bCanFireBananarang = true;
	}



	public IEnumerator Regen()
	{
		if(cGameManger.bGameStillGoing())
		{
		Speed = Speed + fTranqRecoveryRate;
		iHealth++;

		yield return new WaitForSeconds(fRegenRate);

		StartCoroutine (Regen());

		if(Speed > iMaxSpeed)
		{
			Speed = iMaxSpeed;
		}
		if(iHealth > iMaxHealth)
		{
			iHealth = iMaxHealth;
		}
	}
	}
}
