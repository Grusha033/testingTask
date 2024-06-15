using UnityEngine;

public class Message : MonoBehaviour
{
    private Animator _anim => GetComponent<Animator>();

    private void OnEnable() 
    {
        Trigger.enterTrigger += OpenMessagePanel;
        Trigger.exitTrigger += CloseMessagePanel;
    }

    private void OnDisable() 
    {
        Trigger.enterTrigger -= OpenMessagePanel;
        Trigger.exitTrigger -= CloseMessagePanel;
    }

    private void OpenMessagePanel()
    {
        _anim.SetBool("open", true);
    }

    private void CloseMessagePanel()
    {
        _anim.SetBool("open", false);
    }
}