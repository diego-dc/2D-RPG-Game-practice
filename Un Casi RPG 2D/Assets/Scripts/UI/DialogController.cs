using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] public StringValue stringValueText;
    private string stringText;
    [SerializeField] private SignalSender dialogSignal;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject dialogObject;
    [SerializeField] private bool dialogActive = false;


    public void Start()
    {
        dialogObject.SetActive(false);
    }

    public void ActivateDialog()
    {
        dialogActive = !dialogActive;
        if (dialogActive)
        {
            SetDialog();
        }
        else
        {
            DeactivateDialog();
        }
    }

    void SetDialog()
    {
        dialogObject.SetActive(true);
        dialogText.text = stringValueText.value;
    }

    void DeactivateDialog()
    {
        dialogObject.SetActive(false);
    }

}
