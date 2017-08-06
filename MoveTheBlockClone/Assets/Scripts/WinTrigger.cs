using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {
    public GameObject WinObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        var moveBlock = other.GetComponent<MoveBlock>();
        if (moveBlock && moveBlock.IsMain)
            WinObject.SetActive(true);
    }
}
