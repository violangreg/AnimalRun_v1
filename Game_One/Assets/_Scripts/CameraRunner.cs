using UnityEngine;
using System.Collections;

public class CameraRunner : MonoBehaviour {

	Transform player;
	float offSetX;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");

		if (player_go == null) {
			Debug.LogError ("Couldn't find an object with tag 'Player'!");
		} else {
			player = player_go.transform;
			offSetX = transform.position.x - player.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offSetX;
			transform.position = pos;
		}
	}
}
