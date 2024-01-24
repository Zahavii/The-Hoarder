using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public static DungeonCamera DC;
    public Camera mainCam;
    public Vector3 targetPos;
    void Start()
    {
        if(DC == null)
            DC = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((transform.position - targetPos).magnitude > 0.01f)
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*4f);
        //transform.position.Set(transform.position.x, transform.position.y, -10f);
    }
    public void MoveCam(Vector2 t)
    {

        //gameObject.transform.position = new Vector3(t.x, t.y, gameObject.transform.position.z);
        targetPos = t;
        //Vector3 Target = new Vector3(t.x, t.y, gameObject.transform.position.z);
        //Mathf.Lerp()
    }
    public void SetCameraSize(float s)
    {
        //mainCam.set
    }
}
