using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

  public void SwitchState()
    {
        animator.Play("StartCam");
    }
}
