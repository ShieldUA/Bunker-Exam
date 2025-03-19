using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    public GameObject door;  // Посилання на двері
    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // Якщо гравець натискає E
        {
            OpenDoor(); // Викликаємо функцію відкриття дверей
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.transform.position += new Vector3(0, 3, 0); // Піднімаємо двері вгору
            Destroy(gameObject); // Видаляємо рубильник після використання
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Перевіряємо, чи це гравець
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
