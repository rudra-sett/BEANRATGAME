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

    public Collider2D hit;

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
  
        //swordanim.Play("Base Layer.swordidle", 0);
        if (hitfield.IsTouching(hit)) {
            hit.GetComponentInParent<Enemy>().GetHit(damage);
        }
        attackCooldown = cooldownAmount;
       /* if (istouchingrat)
        {
            hit.gameObject.GetComponentInParent<Rat>().GetHit(damage);
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit!");
        hit = other;
    
    }

}
