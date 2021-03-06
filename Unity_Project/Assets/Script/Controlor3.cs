﻿using UnityEngine;
using System.Collections;

public class Controlor3 : MonoBehaviour
{
    public Rigidbody rb1, rb2, rb3;
    Vector3 v;
    public GameObject ob1, ob2, ob3;
    public static float G = 6.67e-11f;

    // Use this for initialization
    void Start()
    {
        rb3 = GetComponent<Rigidbody>();
        rb3.useGravity = false;
        ob1 = GameObject.FindWithTag("Planet1");
        rb1 = GetComponent<Rigidbody>();
        rb1.useGravity = false;
        ob2 = GameObject.FindWithTag("Planet2");
        rb2 = GetComponent<Rigidbody>();
        rb2.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 net_force = new Vector3(0, 0, 0), tp_force = new Vector3(0, 0, 0);
        float distance = (rb1.position - rb3.transform.position).magnitude;
        tp_force.x = (float)((rb1.mass * rb3.mass * G / distance * distance * distance) * (rb3.transform.position.x - rb1.position.x));
        tp_force.y = (float)((rb1.mass * rb3.mass * G / distance * distance * distance) * (rb3.transform.position.y - rb1.position.y));
        tp_force.z = (float)((rb1.mass * rb3.mass * G / distance * distance * distance) * (rb3.transform.position.z - rb1.position.z));
        net_force += tp_force;

        distance = (rb2.position - rb3.transform.position).magnitude;
        tp_force.x = (float)((rb2.mass * rb3.mass * G / distance * distance * distance) * (rb3.transform.position.x - rb2.position.x));
        tp_force.y = (float)((rb2.mass * rb3.mass * G / distance * distance * distance) * (rb3.transform.position.y - rb2.position.y));
        tp_force.z = (float)((rb2.mass * rb3.mass * G / distance * distance * distance) * (rb3.transform.position.z - rb2.position.z));
        net_force += tp_force;

        rb3.AddForce(net_force);
    }
}


