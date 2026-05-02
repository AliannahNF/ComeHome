using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == 0) return; // not moving, keep last animation

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
                animator.Play("Walk_Right");
            else
                animator.Play("Walk_Left");
        }
        else
        {
            if (y > 0)
                animator.Play("Walk_Up");
            else
                animator.Play("Walk_Down");
        }
    }
}
