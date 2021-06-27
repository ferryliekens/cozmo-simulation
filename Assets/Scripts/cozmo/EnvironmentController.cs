using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentController : MonoBehaviour
{
    [HideInInspector]
    public int Score;

    public Text text;

    public float spawnBoxWidth;
    public float spawnBoxHeight;
    public float spawntBoxDepth;

    public GameObject ballPrefab;
    public GameObject currentBall;

    public Material win;
    public Material lose;
    public MeshRenderer floor;

    public HoldBallAgent CozmoAgent;
    private Vector3 position;
    bool done = false;

    public void Start()
    {
        SpawnNewBall();
    }

    public void UpdateScore(bool won)
    {
        if (won)
        {
            Score++;
            floor.material = win;
        }
        else
        {
            Score--;
            floor.material = lose;
        }

        CozmoAgent.SetReward(Score);
        CozmoAgent.EndEpisode();
        //text.text = "Score : " + Score;
        SpawnNewBall();
    }

    public IEnumerator WaitForBall(GameObject ball)
    {
        yield return new WaitForSeconds(2);

        if (ball != null)
        {
            Destroy(ball);
            Score++;
            UpdateScore(true);
        }
    }

    private void SpawnNewBall()
    {
        if (!done)
        {
            position = GenerateRandomPosition();
            done=true;
        }
        currentBall = Instantiate(ballPrefab, position, Quaternion.Euler(new Vector3(0, Random.Range(160f, 160f), 0)));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnBoxWidth * 2, spawnBoxHeight * 2, spawntBoxDepth * 2));
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 t = Vector3.zero;
        t.x = Random.Range(-spawnBoxWidth, spawnBoxWidth) + transform.position.x;
        t.z = Random.Range(-spawntBoxDepth, spawntBoxDepth) + transform.position.z;
        t.y = Random.Range(-spawnBoxHeight, spawnBoxHeight) + transform.position.y;
        return t;
    }
}
