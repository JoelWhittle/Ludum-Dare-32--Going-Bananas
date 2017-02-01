using UnityEngine;
using System.Collections;

public class Bananarang : MonoBehaviour {


	public int iSpeed;
	public float fBananaDestroyTime;

	// Use this for initialization
	void Start () {
	
		GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Add (gameObject);
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * iSpeed, ForceMode.Acceleration);
	
		StartCoroutine (DestroyBananaTimer());

	}
	

	public IEnumerator DestroyBananaTimer()
	{
		yield return new WaitForSeconds (fBananaDestroyTime);

		GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Remove(gameObject);

		Destroy (gameObject);

	}
}
