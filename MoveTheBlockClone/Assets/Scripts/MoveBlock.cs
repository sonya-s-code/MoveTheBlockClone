using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public bool isMain;
    public bool isVertical;
    XYIndex IndexPosition;

    [SerializeField]
    private float blockMoveSpeed = 400;
    [SerializeField]
    private float blockLerpToPointSpeed = 10;

    private bool needMove;
    private bool needMoveToPoint;
    private Rigidbody2D rigidbody;
    private Vector3 moveTergetPosition;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        IndexPosition = new XYIndex() { X = 0, Y = 0 };
	}
	
	void FixedUpdate ()
    {
        if (needMove)
        {
            if (!isVertical)
            {
                float axisX;
                axisX = Input.GetAxis("Mouse X");
                axisX = Mathf.Clamp(axisX, -3, 3);
                rigidbody.velocity = new Vector2(axisX * blockMoveSpeed * Time.deltaTime, 0);
            }
            else
            {
                float axisY;
                axisY = Input.GetAxis("Mouse Y");
                axisY = Mathf.Clamp(axisY, -3, 3);
                rigidbody.velocity = new Vector2(0, axisY * blockMoveSpeed * Time.deltaTime);
            }
        }
        if (needMoveToPoint)
        {
            var targetPosition = Vector2.Lerp(transform.position, moveTergetPosition, blockLerpToPointSpeed * Time.deltaTime);
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        needMove = true;
        needMoveToPoint = false;
    }

    void OnMouseUp()
    {
        needMove = false;
        needMoveToPoint = true;
        rigidbody.velocity = new Vector2(0, 0);
        int layerMask = 1 << 8;
        var moveTerget = Physics2D.OverlapCircle(transform.position, 0.251f, layerMask).gameObject;
        var moveTergetPointPosition = moveTerget.GetComponent<PointPosition>();
        if (moveTergetPointPosition && moveTergetPointPosition.Index.X != IndexPosition.X || moveTergetPointPosition.Index.Y != IndexPosition.Y)
        {
            IndexPosition.X = moveTergetPointPosition.Index.X;
            IndexPosition.Y = moveTergetPointPosition.Index.Y;
            GameController.Action_AddStep.Invoke();
        }
        moveTergetPosition = moveTerget.transform.position;
    }
}

