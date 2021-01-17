using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool moveTo(Vector3 dir)
    {
        Collider[] col = Physics.OverlapSphere(transform.position + dir, 0.1f, LayerMask.GetMask("Wall"));
        Collider[] colGround = Physics.OverlapSphere(transform.position + dir + Vector3.down, 0.1f);

        if (col.Length == 0 && colGround.Length != 0)
        {
            transform.position += dir;
            return true;
        }
        return false;
    }
}
