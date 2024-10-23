using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGravity : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] int rotSpeed = 90;
    private Vector3 cameraRot;
    private Vector3 cameraPos;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        //{
        //    //cameraRot = Vector3.forward * rotSpeed;
        //    //cameraRot = cameraRot - new Vector3(0, 0, 90);
        //    //cameraPos = cameraRot + cameraPos;
        //    //rotation *= Quaternion.AngleAxis(90, Vector3.forward);

        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    //cameraRot
        //    //cameraRot = Vector3.back * rotSpeed;
        //    cameraRot = cameraRot + new Vector3(0, 0, 90);
        //    cameraPos = cameraRot + cameraPos;
            
        //}
        //_camera.transform.rotation = Quaternion.Euler(cameraPos);
        //Physics2D.gravity
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //cameraRot = Vector3.forward * rotSpeed;
            cameraRot = cameraRot + new Vector3(0, 0, -rotSpeed);
            //cameraPos = cameraRot + cameraPos;
            //rotation *= Quaternion.AngleAxis(90, Vector3.forward);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //cameraRot
            //cameraRot = Vector3.back * rotSpeed;

            cameraRot = cameraRot + new Vector3(0, 0, rotSpeed);
            //cameraPos = cameraPos + new Vector3(0, rotSpeed, 0);
            //cameraPos = cameraRot + cameraPos;

        }
        _camera.transform.rotation = Quaternion.Euler(cameraRot); //* Time.deltaTime);
        //Physics2D.gravity;
        Physics2D.gravity = _camera.transform.up*-5f;
        
    
    }
}
