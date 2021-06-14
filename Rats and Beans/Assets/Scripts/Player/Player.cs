using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Sprite[] hitfieldSprites;
    [SerializeField] private SpriteRenderer SRHitfield;

    [SerializeField] private Collider2D hitfield;
    [SerializeField] private Enemy enemy;

    [SerializeField] private float health = 10;
    [SerializeField] private float cooldownAmount = 1;
    [SerializeField] private float damage = 1;
    [SerializeField] private float attackCooldown;

    [SerializeField] public Animator swordanim;

    //public Collider2D hit;
    public List<Collider2D> currentHits = new List<Collider2D>();

    void Update() {
        attackCooldown = Mathf.Max(0, attackCooldown - 1 * Time.deltaTime);

        int spriteID = Mathf.CeilToInt(attackCooldown);
        SRHitfield.sprite = hitfieldSprites[spriteID];
    }

    public bool CheckCooldown() {
        return attackCooldown == 0;
    }

    public void Attack() {
        swordanim.Play("Base Layer.swordanimation",0);

        foreach (var hit in currentHits) {
            hit.GetComponentInParent<Enemy>().GetHit(damage, this);
        }

        /*
        //swordanim.Play("Base Layer.swordidle", 0);
        if (hitfield.IsTouching(hit)) {
            hit.GetComponentInParent<Enemy>().GetHit(damage);
        }*/
        attackCooldown = cooldownAmount;
    }
}
