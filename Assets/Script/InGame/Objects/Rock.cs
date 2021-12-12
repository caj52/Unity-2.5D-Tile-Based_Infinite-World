using System;
using System.Collections.Generic;

public class Rock : InteractableObject
{
    
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
