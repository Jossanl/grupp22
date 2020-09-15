using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private GameObject nextTarget;

    [SerializeField] private float speed = 2f;

    [SerializeField] private List<GameObject> targetPoints;
    private int currentTargetPointIntex;

    // Start is called before the first frame update
    void Start()
    {
        if (targetPoints.Count > 0) {
            nextTarget = targetPoints[0];

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextTarget !=null) {
            MoveToPosition(nextTarget);

        }
    }

    private void MoveToPosition(GameObject moveToTarget) {
      gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.fixedDeltaTime); 
        if (gameObject.transform.position == moveToTarget.transform.position) {
            ChangeTarget();
        }
    }
    private void ChangeTarget() {

        currentTargetPointIntex++;

        while (targetPoints[currentTargetPointIntex] == null)
        {
            currentTargetPointIntex++;
            if (currentTargetPointIntex >= targetPoints.Count) {
                currentTargetPointIntex = 0;
            }
        }

        nextTarget = targetPoints[currentTargetPointIntex];
    }
}