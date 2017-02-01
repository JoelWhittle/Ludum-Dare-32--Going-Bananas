using UnityEngine;
using System.Collections;

public class BananaBomb : MonoBehaviour {

	
	public int iSpeed;
	public float fBananaDestroyTime;
	public int iBananasToSpawn;

	public AudioSource aBoom;
	// Use this for initialization
	void Start () {
		
		GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Add (gameObject);
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * iSpeed, ForceMode.Acceleration);
		
		StartCoroutine (DestroyBananaTimer());

		aBoom = gameObject.GetComponent<AudioSource> ();
		
	}
	
	
	public IEnumerator DestroyBananaTimer()
	{
		yield return new WaitForSeconds (fBananaDestroyTime);
		
		GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Remove(gameObject);
		
		Destroy (gameObject);
		
	}


	void OnCollisionEnter (Collision collision)
	{
		aBoom.Play();

		for(int i = 0; i < iBananasToSpawn; i++)
		{
			Instantiate(GameObject.Find ("_GameManager").GetComponent<GameManager> ().cPrefabs.goBanana, gameObject.transform.position, Quaternion.Euler(Random.Range(0,360),0, Random.Range(0,360)));
		}
	
			GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Remove(collision.gameObject);
			Destroy(collision.gameObject);
			

	}
}
