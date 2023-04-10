using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FatigueController : MonoBehaviour
{
    [SerializeField] private float _speedFatigueDefaultWithBlock;// ����� ��� ������ � ������
    [SerializeField] private float _speedFatigueRunningWithBlock;//������ � ������ ��� ����

    [SerializeField] private float _speedRecoveryStay;// �������������� ��� ������
    [SerializeField] private float _speedRecoveryDefault; // �������������� ��� ������
    [SerializeField] private float _speedFatigueRunning; // ������ ��� ����


    private PlayerController _playerController;
    private KeyboardEvents _KeyboardEvents;


    private GameObject _takedBlock;
    private Vector2 _direction;

    private Slider _sliderFatigue;

    private float _boxWeight=0;
    private void Awake()
    {
        _sliderFatigue  = GetComponent<Slider>();
        _playerController = GameObject.Find("MainHero").GetComponent<PlayerController>();
        _KeyboardEvents = GameObject.Find("MainHero").GetComponent<KeyboardEvents>();
    }

    private void Start()
    {
        float _MaxFatigue = GameObject.Find("Main Camera").GetComponent<GlobalObjects>()._MaxFatigue;

        _sliderFatigue.maxValue = _MaxFatigue;
    }

    private void FixedUpdate()
    {
        _takedBlock = _playerController._takedBlock;

        _direction = _playerController._direction;


        if (_takedBlock == null)
        {
            _boxWeight = 0;
        }
        else
        {
            _boxWeight = _takedBlock.GetComponent<Box>()._weight;
        }
            Move();

        if ((_sliderFatigue.value == 0)&&(_takedBlock!=null))
        {
            TossBox();
        }

    }
    private void TossBox()
    {

           if(_takedBlock.TryGetComponent<FragileBox>(out FragileBox _fragile))
           {
            _fragile.DamageBlock(_takedBlock);
        }
        else
        {
            _KeyboardEvents.TossBlock();
        }
    }

    private void FatigueBecouseOfWeight(int _ratioWeight) //������ � ������������ �� ��� ����� (3 ���� ���� 0 1 � 2)
    {
        
        if (_boxWeight >= 2)
        {
            _sliderFatigue.value -= (float)2 / 100 * Time.fixedDeltaTime * _ratioWeight;
        }
        else if (_boxWeight >= 1)
        {
            _sliderFatigue.value -= (float) 0.5 / 100 * Time.fixedDeltaTime * _ratioWeight;
        }
    }
    private void Move() 
    {
        int _ratioWeight = 1; //��������� ������� ����

        if (_direction == Vector2.zero) //���� ����� ����� ������ ����� � ������ ���� ���� ���� ����, ����� ������� ��������������
        {
            _ratioWeight = 1;
            if (_takedBlock != null)
            {
                FatigueBecouseOfWeight(_ratioWeight);
            }
            else
            {
                _sliderFatigue.value += _speedRecoveryStay / 100 * Time.fixedDeltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift)==false) //���� ����� ������������� ��� �����
        {
            _ratioWeight = 2;
            if (_takedBlock != null) // ������ ��� ������������ + ����� ����
            {
                FatigueBecouseOfWeight(_ratioWeight);
                _sliderFatigue.value -= _speedFatigueDefaultWithBlock / 100 * Time.fixedDeltaTime;
            }
            else
            {
                _sliderFatigue.value += _speedRecoveryDefault / 100 * Time.fixedDeltaTime; // ������ ������������
            }
            
        }
        else
        {
            _ratioWeight = 10;
            if (_takedBlock != null)
            {
                FatigueBecouseOfWeight(_ratioWeight); //����� ����
                _sliderFatigue.value -= _speedFatigueRunningWithBlock / 100 * Time.fixedDeltaTime;
            }
            else
            {
                _sliderFatigue.value -= _speedFatigueRunning / 100 * Time.fixedDeltaTime;
            }
            
        }
    }
}
