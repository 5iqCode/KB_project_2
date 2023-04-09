using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //������������ ������
{
    public float _speedHero; //������� �������� ����� � ������ ��������
    private float _halfSpeedHero; // �������� �������� ��� ������� ��������

    [SerializeField] private float _speedUpHero; //�������� � ������� ������
    
    public float _speedHeroDefault; //�������� ��� ��������

    public Vector2 _direction;

    private Rigidbody2D _rbHero;


    private KeyboardEvents _keyboardEvents;
    public GameObject _takedBlock; //���� � �����

    [SerializeField] private float _distanceBlockInHeands; // ��������� ���� ������� �� �������� �����

    private float _boxWeight = 0; //��� ����� ����� ��� ������� ��������
    public float _ratioDebaffWeight = 1; //��������� ������� ��������, ��������� �� ����

    private void Awake()
    {
        _rbHero = GetComponent<Rigidbody2D>();
        SpeedManageAwake();

        _keyboardEvents = GetComponent<KeyboardEvents>();
    }
    private void SpeedManageAwake()
    {
        _halfSpeedHero = _speedHero / 1.5f;

        _speedHeroDefault = _speedHero;

    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
        _takedBlock = _keyboardEvents._takedBlock;

        if (_takedBlock != null) //���������������� ����� ��� ������������ �����
        {


            _takedBlock.transform.localPosition = _direction * _distanceBlockInHeands;
            _boxWeight = _takedBlock.GetComponent<Box>()._weight;
            _ratioDebaffWeight = RatioDebaffWeight(_boxWeight);
        }
        else // ����� �� ����� �����
        {
            _boxWeight = 0;
            _ratioDebaffWeight = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift)) // ����� ����� ����, ����������� ��� ����� 
        {
            _speedHero = _speedUpHero / _ratioDebaffWeight;
            _halfSpeedHero = _speedUpHero/ 1.5f / _ratioDebaffWeight;
        }
        else
        {
            _speedHero = _speedHeroDefault /_ratioDebaffWeight;
            _halfSpeedHero = _speedHeroDefault/1.5f / _ratioDebaffWeight;
        }
    }

    private float RatioDebaffWeight(float _boxWeight) // �������� ������� � ����������� � ����� �����
    {
        if (_boxWeight >= 2)
        {
            return 2;
        } else if (_boxWeight >= 1)
        {
            return 1.5f;
        }
        else
        {
            return 1;
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude < 2) // ������������ �����
        {
            _rbHero.MovePosition(_rbHero.position + _direction * _speedHero * Time.fixedDeltaTime);
        }
        else
        {
            _rbHero.MovePosition(_rbHero.position + _direction * _halfSpeedHero * Time.fixedDeltaTime);
        }

    }
}
