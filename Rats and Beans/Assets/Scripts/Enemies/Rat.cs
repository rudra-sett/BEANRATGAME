using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy {

    private void Awake() {
        totalHealth = 3;
        rotationSpeed = 2;
    }

    // moves towards player

    protected override void Move () {
        base.Move();

        transform.parent.position += transform.up * Time.deltaTime * 10;
    }
}
