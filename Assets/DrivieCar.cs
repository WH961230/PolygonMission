using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DrivieCar : MonoBehaviour{
    public float speed = 0f;
    public float xSensitive = 0f;
    public float ySensitive = 0f;
    public Camera cam;
    private Quaternion m_camLocalRotation;
    // Start is called before the first frame update
    void Start()
    {
        m_camLocalRotation = cam.transform.localRotation;
    }

    // Update is called once per frame
    void Update(){

        float yRot = Input.GetAxis("Mouse X") * xSensitive * 0.6f;
        float xRot = Input.GetAxis("Mouse Y") * ySensitive * 0.3f;

        m_camLocalRotation *= Quaternion.Euler(-xRot,yRot,0f);
        cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation,m_camLocalRotation,Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
