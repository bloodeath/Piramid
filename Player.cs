using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveTo(Vector3.forward);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveTo(Vector3.back);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveTo(Vector3.left);
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveTo(Vector3.right);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    private void moveTo(Vector3 dir)
    {
        Collider[] col = Physics.OverlapSphere(transform.position + dir, 0.1f);
        Collider[] colGround = Physics.OverlapSphere(transform.position + dir + Vector3.down, 0.1f);

        if (colGround.Length != 0)
            if (col.Length == 1)
            {
                if (col[0].tag == "Stone")
                {
                    if (col[0].GetComponent<Stone>().moveTo(dir))
                        transform.position += dir;
                }
                else if (col[0].tag == "End")
                    transform.position += dir;
                else if (col[0].tag == "Lever")
                    col[0].GetComponent<Lever>().changeState();
            }
            else if (col.Length == 0)
                transform.position += dir;
        
    }
}
