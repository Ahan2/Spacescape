using UnityEngine;
using System.Collections;

public class BossGetPunched : MonoBehaviour {
	
	public GameObject player;
	bool playerThere;
	Movement3D mover;
	public float bossEndurance = 3.0f;
	float bossCurrentHealth;

	// Use this for initialization
	void Start () {
		mover = player.GetComponent<Movement3D> ();
		playerThere = false;
		bossCurrentHealth = bossEndurance;
	}
	
	// Update is called once per frame
	void Update () {
		if(mover.punchOccuring && playerThere) {
			bossCurrentHealth -= Time.deltaTime;
		}

		if(bossCurrentHealth <= 0) {
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter (Collision col) {
		if(col.gameObject.CompareTag("Player")) {
			playerThere = true;
			
		}
	}
	
	void OnCollisionExit (Collision col) {
		if(col.gameObject.CompareTag("Player")) {
			playerThere = false;
		}
	}
}
