using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkladController : MonoBehaviour
{
    [SerializeField] private Transform[] _PointsOnSklad; //����� ��� �������������

    public int _countBlockInSklad = 0; //���������� ������ �� ������

    private KeyboardEvents _keyboardEvents;

    private void Start()
    {
        _keyboardEvents = GameObject.Find("MainHero").GetComponent<KeyboardEvents>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_countBlockInSklad < _PointsOnSklad.Length) //���� ���� ����� �� ������
        {
            if (collision.CompareTag("movableBlock"))
            {
                putOnTheSklad();
            }
        }
    }

    private void putOnTheSklad() // �������� �� �����
    {
        GameObject _takedBlockTemp = _keyboardEvents._takedBlock;
        _keyboardEvents._takedBlock = null;
        _takedBlockTemp.transform.position = _PointsOnSklad[_countBlockInSklad].position;
        _takedBlockTemp.transform.parent = null;
        
        _takedBlockTemp.tag = "notMovableBlock"; // ������ ��� ���� ����� ���� ������ ���� �������

        _countBlockInSklad++;
    }
}
