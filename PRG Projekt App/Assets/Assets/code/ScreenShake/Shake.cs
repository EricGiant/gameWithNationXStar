using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shake : MonoBehaviour
{
  public Animator camAnim;
  
  //do shake animation
  public void CamShake(){
      camAnim.SetTrigger("shake");
  }
}
