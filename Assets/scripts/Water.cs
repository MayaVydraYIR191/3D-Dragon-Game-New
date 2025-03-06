using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player")&&other.GetComponent<CharacterController>()!=null)
      {
         CharacterController move = other.GetComponent<CharacterController>();
      }

   }

   private void OnTriggerExit(Collider other)
   {

   }
}
