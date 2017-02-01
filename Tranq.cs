using UnityEngine;
using System.Collections;

public class Tranq : MonoBehaviour {


	
	public int iSpeed;
	public float fDestroyTime;
	public float fSlowStrength;
	
	// Use this for initialization
	void Start () {
		
		GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Add (gameObject);
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * iSpeed, ForceMode.Acceleration);
		
		StartCoroutine (DestroyTimer());
	}
	
	
	public IEnumerator DestroyTimer()
	{
		yield return new WaitForSeconds (fDestroyTime);
		
		DestroyItem ();
		
	}

	public void DestroyItem()
	{
		GameObject.Find ("_GameManager").GetComponent<GameManager> ().ObjectsToClean.Remove(gameObject);
		
		Destroy (gameObject);
	}
}
