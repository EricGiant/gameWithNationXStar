using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Shake : MonoBehaviour
{
  public Animator camAnim;
  
  public void CamShake(){
      camAnim.SetTrigger("shake");
  }

  
}
