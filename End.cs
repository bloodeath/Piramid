using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class End : MonoBehaviour
{
    public string nextScene;

    Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    //quand la roche arrive sur la fin, on passe au niveau suivant
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stone")
            GameManager.Instance.loadLevel(nextScene);
    }
}
