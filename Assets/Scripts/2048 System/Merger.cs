using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merger : MonoBehaviour
{
    public void Unite(Rigidbody2D one, Rigidbody2D two)
    {
        //SetOneToCenter(one, two);

        Vector2 newVelocity = (one.velocity + two.velocity) / 2f;
        one.velocity = newVelocity;
        Destroy(two.gameObject);
    }

    private void SetOneToCenter(Rigidbody2D one, Rigidbody2D two)
    {
        Vector2 newPosition = (one.position + two.position) / 2f;
        one.MovePosition(newPosition);
    }
}
