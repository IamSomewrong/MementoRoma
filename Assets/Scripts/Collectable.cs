using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Destroy(gameObject);
    }
}
