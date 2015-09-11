using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public float playerHitEndurance = 6.0f;
	private float health;
	private Animation anim;
	public bool dead;

	public EnemyController alien1;
	public EnemyController alien2;
	public EnemyController alien3;
	public EnemyController alien4;

	private float damage;
	private float deathTimer;
	public GameObject myUI;

	// Use this for initialization
	void Start () {
		dead = false;
		health = playerHitEndurance;
		anim = gameObject.GetComponent<Animation> ();
		deathTimer = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

		damage = 0;

		if(alien1.attacking)
		{
			damage++;
		}

		if(alien2.attacking)
		{
			damage++;
		}

		if(alien3.attacking)
		{
			damage++;
		}

		if(alien4.attacking)
		{
			damage++;
		}

		health -= damage;
		if(health <= 0)
		{
			dead = true;
			anim.Play("death");
			deathTimer -= Time.deltaTime;
			if(deathTimer <= 0) {
				GameOver();
			}
		}

	}

	void GameOver() {

		myUI.SetActive(true);	
	}
}
