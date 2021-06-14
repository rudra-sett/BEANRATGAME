using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles all types of enemies in general.
public class Enemy : MonoBehaviour {
    protected Transform target;
    [SerializeField] Transform healthBar;
    [SerializeField] Collider2D collider;

    protected float totalHealth;
    private float health;

    protected float rotationSpeed = 1f;

    private void Start() {
        health = totalHealth;
    }

    private void Update() {
        Move();
    }

    // adjusts all enemies to look at the Player

    protected virtual void Move () {

        float step = rotationSpeed * Time.deltaTime;

        Vector2 direction = target.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
    }

    public void GetHit (float damage, Player sender) {
        health -= damage;

        float healthPercentage = 1f / totalHealth * health;
        healthBar.localScale = new Vector3(healthPercentage, 1, 1);

        if (health < 0) {
            sender.currentHits.Remove(collider);
            Destroy(gameObject);
        }
    }
}
