using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffController : MonoBehaviour
{
    private FatigueController _fatigue;
    private int _hungerValue;
    private int _stressValue;

    private void Start()
    {

        _fatigue = GameObject.Find("fatigue").GetComponent<FatigueController>();
    }

    public void ChangeMaxFatigue_hunger(int _hungerValue)
    {
        switch (_hungerValue)
        {
            case 0:
                Debug.Log(123);
            break;
            case <=3:
                Debug.Log(123);
                break;
        }
    }
}
