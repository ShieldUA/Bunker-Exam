using UnityEngine;
using System.Collections;

public class LeverSwitch : MonoBehaviour
{
    public GameObject door;  // Посилання на двері
    public GameObject shieldOff;  // Щиток з текстом "Відмовлено"
    public GameObject shieldOn;   // Щиток з текстом "Дозволено"
    public float openHeight = 3f; // Висота, на яку піднімаються двері
    public float openSpeed = 2f; // Швидкість підняття дверей
    private bool isPlayerNear = false;
    private bool isDoorOpen = false;

    void Start()
    {
        // Початково показуємо щиток з текстом "Відмовлено"
        shieldOff.SetActive(true);
        shieldOn.SetActive(false);
    }

    void Update()
    {
        // Якщо гравець натискає E біля щитка і має картку та двері ще не відкриті
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && Card.hasCard && !isDoorOpen)
        {
            Debug.Log("Натиснуто E та є картка, відкриваємо двері...");
            StartCoroutine(OpenDoor(openHeight, openSpeed)); // Відкриваємо двері
            isDoorOpen = true; // Встановлюємо, що двері відкриті
            Debug.Log("Двері відкрито!");

            // Заміна щитка після натискання E
            shieldOff.SetActive(false); // Приховуємо щиток з текстом "Відмовлено"
            shieldOn.SetActive(true);   // Показуємо щиток з текстом "Дозволено"
        }
    }

    // Корутіна для відкриття дверей
    IEnumerator OpenDoor(float height, float speed)
    {
        if (door != null)
        {
            Vector3 startPos = door.transform.position;
            Vector3 endPos = startPos + new Vector3(0, height, 0);
            float elapsedTime = 0f;

            Debug.Log("Запускається корутина для відкриття дверей.");

            // Перевірка кожного кроку
            while (elapsedTime < height / speed)
            {
                door.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime * speed) / height);
                elapsedTime += Time.deltaTime;

                Debug.Log("Позиція дверей: " + door.transform.position);  // Вивести позицію дверей для моніторингу

                yield return null;
            }

            door.transform.position = endPos;  // Гарантуємо, що двері досягли кінцевої позиції
            Debug.Log("Двері відкриті до кінця: " + door.transform.position);
        }
        else
        {
            Debug.LogError("Не знайдено двері!");
        }
    }

    // Коли гравець входить в тригер
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Перевірка, чи це гравець
        {
            isPlayerNear = true;
            Debug.Log("Гравець біля щитка!");
        }
    }

    // Коли гравець виходить з тригера
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Гравець відійшов від щитка!");
        }
    }
}
