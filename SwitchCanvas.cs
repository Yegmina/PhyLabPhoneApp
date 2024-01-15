using UnityEngine;
using UnityEngine.UI;

public class SwitchCanvas : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    

   

    public void SwitchCanvasState()
    {
        // Включение Canvas 1 и выключение Canvas 2
        canvas1.enabled = !canvas1.enabled;
		
        canvas2.enabled = !canvas2.enabled;
    }
}
