using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int fusesInserted = 0;
    public FuseBox fuseBox;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddFuse()
    {
        fusesInserted++;
        Debug.Log("Запобіжники вставлені: " + fusesInserted); // Виводить кількість вставлених запобіжників
        if (fusesInserted >= 3)
        {
            fuseBox.ActivatePower();  // Активує електрику, якщо вставлено 3 запобіжники
        }
    }
}
