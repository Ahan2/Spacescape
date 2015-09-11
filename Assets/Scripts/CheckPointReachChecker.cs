using UnityEngine;
using System.Collections;

public class CheckPointReachChecker : MonoBehaviour {

	public bool reachedCheckpoint;

	// Use this for initialization
	void Start () {
		reachedCheckpoint = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag("Player")) {
			reachedCheckpoint = true;
		}
	}
}
