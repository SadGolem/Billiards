using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoSuperman : MonoBehaviour
{
    Rigidbody superball;

    public float valueMultiplier = 10f; // Множитель для регулирования значения
    private float holdTime = 0f; // Длительность нажатия // Флаг для отслеживания состояния нажатия

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
            // Увеличиваем holdTime на время кадра, когда клавиша удерживается
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
        // Ваш код для регулирования значения в зависимости от длительности нажатия
        currentValue = holdTime * valueMultiplier;
        Debug.Log("Значение: " + currentValue);
    }

    private void SupermanInGoing(float currentValue)
    {
        if (superball != null)
        {
            superball.AddForce(0, 0, currentValue, ForceMode.Impulse);
        }
    }
}
