using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject player;

    float offsetx;
    float offsety;

    void Start()
    {
        offsetx = gameObject.transform.position.x - player.transform.position.x;
        offsety = gameObject.transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + offsetx, player.transform.position.y + offsety,-10);


    }
}
