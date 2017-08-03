using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public bool isMain;
    public BlockType Type;
    public BlockSize Size;

    [SerializeField]
    private float blockMoveSpeed = 400;
    [SerializeField]
    private float blockLerpToPointSpeed = 10;

    private bool needMove;
    private bool needMoveToPoint;
    private Rigidbody2D rigidbody;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (needMove)
        {
            if (Type == BlockType.Horizontal)
            {
                var axisX = Input.GetAxis("Mouse X");
                rigidbody.velocity = new Vector2(axisX * blockMoveSpeed * Time.deltaTime, 0);
            }
            else
            {
                var axisY = Input.GetAxis("Mouse Y");
                rigidbody.velocity = new Vector2(0, axisY * blockMoveSpeed * Time.deltaTime);
            }
        }
        if (needMoveToPoint)
        {
            int layerMask = 1 << 8;
            var pointPosition = Physics2D.OverlapCircle(transform.position, 0.251f, layerMask).transform.position;
            var targetPosition = new Vector3(Type == BlockType.Horizontal ? pointPosition.x : transform.position.x, Type == BlockType.Vertical ? pointPosition.y : transform.position.y);
            if ((targetPosition - transform.position).sqrMagnitude > 0.1)
                transform.position = Vector2.Lerp(transform.position, targetPosition, blockLerpToPointSpeed * Time.deltaTime);
            else
            {
                transform.position = targetPosition;
                needMoveToPoint = false;
            }
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
    }
}

public enum BlockType
{
    Horizontal,
    Vertical
}

public enum BlockSize
{
    Size2,
    Size3
}
