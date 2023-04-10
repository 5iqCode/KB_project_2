using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //передвижение игрока
{
    public float _speedHero; //текущая скорость героя с учетом дебаффов
    private float _halfSpeedHero; // половина скорости для удобных расчетов

    [SerializeField] private float _speedUpHero; //скорость с нажатым шифтом
    
    public float _speedHeroDefault; //скорость без дебаффов

    public Vector2 _direction;

    private Rigidbody2D _rbHero;


    private KeyboardEvents _keyboardEvents;
    public GameObject _takedBlock; //блок в руках

    [SerializeField] private float _distanceBlockInHeands; // насколько блок отдален от главного героя

    private float _boxWeight = 0; //вес блока нужен для дебаффа скорости
    public float _ratioDebaffWeight = 1; //множитель дебаффа скорости, зависящий от веса

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

        if (_takedBlock != null) //позиционирование блока при передвижении героя
        {


            _takedBlock.transform.localPosition = _direction * _distanceBlockInHeands;
            _boxWeight = _takedBlock.GetComponent<Box>()._weight;
            _ratioDebaffWeight = RatioDebaffWeight(_boxWeight);
        }
        else // герой не имеет блока
        {
            _boxWeight = 0;
            _ratioDebaffWeight = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift)) // игрок нажал шифт, учитывается вес блока 
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

    private float RatioDebaffWeight(float _boxWeight) // значение дебаффа в соотвествии с весом блока
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
        if (_direction.sqrMagnitude < 2) // передвижение героя
        {
            _rbHero.MovePosition(_rbHero.position + _direction * _speedHero * Time.fixedDeltaTime);
        }
        else
        {
            _rbHero.MovePosition(_rbHero.position + _direction * _halfSpeedHero * Time.fixedDeltaTime);
        }

    }
}
