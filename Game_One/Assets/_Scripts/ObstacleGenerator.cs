using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

	public GameObject obstacle;
	public Transform generationPoint;
	public float distanceBetweenMinX, distanceBetweenMaxX, distanceBetweenMinY, distanceBetweenMaxY, originalY;
	private float distanceBetweenX, distanceBetweenY;
	public ObjectPooler objectPool;

	// Use this for initialization
	void Start () {
		originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			distanceBetweenX = Random.Range (distanceBetweenMinX, distanceBetweenMaxX);
			distanceBetweenY = Random.Range (distanceBetweenMinY, distanceBetweenMaxY);

			transform.position = new Vector3 (transform.position.x, originalY, transform.position.z);
			transform.position = new Vector3 (transform.position.x + distanceBetweenX, transform.position.y + distanceBetweenY, transform.position.z);

			//Instantiate (obstacle, transform.position, transform.rotation);
			GameObject newObstacle = objectPool.GetPooledObject ();

			newObstacle.transform.position = transform.position;
			newObstacle.transform.rotation = transform.rotation;
			newObstacle.SetActive (true);

		}

	}
}
