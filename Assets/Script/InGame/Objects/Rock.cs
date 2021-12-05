using System;
using System.Collections.Generic;

public class Rock : InteractableObject
{
    
    private void Awake()
    {
        InitUniqueObjectVariables();
    }

    public override void InitUniqueObjectVariables()
    {
        name = "Rock";
        isHoldable = true;
        examineDescription = "Its a rock.";
        Interactions.Add("Pick Up",Interactions.Count-1);
    }
    
    public override void ExecuteInteraction(int interaction)
    {
        switch (interaction)
        {
            case 0:
                Examine();
                break;
            case 1:
                Drop();
                break;
            case 2:
                Throw();
                break;
        }
    }
    
}
