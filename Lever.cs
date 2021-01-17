using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Permet d'activé ou déactivé le collider des blocs activables passés en paramètres
public class Lever : MonoBehaviour
{
    public List<ActivableBloc> actiBloc;

    public void changeState()
    {
        foreach (ActivableBloc ab in actiBloc)
            ab.changeState();
    }
}
