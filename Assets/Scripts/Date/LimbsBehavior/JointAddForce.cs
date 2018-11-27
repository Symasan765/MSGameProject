﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAddForce : MonoBehaviour {
    public Rigidbody rigidbody;
    public Vector3 vector;
    public ForceMode forceMode;
    public Transform axis;

    public enum AddForceType
    {
        AddForce,
        AddRelativeForce,
        AddExplosionForce
    }
    public AddForceType forceType;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//        Vector3 vc = axis.TransformDirection(vector);
        //Debug.Log(vc); 
        /*
        if (Input.GetKey(KeyCode.H))
        {
            switch (forceType)
            {
                case AddForceType.AddForce:
                    rigidbody.AddForce(vc, forceMode);
                    break;
                case AddForceType.AddRelativeForce:
                    rigidbody.AddRelativeForce(vc, forceMode);
                    break;
            }
        }
        */
    }

    public void Rotation(bool right)
    {
        Vector3 vc = vector;
        vc.x = right ? vc.x : -vc.x;

        vc = axis.TransformDirection(vc);

        switch (forceType)
        {
            case AddForceType.AddForce:
                rigidbody.AddForce(vc, forceMode);
                break;
            case AddForceType.AddRelativeForce:
                rigidbody.AddRelativeForce(vc, forceMode);
                break;
        }

    }
}
