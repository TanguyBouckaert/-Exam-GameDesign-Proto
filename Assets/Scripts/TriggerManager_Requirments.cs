using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager_Requirments : MonoBehaviour
{
    [SerializeField]
    private UIManager_02 UI;

    [SerializeField]
    private bool green, red, blue;

    [SerializeField]
    private Material _ownMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Train") && _ownMaterial == other.GetComponentInChildren<Renderer>().sharedMaterial)
        {
            if(green) UI.UpdateScoreGreen();
            if(red) UI.UpdateScoreRed();
            if(blue) UI.UpdateScoreBlue();
        }
    }

}
