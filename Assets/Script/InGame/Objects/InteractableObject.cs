
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class InteractableObject: MonoBehaviour
{
   public string name;
   public bool beingHeld;
   public string examineDescription;

   [Header("Unique Interactions")] 
   public bool canPickUp;
   
   public Dictionary<string, int> Interactions = new Dictionary<string, int>
   {
      {"Examine", 0},
   };
   public Dictionary<string, int> HeldInteractions = new Dictionary<string, int>
   {
      {"Drop", 1},
      {"Throw", 2}
   };

   private void Awake()
   {
      InitUniqueObjectVariables();
   }

   public Dictionary<string, int> GetCurrentInteractions()
   {
      if (beingHeld)
         return HeldInteractions;
      
      return Interactions;
   }

   public void ClearInteractions()
   {
      Interactions.Clear();
      HeldInteractions.Clear();
   }

   public virtual void InitUniqueObjectVariables()
   {
      if (canPickUp)
      {
         Interactions.Add("Pick Up",Interactions.Count+1);
      }
   }
   public virtual void ExecuteInteraction(int interaction) { }

   public virtual void Drop()
   {
   }
   public virtual void Examine()
   {
      Debug.Log(examineDescription);
   }
   public virtual void Throw()
   {
      
   }
}
