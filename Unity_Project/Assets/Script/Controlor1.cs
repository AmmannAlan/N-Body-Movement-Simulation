using UnityEngine;
using System.Collections;

public class Controlor1 : MonoBehaviour
{
    public Rigidbody rb1, rb2, rb3;
    Vector3 v;
    public GameObject ob1, ob2, ob3;
    public static float G = 6.67e-11f;

    // Use this for initialization
    void Start()
    {
        rb1 = GetComponent<Rigidbody>();
        rb1.useGravity = false;
        ob2 = GameObject.FindWithTag("Planet2");
        rb2 = GetComponent<Rigidbody>();
        rb2.useGravity = false;
        ob3 = GameObject.FindWithTag("Planet3");
        rb3 = GetComponent<Rigidbody>();
        rb3.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 net_force = new Vector3(0, 0, 0), tp_force = new Vector3(0, 0, 0);
        float distance = (rb2.position - rb1.transform.position).magnitude;
        tp_force.x = (float)((rb2.mass * rb1.mass * G / distance * distance * distance) * (rb1.transform.position.x - rb2.position.x));
        tp_force.y = (float)((rb2.mass * rb1.mass * G / distance * distance * distance) * (rb1.transform.position.y - rb2.position.y));
        tp_force.z = (float)((rb2.mass * rb1.mass * G / distance * distance * distance) * (rb1.transform.position.z - rb2.position.z));
        net_force += tp_force;

        distance = (rb3.position - rb1.transform.position).magnitude;
        tp_force.x = (float)((rb3.mass * rb1.mass * G / distance * distance * distance) * (rb1.transform.position.x - rb3.position.x));
        tp_force.y = (float)((rb3.mass * rb1.mass * G / distance * distance * distance) * (rb1.transform.position.y - rb3.position.y));
        tp_force.z = (float)((rb3.mass * rb1.mass * G / distance * distance * distance) * (rb1.transform.position.z - rb3.position.z));
        net_force += tp_force;

        rb1.AddForce(net_force);
    }
}


