using UnityEngine;
using System.Collections;

public class FuseBox : MonoBehaviour
{
    public Transform door;
    public Light flickeringLight;
    public Light stableLight;
    public float doorOpenHeight = 3f;
    public float doorOpenSpeed = 2f;
    private bool powerActivated = false;

    void Start()
    {
        stableLight.enabled = false;
        StartCoroutine(FlickerLight());
    }

    public void InsertFuse()
    {
        GameManager.Instance.AddFuse(); // Додає запобіжник в GameManager
    }

    public void ActivatePower()
    {
        flickeringLight.enabled = false;
        stableLight.enabled = true;
        powerActivated = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && powerActivated)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator FlickerLight()
    {
        while (!powerActivated)
        {
            flickeringLight.enabled = !flickeringLight.enabled;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }

    IEnumerator OpenDoor()
    {
        Vector3 targetPosition = door.position + new Vector3(0, doorOpenHeight, 0);
        while (Vector3.Distance(door.position, targetPosition) > 0.01f)
        {
            door.position = Vector3.Lerp(door.position, targetPosition, Time.deltaTime * doorOpenSpeed);
            yield return null;
        }
        door.position = targetPosition;
    }
}
