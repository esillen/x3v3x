using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Put this in the same component as the player. They depend on each other.
public class ControlMap : MonoBehaviour
{
  private KeyCode leftKeyCode;
  private KeyCode leftKeyCode_alternative;
  private KeyCode rightKeyCode;
  private KeyCode rightKeyCode_alternative;
  private KeyCode centerKeyCode;
  private KeyCode centerKeyCode_alternative;

  void Start()
  {
    int playerNumber = GetComponent<Player>().playerNumber;

    int controllerIndex = PlayerNumberToControllerIndex(playerNumber);

    leftKeyCode = KEY_MAPPINGS[controllerIndex].leftKeyCode;
    leftKeyCode_alternative = KEY_MAPPINGS[controllerIndex].leftKeyCode_alternative;
    centerKeyCode = KEY_MAPPINGS[controllerIndex].centerKeyCode;
    centerKeyCode_alternative = KEY_MAPPINGS[controllerIndex].centerKeyCode_alternative;
    rightKeyCode = KEY_MAPPINGS[controllerIndex].rightKeyCode;
    rightKeyCode_alternative = KEY_MAPPINGS[controllerIndex].rightKeyCode_alternative;

    SanityCheck();
  }


  public bool LeftKeyPressed => Input.GetKey(leftKeyCode) || Input.GetKey(leftKeyCode_alternative);
  public bool RightKeyPressed => Input.GetKey(rightKeyCode) || Input.GetKey(rightKeyCode_alternative);
  public bool CenterKeyPressed => Input.GetKey(centerKeyCode) || Input.GetKey(centerKeyCode_alternative);

  private record KeyMap(
    KeyCode leftKeyCode,
      KeyCode leftKeyCode_alternative,
      KeyCode centerKeyCode,
      KeyCode centerKeyCode_alternative,
      KeyCode rightKeyCode,
      KeyCode rightKeyCode_alternative
  );

  private void SanityCheck()
  {
    // All keycodes should be uniqye
    HashSet<KeyCode> keycodes = new HashSet<KeyCode>();
    void AddToKeyCodesIfUnique(KeyCode keyCode)
    {
      if (!keycodes.Contains(keyCode))
      {
        keycodes.Add(keyCode);
      }
      else
      {
        Debug.LogError("Keycode assigned more than once:" + keyCode);
      }
    }
    foreach (KeyMap keymap in KEY_MAPPINGS.Values)
    {
      AddToKeyCodesIfUnique(keymap.leftKeyCode);
      AddToKeyCodesIfUnique(keymap.leftKeyCode_alternative);
      AddToKeyCodesIfUnique(keymap.rightKeyCode);
      AddToKeyCodesIfUnique(keymap.rightKeyCode_alternative);
      AddToKeyCodesIfUnique(keymap.centerKeyCode);
      AddToKeyCodesIfUnique(keymap.centerKeyCode_alternative);
    }
  }

  // This ugly hack is so that the controller mappings below make sense on the physical device.
  public int PlayerNumberToControllerIndex(int playerNumber)
  {

    Dictionary<int, int> keyMap = new Dictionary<int, int>{
        {1, 5},
        {2, 6},
        {3, 7},
        {4, 1},
        {5, 2},
        {6, 3}
    };

    return keyMap[playerNumber];

  }

  private static readonly Dictionary<int, KeyMap> KEY_MAPPINGS = new Dictionary<int, KeyMap> {
        {0, new KeyMap(
            leftKeyCode: KeyCode.Q,
            leftKeyCode_alternative: KeyCode.Joystick3Button0,
            centerKeyCode: KeyCode.W,
            centerKeyCode_alternative: KeyCode.Joystick3Button6,
            rightKeyCode: KeyCode.E,
            rightKeyCode_alternative: KeyCode.Joystick3Button1)
        },
        {1, new KeyMap(
            leftKeyCode: KeyCode.R,
            leftKeyCode_alternative: KeyCode.Joystick3Button7,
            centerKeyCode: KeyCode.T,
            centerKeyCode_alternative: KeyCode.Joystick3Button10,
            rightKeyCode: KeyCode.Y,
            rightKeyCode_alternative: KeyCode.Joystick3Button9)
        },
        {2, new KeyMap(
            leftKeyCode: KeyCode.U,
            leftKeyCode_alternative: KeyCode.Joystick2Button7,
            centerKeyCode: KeyCode.I,
            centerKeyCode_alternative: KeyCode.Joystick2Button8,
            rightKeyCode: KeyCode.O,
            rightKeyCode_alternative: KeyCode.Joystick2Button6)
        },
        {3, new KeyMap(
            leftKeyCode: KeyCode.A,
            leftKeyCode_alternative: KeyCode.Joystick2Button4,
            centerKeyCode: KeyCode.S,
            centerKeyCode_alternative: KeyCode.Joystick2Button5,
            rightKeyCode: KeyCode.D,
            rightKeyCode_alternative: KeyCode.Joystick2Button3)
        },
        {4, new KeyMap(
            leftKeyCode: KeyCode.F,
            leftKeyCode_alternative: KeyCode.Joystick2Button1,
            centerKeyCode: KeyCode.G,
            centerKeyCode_alternative: KeyCode.Joystick2Button2,
            rightKeyCode: KeyCode.H,
            rightKeyCode_alternative: KeyCode.Joystick2Button0)
        },
        {5, new KeyMap(
            leftKeyCode: KeyCode.J,
            leftKeyCode_alternative: KeyCode.Joystick1Button1,
            centerKeyCode: KeyCode.K,
            centerKeyCode_alternative: KeyCode.Joystick1Button2,
            rightKeyCode: KeyCode.L,
            rightKeyCode_alternative: KeyCode.Joystick1Button0)
        },
        {6, new KeyMap(
            leftKeyCode: KeyCode.Z,
            leftKeyCode_alternative: KeyCode.Joystick1Button3,
            centerKeyCode: KeyCode.X,
            centerKeyCode_alternative: KeyCode.Joystick1Button5,
            rightKeyCode: KeyCode.C,
            rightKeyCode_alternative: KeyCode.Joystick1Button4)
        },
        {7, new KeyMap(
            leftKeyCode: KeyCode.V,
            leftKeyCode_alternative: KeyCode.Joystick3Button2,
            centerKeyCode: KeyCode.B,
            centerKeyCode_alternative: KeyCode.Joystick3Button5,
            rightKeyCode: KeyCode.N,
            rightKeyCode_alternative: KeyCode.Joystick3Button4)
        },
    };


  public static bool AnyLeftKeyDown()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      return true;
    }
    foreach (KeyMap keymap in KEY_MAPPINGS.Values)
    {
      if (Input.GetKeyDown(keymap.leftKeyCode) || Input.GetKeyDown(keymap.leftKeyCode_alternative))
      {
        return true;
      }
    }
    return false;
  }


  public static bool AnyRightKeyDown()
  {
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      return true;
    }
    foreach (KeyMap keymap in KEY_MAPPINGS.Values)
    {
      if (Input.GetKeyDown(keymap.rightKeyCode) || Input.GetKeyDown(keymap.rightKeyCode_alternative))
      {
        return true;
      }
    }
    return false;
  }

}




// This fixes a stupid bug with records
namespace System.Runtime.CompilerServices
{
  internal static class IsExternalInit { }
}


