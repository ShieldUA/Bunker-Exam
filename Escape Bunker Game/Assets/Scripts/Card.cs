using UnityEngine;

public class Card : MonoBehaviour
{
    public static bool hasCard = false; // Статична змінна для зберігання стану картки
    private bool isPlayerNear = false;  // Змінна для перевірки, чи гравець поруч з карткою

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true; // Гравець наблизився до картки
            Debug.Log("Гравець біля картки!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false; // Гравець відійшов від картки
            Debug.Log("Гравець відійшов від картки!");
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Q)) // Перевірка на натискання Q для взяття картки
        {
            hasCard = true;
            Debug.Log("Картка взята!");
            Destroy(gameObject); // Знищуємо картку після того, як гравець її забрав
        }
    }
}
