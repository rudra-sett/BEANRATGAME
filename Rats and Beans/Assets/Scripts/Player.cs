using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Sprite[] hitfieldSprites;
    [SerializeField] private SpriteRenderer hitfield;

    [SerializeField] private Collider2D tempcollider1;
    [SerializeField] private Collider2D tempcollider2;

    [SerializeField] private float health = 10;
    [SerializeField] private float enemyHealth = 10;
    [SerializeField] private float cooldownAmount = 1;
    [SerializeField] private float damage = 1;
    [SerializeField] private float attackCooldown;

    void Update() {
        attackCooldown = Mathf.Max(0, attackCooldown - 1 * Time.deltaTime);

        int spriteID = Mathf.CeilToInt(attackCooldown);
        hitfield.sprite = hitfieldSprites[spriteID];
    }

    public bool CheckCooldown() {
        return attackCooldown == 0;
    }

    public void Attack() {
        //if (tempcollider1.OverlapCollider(new ContactFilter2D(), tempcollider2)) {
        if (tempcollider1.IsTouching(tempcollider2)) {
            enemyHealth -= damage;
        }
        attackCooldown = cooldownAmount;
    }
}
