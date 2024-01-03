using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [SerializeField]
    private UIManager UI;

    [SerializeField]
    private Material highlightedMaterial;

    private bool _isHighlighted = false;

    private void FixedUpdate()
    {
        Material mat = gameObject.GetComponent<Renderer>().sharedMaterial;
        if(mat == highlightedMaterial)
        {
            _isHighlighted = true;
        }
        else
        {
            _isHighlighted = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Train") && _isHighlighted)
        {
            UI.UpdateScore();
        }
    }

}
