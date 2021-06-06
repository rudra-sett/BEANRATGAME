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
        if (hitfield.IsTouching(tempcollider2)) {
            enemy.GetHit(damage);
        }
        attackCooldown = cooldownAmount;
    }
}
