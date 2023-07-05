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
    int playerIndex = GetComponent<Player>().playerNumber;

    leftKeyCode = KEY_MAPPINGS[playerIndex].leftKeyCode;
    leftKeyCode_alternative = KEY_MAPPINGS[playerIndex].leftKeyCode_alternative;
    centerKeyCode = KEY_MAPPINGS[playerIndex].centerKeyCode;
    centerKeyCode_alternative = KEY_MAPPINGS[playerIndex].centerKeyCode_alternative;
    rightKeyCode = KEY_MAPPINGS[playerIndex].rightKeyCode;
    rightKeyCode_alternative = KEY_MAPPINGS[playerIndex].rightKeyCode_alternative;

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

  private void SanityCheck() {
    // All keycodes should be uniqye
    HashSet<KeyCode> keycodes = new HashSet<KeyCode>();
    void AddToKeyCodesIfUnique(KeyCode keyCode) {
        if (!keycodes.Contains(keyCode)) {
            keycodes.Add(keyCode);
        } else {
            Debug.LogError("Keycode assigned more than once:" + keyCode);
        }
    }
    foreach(KeyMap keymap in KEY_MAPPINGS.Values) {
        AddToKeyCodesIfUnique(keymap.leftKeyCode);
        AddToKeyCodesIfUnique(keymap.leftKeyCode_alternative);
        AddToKeyCodesIfUnique(keymap.rightKeyCode);
        AddToKeyCodesIfUnique(keymap.rightKeyCode_alternative);
        AddToKeyCodesIfUnique(keymap.centerKeyCode);
        AddToKeyCodesIfUnique(keymap.centerKeyCode_alternative);
    }
  }

  private static readonly Dictionary<int, KeyMap> KEY_MAPPINGS = new Dictionary<int, KeyMap> {
        {0, new KeyMap(
            leftKeyCode: KeyCode.Q, 
            leftKeyCode_alternative: KeyCode.Joystick3Button6, 
            centerKeyCode: KeyCode.W, 
            centerKeyCode_alternative: KeyCode.Joystick3Button8, 
            rightKeyCode: KeyCode.E, 
            rightKeyCode_alternative: KeyCode.Joystick3Button7)
        },
        {1, new KeyMap(
            leftKeyCode: KeyCode.R, 
            leftKeyCode_alternative: KeyCode.Joystick3Button9, 
            centerKeyCode: KeyCode.T, 
            centerKeyCode_alternative: KeyCode.Joystick3Button11, 
            rightKeyCode: KeyCode.Y, 
            rightKeyCode_alternative: KeyCode.Joystick3Button10)
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
            leftKeyCode_alternative: KeyCode.Joystick3Button3, 
            centerKeyCode: KeyCode.B, 
            centerKeyCode_alternative: KeyCode.Joystick3Button5, 
            rightKeyCode: KeyCode.N, 
            rightKeyCode_alternative: KeyCode.Joystick3Button4)
        },
    };
}

// This fixes a stupid bug with records
namespace System.Runtime.CompilerServices
    {
          internal static class IsExternalInit {}
    }


