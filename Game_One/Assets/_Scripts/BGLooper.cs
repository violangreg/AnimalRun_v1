using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public GameObject LooperPoint;
	int numBGPanels = 10;

	void Start ()
	{
		LooperPoint = GameObject.Find ("BGLooper");
	}

	void Update()
	{
		if (transform.position.x < LooperPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);

		float widthOfBGObject = collider.bounds.size.x;
		Vector3 position = collider.transform.position;

		position.x += widthOfBGObject * numBGPanels - widthOfBGObject/2;

		collider.transform.position = position;
	}
}
