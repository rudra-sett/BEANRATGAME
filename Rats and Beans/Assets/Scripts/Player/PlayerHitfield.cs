using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitfield : MonoBehaviour {
    [SerializeField] Player player;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("entered!");
        //gameObject.GetComponentInParent<Player>().hit = other;
        player.currentHits.Add(other);

    }

    private void OnTriggerExit2D(Collider2D other) {
        player.currentHits.Remove(other);
        Debug.Log("left!");
    }
}
