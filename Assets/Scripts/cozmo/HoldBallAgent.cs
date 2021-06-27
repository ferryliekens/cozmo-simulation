using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class HoldBallAgent : Agent
{
    public EnvironmentController environmentController;
    Rigidbody m_Rigidbody;
    float movementSpeed = 5f;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.rotation);
        if (environmentController.currentBall != null)
        {
            sensor.AddObservation(environmentController.currentBall.transform.position);
        }
        Debug.Log("collecting observations");
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float forwards = actions.ContinuousActions[0];
        float right = actions.ContinuousActions[1];

        m_Rigidbody.velocity = transform.forward * forwards * 2;
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * right * 40, Space.World);
        //transform.position += new Vector3(forwards, 0, right) * Time.deltaTime * movementSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("hit");
            StartCoroutine(environmentController.WaitForBall(other.gameObject));
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Vertical");
        continuousActions[1] = Input.GetAxisRaw("Horizontal");
    }

}
