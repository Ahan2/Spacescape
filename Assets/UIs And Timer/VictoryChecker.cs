using UnityEngine;
using System.Collections;

public class VictoryChecker : MonoBehaviour {
	public GameObject WinUI;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.T)) {
			player.SetActive(false);
			Victory();
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag("Player")) {
			player.SetActive(false);
			Victory();
		}
	}

	void Victory() {
		WinUI.SetActive(true);
	}
}
