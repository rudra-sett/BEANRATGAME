using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// specific to rat AI, values and pathfinding
public class Rat : Enemy {
    [SerializeField] bool active;
    [SerializeField] NavMeshAgent agent;

    private void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        totalHealth = 3;
        rotationSpeed = 11;
    }

    // rotates towards player
    protected override void Move () {
        base.Move();
    }

    // moves towards player
    private void FixedUpdate() {
        if (active) {
            //Pathfinding();
            agent.SetDestination(target.position);
        }
    }
}
