using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    Player player;
    Camera mainCamera;

    [SerializeField] private float movementSpeed = 0.25f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float slidyness = 15f;

    private Vector2 roughPosition;

    // Get required classes
    void Awake() {
        player = GetComponent<Player>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        UpdatePosition();
        UpdateDirection();
    }

    private void FixedUpdate() {
        Actions();
    }

    void Actions () {
        

        if (Input.GetMouseButton(0) && player.CheckCooldown()) {
            player.Attack();

        }
    }

    void UpdatePosition () {
        float step = movementSpeed * Time.deltaTime;

        float x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);

        Vector2 updatedPosition = new Vector2(x, y );
        updatedPosition = Vector2.ClampMagnitude(updatedPosition, step);

        roughPosition = roughPosition + updatedPosition;

        transform.position = Vector3.Lerp(transform.position, roughPosition, 1 / slidyness);
    }

    void UpdateDirection() {
        float step = rotationSpeed * Time.deltaTime;

        Vector2 direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
    }
}
