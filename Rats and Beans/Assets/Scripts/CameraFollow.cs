using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject player;

    Vector3 offset;

    void Start()
    {
        offset = gameObject.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position + offset;
        
    }
}
