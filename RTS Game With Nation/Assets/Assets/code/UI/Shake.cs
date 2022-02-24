using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Shake : MonoBehaviour
{
  public Animator camAnim;
  
  public void CamShake(){
      camAnim.SetTrigger("shake");
  }
}
