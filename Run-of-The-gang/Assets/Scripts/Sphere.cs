using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private GameObject[] allSphere;

    private void Start()
    {
        for (int a = 0; a < allSphere.Length; a++)
        {
            allSphere[a].name = a.ToString();
        }
    }

}
