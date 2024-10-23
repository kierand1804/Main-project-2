using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrav : MonoBehaviour
{
    public Vector3 rotation;
    public GameObject player;

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.rotation = Quaternion.Euler(rotation);
    }
}
