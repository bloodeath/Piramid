using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        //selon la fleche présser, on se déplace dans la direction choisi
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
        //on récupére les collider en face et en dessous dans la dirction choisi
        Collider[] col = Physics.OverlapSphere(transform.position + dir, 0.1f);
        Collider[] colGround = Physics.OverlapSphere(transform.position + dir + Vector3.down, 0.1f);

        //si il n'y pas de sol on s'arréte
        if (colGround.Length != 0)
            //si il y a un collider en face, ça peut être :
            if (col.Length == 1)
            {
                //un roche, dans ce cas on va tenté de la déplacer, si ça à marché on avance
                if (col[0].tag == "Stone")
                {
                    if (col[0].GetComponent<Stone>().moveTo(dir))
                        transform.position += dir;
                }
                //la fin du niveau, dans ce cas on laisse passé le joueur
                else if (col[0].tag == "End")
                    transform.position += dir;
                //un levier, dans ce cas on change l'état de celui ci
                else if (col[0].tag == "Lever")
                    col[0].GetComponent<Lever>().changeState();
            }
            //si il n'y a pas de collider en face, on avance
            else if (col.Length == 0)
                transform.position += dir;
        
    }
}
