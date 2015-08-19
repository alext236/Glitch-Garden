﻿using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private Animator anim;
    private Health healthComp;

    private Attacker currentAttacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        healthComp = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckHealth();
    }

    private void CheckHealth() {
        if (healthComp.health <= 0) {
            Debug.Log(gameObject + " is destroyed");
            Destroy(gameObject);
            currentAttacker.StopAttack();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject atk = collision.gameObject;
        //only recognize entering trigger with attackers
        if (!atk.GetComponent<Attacker>()) {
            return;            
        }
        currentAttacker = atk.GetComponent<Attacker>();
        Debug.Log(name + " enter trigger with an attacker");
        anim.SetBool("isAttacked", true);
    }
}
