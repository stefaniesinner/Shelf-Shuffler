using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    // to use the ladder
    private float moveVertical;
    private float speed = 8f;
    private bool isLadder; // to know if the player is standing on the ladder
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
        }
    }

    /*
     * Check if the player is standing on the ladder.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    /*
     * Check if the player is standing on the ladder yet.
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
