using UnityEngine;

public static class InputActions
{
    public static bool anyNumDown
    {
        get => (nineDown||eightDown||sevenDown||sixDown||fiveDown||fourDown||threeDown||twoDown||oneDown||zeroDown);
    }
    public static bool anyNumUp
    {
        get => (nineUp||eightUp||sevenUp||sixUp||fiveUp||fourUp||threeUp||twoUp||oneUp||zeroUp);
    }
    public static bool lmbDown
    {
        get => Input.GetMouseButton(0);
    }
    public static bool nineDown
    {
        get => Input.GetKey("9");
    }
    public static bool nineUp
    {
        get => Input.GetKeyUp("9");
    }
    public static bool eightDown
    {
        get => Input.GetKey("8");
    }
    public static bool eightUp
    {
        get => Input.GetKeyUp("8");
    }
    public static bool sevenDown
    {
        get => Input.GetKey("7");
    }
    public static bool sevenUp
    {
        get => Input.GetKeyUp("7");
    }
    public static bool sixDown
    {
        get => Input.GetKey("6");
    }
    public static bool sixUp
    {
        get => Input.GetKeyUp("6");
    }
    public static bool fiveDown
    {
        get => Input.GetKey("5");
    }
    public static bool fiveUp
    {
        get => Input.GetKeyUp("5");
    }
    public static bool fourDown
    {
        get => Input.GetKey("4");
    }
    public static bool fourUp
    {
        get => Input.GetKeyUp("4");
    }
    public static bool threeDown
    {
        get => Input.GetKey("3");
    }
    public static bool threeUp
    {
        get => Input.GetKeyUp("3");
    }
    public static bool twoDown
    {
        get => Input.GetKey("2");
    }
    public static bool twoUp
    {
        get => Input.GetKeyUp("2");
    }
    public static bool oneDown
    {
        get => Input.GetKey("1");
    }
    public static bool oneUp
    {
        get => Input.GetKeyUp("1");
    }
    public static bool zeroDown
    {
        get => Input.GetKey("0");
    }
    public static bool zeroUp
    {
        get => Input.GetKeyUp("0");
    }
    public static bool upDown
    {
        get => Input.GetKey(KeyCode.UpArrow);
    }

    public static bool leftDown
    {
        get => Input.GetKey(KeyCode.LeftArrow);
    }
    public static bool downDown
    {
        get => Input.GetKey(KeyCode.DownArrow);
    }
    public static bool rightDown
    {
        get => Input.GetKey(KeyCode.RightArrow);
    }
    public static bool qDown
    {
        get => Input.GetKey(KeyCode.Q);
    }
    public static bool eDown
    {
        get => Input.GetKey(KeyCode.E);
    }
    public static bool upUp 
    {
        get => Input.GetKeyUp(KeyCode.UpArrow);
    }
    public static bool leftUp
    {
        get => Input.GetKeyUp(KeyCode.LeftArrow);
    }
    public static bool downUp
    {
        get => Input.GetKeyUp(KeyCode.DownArrow);
    }
    public static bool rightUp
    {
        get => Input.GetKeyUp(KeyCode.RightArrow);
    }
    public static bool wDown
    {
        get => Input.GetKey(KeyCode.W);
    }
    public static bool wUp
    {
        get => Input.GetKeyUp(KeyCode.W);
    }
    public static bool aDown
    {
        get => Input.GetKey(KeyCode.A);
    }
    public static bool aUp
    {
        get => Input.GetKeyUp(KeyCode.A);
    }
    public static bool sDown
    {
        get => Input.GetKey(KeyCode.S);
    }
    public static bool sUp
    {
        get => Input.GetKeyUp(KeyCode.S);
    }
    public static bool dDown
    {
        get => Input.GetKey(KeyCode.D);
    }
    public static bool dUp
    {
        get => Input.GetKeyUp(KeyCode.D);
    }

    public static int GetNumberPressed()
    {
        if (zeroDown)
            return 0;
        if (oneDown)
            return 1;
        if (twoDown)
            return 2;
        if (threeDown)
            return 3;
        if (fourDown)
            return 4;
        if (fiveDown)
            return 5;
        if (sixDown)
            return 6;
        if (sevenDown)
            return 7;
        if (eightDown)
            return 8;
        if (nineDown)
            return 9;

        return -1;
    }
    public static int GetNumberReleased()
    {
        if (zeroUp)
            return 0;
        if (oneUp)
            return 1;
        if (twoUp)
            return 2;
        if (threeUp)
            return 3;
        if (fourUp)
            return 4;
        if (fiveUp)
            return 5;
        if (sixUp)
            return 6;
        if (sevenUp)
            return 7;
        if (eightUp)
            return 8;
        if (nineUp)
            return 9;

        return -1;
    }
}
