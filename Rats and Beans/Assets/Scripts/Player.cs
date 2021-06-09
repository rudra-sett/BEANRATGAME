using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Sprite[] hitfieldSprites;
    [SerializeField] private SpriteRenderer SRHitfield;

    [SerializeField] private Collider2D hitfield;
    [SerializeField] private Collider2D tempcollider2;
    [SerializeField] private Enemy enemy;

    [SerializeField] private float health = 10;
    [SerializeField] private float cooldownAmount = 1;
    [SerializeField] private float damage = 1;
    [SerializeField] private float attackCooldown;

    [SerializeField] public Animator swordanim;

    private bool istouchingrat = false;
    private Collision2D hit;

    void Update() {
        attackCooldown = Mathf.Max(0, attackCooldown - 1 * Time.deltaTime);

        int spriteID = Mathf.CeilToInt(attackCooldown);
        SRHitfield.sprite = hitfieldSprites[spriteID];
    }

    public bool CheckCooldown() {
        return attackCooldown == 0;
    }

    public void Attack() {
        //if (tempcollider1.OverlapCollider(new ContactFilter2D(), enemyColliders)) {

        /*foreach (AnimationState state in swordanim)
        {
            state.speed = 0.5F;
        }*/

        swordanim.Play("Base Layer.swordanimation",0);
  
        swordanim.Play("Base Layer.New State", 0);
        if (hitfield.IsTouching(tempcollider2)) {
            enemy.GetHit(damage);
        }
        attackCooldown = cooldownAmount;
       /* if (istouchingrat)
        {
            hit.gameObject.GetComponentInParent<Rat>().GetHit(damage);
        }*/
    }

    //ignore this for now; I was trying to make the attack thingy work against multiple rats
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rat")
        {
            //collision.gameObject.GetComponentInParent<Rat>().GetHit(damage);
            istouchingrat = true;
            hit = collision;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rat")
        {
            //collision.gameObject.GetComponentInParent<Rat>().GetHit(damage);
            istouchingrat = false;
            hit = null;
        }
    }*/

   
}
