using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private bool crossedCheckpoint;
	public CheckPointReachChecker checkPoint; 

	public float moveSpeed;

	public GameObject player;
	private Movement3D mover;

	public bool attacking = false;
	private bool inRange = false;
	public float attackDelay = 1.0f;
	private float delay = 0.0f;

	private Animation anim;

	// Use this for initialization
	void Start () {
		crossedCheckpoint = false;
		mover = player.GetComponent<Movement3D> ();
		anim = gameObject.GetComponent<Animation> ();
	}

	// Update is called once per frame
	void Update () {
		crossedCheckpoint = checkPoint.reachedCheckpoint;
	
		if(crossedCheckpoint) {
			LastLevelUpdate();
		}
	}

	void LastLevelUpdate() {

		delay -= Time.deltaTime;

		if(inRange && !mover.invisible) {
			if(delay <= 0) {
				delay = attackDelay;
				anim.Play("SwingAttack");
				attacking = true;
			}
			else {
				attacking = false;
			}
		} else if(!mover.invisible) {
			attacking = false;
			anim.Play("Walk");
			transform.LookAt(player.transform);
			transform.Translate(transform.forward * Time.deltaTime * moveSpeed);
		} else {
			attacking = false;
			anim.Stop();
		}


	}

	void OnCollisionEnter() {
		inRange = true;
	}

	void OnCollisionExit() {
		inRange = false;
	}
}