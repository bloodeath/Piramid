using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//la pierre à fair bougé à la fin du niveau
public class Stone : MonoBehaviour
{
    //on vérifie si il y a un sol et qu'il n'y a pas de mur avant de déplacé la roche
    //si il y a un mur ou qu'il n'y a pas de sol dans la direction choisi on renvoie false pour ne pas permettre au joueur de se déplacer 
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
