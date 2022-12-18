using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
   public DedPlayer DedSound;
   public CarPlayer CarSound;
   public SounderPlayer SounderSound;

   

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.D))
      {
         DedSound.StartCoroutine(DedSound.PlaySound());
      }
      if (Input.GetKeyDown(KeyCode.C))
      {
         CarSound.StartCoroutine(CarSound.PlaySound());
      }
      if (Input.GetKeyDown(KeyCode.S))
      {
         SounderSound.StartCoroutine(SounderSound.PlaySound());
      }
   }
}
