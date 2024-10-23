using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForPlayer : MonoBehaviour
{
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] GameObject player;
    [SerializeField] DoorOpen _open;


    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<GameObject>();
        //_collider = GetComponent<BoxCollider2D>();
        //_open = GetComponent<DoorOpen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _open.doorOpen();
        Destroy(gameObject);
    }
}
