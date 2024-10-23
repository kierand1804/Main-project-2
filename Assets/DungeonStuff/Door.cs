using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Door : MonoBehaviour
{
   public enum DoorType
    {
        left,right, top, bottom
    }

    public DoorType doorType;
    private GameObject player;
    private float widthOffset = 1.75f;
    private float heightOffset = 5f;
    public GameObject doorCollider;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch(doorType) 
            {
                case DoorType.bottom:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - widthOffset);
                    break;
                case DoorType.left:
                    player.transform.position = new Vector2(transform.position.x - widthOffset - 4, transform.position.y);
                    break;
                case DoorType.right:
                    player.transform.position = new Vector2(transform.position.x + widthOffset, transform.position.y);
                    break;
                case DoorType.top:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y + heightOffset);
                    break;
            }
        }
    }
}
