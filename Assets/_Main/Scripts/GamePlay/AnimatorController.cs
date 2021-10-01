using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : Singleton<AnimatorController>
{
   [SerializeField] private Animator leftAnim;
   [SerializeField] private Animator rightAnim;

   public void LeftAnim()
   {
      leftAnim.SetTrigger("Move");
   }

   public void RightAnim()
   {
      rightAnim.SetTrigger("Shoot");
   }
}
