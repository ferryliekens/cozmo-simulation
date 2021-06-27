using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement for manual testing
public class movement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Speed;
    public EnvironmentController environmentController;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 2.0f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("hit");
            StartCoroutine(environmentController.WaitForBall(col.gameObject));
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Rigidbody.velocity = transform.forward * -m_Speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed * 20, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * -m_Speed * 20, Space.World);
        }
    }
}
