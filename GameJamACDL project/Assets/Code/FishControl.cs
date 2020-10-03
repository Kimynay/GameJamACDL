using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour
{
    public float mVerticalSpeed = 4.0f;
    public float mHorizontalSpeed = 20.0f;
    public float mMaxHorizontalDisplacement = 6f;
    public GameObject mCamera;
    public float mCameraVerticalSpeed = 0.05f;
    public float mCameraHorizontalSpeed = 0.05f;

    void Start()
    {
        
    }//

    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            transform.position = transform.position + new Vector3(0.0f, Input.GetAxis("Vertical") * Time.deltaTime * mVerticalSpeed, 0.0f);
        }
        if (transform.position.y > mMaxHorizontalDisplacement)
            transform.position = new Vector3(transform.position.x, mMaxHorizontalDisplacement, transform.position.z);
        if (transform.position.y < -mMaxHorizontalDisplacement)
            transform.position = new Vector3(transform.position.x, -mMaxHorizontalDisplacement, transform.position.z);
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0.0f, Input.GetAxis("Horizontal") * Time.deltaTime * -mHorizontalSpeed, 0.0f);
            Debug.Log(Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        Quaternion TargetRotation = transform.rotation;
        Quaternion nextCameraRotation = Quaternion.Lerp(mCamera.transform.rotation, TargetRotation, mCameraVerticalSpeed);
        mCamera.transform.rotation = nextCameraRotation;

        Vector3 TargetPosition = transform.position;
        Vector3 nextCameraPosition = Vector3.Lerp(mCamera.transform.position, new Vector3(mCamera.transform.position.x, TargetPosition.y, mCamera.transform.position.z), mCameraHorizontalSpeed);
        mCamera.transform.position = nextCameraPosition;

    }
}
