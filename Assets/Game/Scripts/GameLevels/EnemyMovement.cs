using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const float MaxDistanceFromCenter = 13;

    const float StartingYPos = -1f;
    const float StartingZPos = 9.5f;

    const float MovingSpeed = 1;

    private float StartingXPos;
    private Vector3 StartingPos;
    private Vector3 MovePos;
    private bool movingToStartPos;

    // Start is called before the first frame update
    void Awake()
    {
        StartingXPos = Random.Range(-MaxDistanceFromCenter, MaxDistanceFromCenter);
        StartingPos = new Vector3(StartingXPos, StartingYPos, StartingZPos);
        MovePos = new Vector3(StartingXPos + Random.Range(-0.5f, 0.5f), Random.Range(0.5f, 1.5f), StartingZPos);
        movingToStartPos = false;

        transform.position = StartingPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePositions();
    }

    private void MovePositions()
    {
        Vector3 TargetPos;
        
        if(movingToStartPos)
        {
            TargetPos = StartingPos;
        }
        else
        {
            TargetPos = MovePos;
        }

        transform.position = Vector3.MoveTowards(transform.position, TargetPos, MovingSpeed * Time.deltaTime);

        if(transform.position == TargetPos)
        {
            movingToStartPos = !movingToStartPos;
        }
    }
}
