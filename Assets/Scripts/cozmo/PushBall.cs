using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(doSomething());
    }


    private IEnumerator doSomething()
    {
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.forward * speed * 100);
    }
}
