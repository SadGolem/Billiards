using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoSuperman : MonoBehaviour
{
    Rigidbody superball;

    public float valueMultiplier = 10f; // ��������� ��� ������������� ��������
    private float holdTime = 0f; // ������������ ������� // ���� ��� ������������ ��������� �������

    private KeyCode isHolding = KeyCode.Space;
    float currentValue = 0;

    private void Start()
    {
        superball = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
        if (Input.GetKey(isHolding))
        {
            // ����������� holdTime �� ����� �����, ����� ������� ������������
            holdTime += Time.deltaTime;
        }
        else if (Input.GetKeyUp(isHolding))
        {
            CalculateValue();
            holdTime = 0f;
            SupermanInGoing(currentValue);
        }
    }

    private void CalculateValue()
    {
        // ��� ��� ��� ������������� �������� � ����������� �� ������������ �������
        currentValue = holdTime * valueMultiplier;
        Debug.Log("��������: " + currentValue);
    }

    private void SupermanInGoing(float currentValue)
    {
        if (superball != null)
        {
            superball.AddForce(0, 0, currentValue, ForceMode.Impulse);
        }
    }
}
