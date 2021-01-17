using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public List<ActivableBloc> actiBloc;

    public void changeState()
    {
        foreach (ActivableBloc ab in actiBloc)
            ab.changeState();
    }
}
