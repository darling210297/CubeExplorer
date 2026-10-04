using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static int Collected = 0;
    public static int Total = 0;

    private bool picked = false;

   
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetCounters()
    {
        Collected = 0;
        Total = 0;
    }

    void Awake()
    {
        Total++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (picked) return;               
        if (other.CompareTag("Player"))
        {
            picked = true;
            Collected++;
            Destroy(gameObject);
        }
    }
}