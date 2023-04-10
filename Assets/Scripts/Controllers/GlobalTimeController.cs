using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTimeController : MonoBehaviour
{

    [SerializeField] private float _speedGlobalTime;

    private TMP_Text _timeText;

    [SerializeField] private TMP_Text _hunger;
    public int _hungerValue;
    [SerializeField] private TMP_Text _stress;
    public int _stressValue;

    [SerializeField] private int _waitDebuffHunger;
    [SerializeField] private int _waitDebuffStress;


    [SerializeField] private DebuffController _debuffController;



    public int _timeHasPassedHunger;
    public int _timeHasPassedStress;

    private void Start()
    {
        
        _timeText = GetComponent<TMP_Text>();
        string[] _tempTime = _timeText.text.Split(':');

        StartCoroutine(TimeTick(int.Parse(_tempTime[0]), int.Parse(_tempTime[1])));
    }

    IEnumerator TimeTick(int hour,int min)
    {
        while (true)
        {
        _timeHasPassedHunger++;
        _timeHasPassedStress++;

            if (_timeHasPassedHunger == _waitDebuffHunger)
            {
                _hungerValue++;
                _hunger.text = _hungerValue.ToString();
                _timeHasPassedHunger = 0;
                _debuffController.ChangeMaxFatigue_hunger(_hungerValue);
            }
            if (_timeHasPassedStress == _waitDebuffStress)
            {
                _stressValue++;
                _stress.text = _stressValue.ToString();
                _timeHasPassedStress = 0;
            }


            if (min != 59)
        {
            min++;
        }
        else
        {
            min = 0;
            if (hour != 23)
            {
                hour++;
            }
            else
            {
                hour = 0;
            }
        }

        _timeText.text = hour.ToString("D2")+":"+min.ToString("D2");

        yield return new WaitForSeconds(_speedGlobalTime);
        }
    }

}
