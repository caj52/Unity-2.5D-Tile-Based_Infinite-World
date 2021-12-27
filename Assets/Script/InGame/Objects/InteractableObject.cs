using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class InteractableObject: MonoBehaviour
{
   public string name;
   public bool beingHeld;
   public string examineDescription;
   private bool inventoryObject;

   [Header("Unique Interactions")] 
   public bool canPickUp;

   public bool isConsumable;

   public List<InteractionTypes.Interaction> Interactions = new List<InteractionTypes.Interaction>()
   {
      InteractionTypes.Interaction.Examine
   };
   public List<InteractionTypes.Interaction> HeldInteractions = new List<InteractionTypes.Interaction>()
   {
      InteractionTypes.Interaction.Drop,
      InteractionTypes.Interaction.Throw
   };
   
   private void Awake()
   {
      InitUniqueObjectVariables();
   }

   public List<InteractionTypes.Interaction> GetCurrentInteractions()
   {
      if (beingHeld)
      {
         foreach (var interaction in HeldInteractions)
            Interactions.Add(interaction);
      }

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
         Interactions.Add(InteractionTypes.Interaction.Pick_Up);
      if (isConsumable)
         Interactions.Add(InteractionTypes.Interaction.Eat);
   }

   public virtual void ExecuteInteraction(int interaction)
   {
      switch (interaction)
      {
         case 0:
            Examine();
            break;
         case 1:
            break;
         case 2:
            break;
      }
   }

   public virtual void Drop()
   {
   }
   public virtual void Examine()
   {
      HUDTextBox.Instance.ShowText(examineDescription);
   }
   public virtual void Throw()
   {
      
   }
}
