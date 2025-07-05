
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private List<IInteractable> _interactables;

    private void Awake()
    {
        _interactables = new List<IInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable)) 
        {
            _interactables.Add(interactable);
        }
        
        print(_interactables.Count);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            _interactables.Remove(interactable);
        }
        print(_interactables.Count);
    }


    public void OnInteract()
    {
        if (_interactables.Count == 0) { return; }
        _interactables.Last().OnInteract();
    }
}
