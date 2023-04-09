using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float _weight;
    public bool _isFarigile;

    private void Start()
    {

        _weight = Random.Range(0, 3);

    }

}


