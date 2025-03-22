using UnityEngine;

public class Fuse : MonoBehaviour
{
    public FuseBox fuseBox; // Ссилка на об'єкт FuseBox для виклику методів в ньому

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Гравець підняв запобіжник!");
            fuseBox.InsertFuse();  // Викликає метод додавання запобіжника в FuseBox
            Destroy(gameObject);  // Знищує об'єкт після того, як його підібрали
        }
    }
}
