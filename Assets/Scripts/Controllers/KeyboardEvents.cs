using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardEvents : MonoBehaviour
{
    private GameObject[] _MovableBlocks;

    public GameObject _takedBlock;

    [SerializeField] private Slider _fatigue;

    [SerializeField] private float _takeDistance;// ��������� �������� �����
    [SerializeField] private float _tossDistance; //��������� ����������� �����
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (_takedBlock != null)
            {
                TossBlock();
            }
            else
            {
                if (_fatigue.value > (_fatigue.maxValue / 10))
                {
                    TryToTakeBlock();
                }
                else
                {
                    Debug.Log("�� ������");
                }
            }
        }
    }
    public void TossBlock() // ������� ����
    {
        _takedBlock.transform.parent = null;
        _takedBlock = null;
    }
    private void TryToTakeBlock() // ������� ��������� ����
    {
        _MovableBlocks = GameObject.FindGameObjectsWithTag("movableBlock"); // ����� ���� ��������� ������
        if (_MovableBlocks.Length > 0)
        {
            float _closestDist = Vector3.Distance(_MovableBlocks[0].transform.position, transform.position); // ���������� �� ���������� �����
            GameObject _closestObject = _MovableBlocks[0]; //��������� ������
            for (int i = 1; i < _MovableBlocks.Length; i++) // ����� ���������� �� ���� ��������� ������
            {
                float _dist = Vector3.Distance(_MovableBlocks[i].transform.position, transform.position);
                if (_dist < _closestDist)
                {
                    _closestDist = _dist;
                    _closestObject = _MovableBlocks[i];
                }
            }
            if (_takeDistance > _closestDist) // ���� ��������� �������� ������ ���������� �� ���������� �����, �� ��� ����� �������
            {
                _closestObject.transform.position = gameObject.transform.position;
                _closestObject.transform.parent = gameObject.transform;

                _takedBlock = _closestObject;

            }
        }
    }
}
