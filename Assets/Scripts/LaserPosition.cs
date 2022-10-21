using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPosition : MonoBehaviour
{
    public GameObject muzzle;
    public Vector3 laserPos;
    public Vector3 muzzlePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        muzzle = GameObject.Find("Muzzle");

        laserPos = transform.position;
        muzzlePos = muzzle.transform.position;

        laserPos = new Vector3 (muzzlePos.x, muzzlePos.y, muzzlePos.z);

        transform.position = laserPos;

        //Debug.Log("laser : " + transform.position);
        //Debug.Log("Muzzle : " + muzzle.transform.position);

    }
}
