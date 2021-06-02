using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float health = 10;
    [SerializeField] private float enemyHealth = 10;
    [SerializeField] private float cooldownAmount = 1;
    [SerializeField] private float damage = 1;
    [SerializeField] private float attackCooldown;

    void Update() {
        attackCooldown = Mathf.Max(0, attackCooldown - 1 * Time.deltaTime);
    }

    public bool CheckCooldown() {
        return attackCooldown == 0;
    }

    public void Attack() {
        attackCooldown = cooldownAmount;
        enemyHealth -= damage;
    }
}
