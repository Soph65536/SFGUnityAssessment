using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const float StartingYPos = -0.5f;
    const float StartingZPos = -0.5f;
    const float MovingSpeed = 1;

    private Vector3 StartingPos;
    private Vector3 MovePos;
    private bool movingToStartPos;

    // Start is called before the first frame update
    void Awake()
    {
        StartingPos = new Vector3(Random.Range(-30, 30), StartingYPos, StartingZPos);
        MovePos = new Vector3(StartingPos.x + Random.Range(-0.5f, 0.5f), Random.Range(0.5f, 1.5f), StartingZPos);
        movingToStartPos = false;
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
