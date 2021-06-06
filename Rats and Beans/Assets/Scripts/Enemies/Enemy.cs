using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] Transform healthBar;

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

        Vector2 direction = player.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
    }

    public void GetHit (float damage) {
        health -= damage;

        float healthPercentage = 1f / totalHealth * health;
        healthBar.localScale = new Vector3(healthPercentage, 1, 1);

        if (health < 0) { Destroy(transform.parent.gameObject); }
    }
}
