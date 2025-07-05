using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RadialMenuItem : MonoBehaviour
{
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
        GetComponentInParent<RadialLayout>().SelectionChanged += OnSelect;
    }
    public void OnSelect(RadialMenuItem item)
    {
        if(item == this)
        {
            _image.color = Color.red;
        }
        else
        {
            _image.color = Color.white;
        }
    }
    public void Clicked()
    {
        print("ŒÔ‡");
    }
}
