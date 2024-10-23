using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrate : MonoBehaviour
{
    [SerializeField] GameObject _crate;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_crate);
    }
}
