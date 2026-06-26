using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] PlayerCharacterController characterController;
    [SerializeField] private Animator animator;
    private int velocityHash;

    private void Start()
    {
        velocityHash = Animator.StringToHash("Input Magnitude");
    }

    private void Update()
    {
        animator.SetFloat(velocityHash, Mathf.Abs(characterController.VelocityX));
    }
}
