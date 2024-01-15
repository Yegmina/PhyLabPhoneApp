using U = UnityEngine;
using UI = UnityEngine.UI;

public class AttachToAnchor : U.MonoBehaviour
{
    public U.HingeJoint2D a;
    public U.Transform b, C;
    public UI.Slider c, d;
    public UI.Text e;
    public UI.Slider f;

    private float g = 0.8f, h = 0.1f;

    private void i() {}

    private void j() {
        if (a == null || b == null) {
            U.Debug.LogError("a или b не заданы!");
            return;
        }
        U.Vector2 k = a.connectedAnchor;
        b.position = k;
    }

    public void l() {
        U.Vector2 m = a.anchor;
        m.y = c.value;
        a.anchor = m;
        U.Vector2 n = a.anchor;
        b.position = n;
        C.eulerAngles = new U.Vector3(0f, 0f, d.value);
        StartCoroutine(o());
        float p = 2f * U.Mathf.PI * U.Mathf.Sqrt(c.value / 9.81f);
        if (d.value != 0) {
            e.text = "Період=" + p.ToString("F2") + " секунд";
        }
    }

    private System.Collections.IEnumerator o() {
        U.Rigidbody2D q = C.GetComponent<U.Rigidbody2D>();
        q.bodyType = U.RigidbodyType2D.Kinematic;
        yield return new U.WaitForSeconds(1f);
        q.bodyType = U.RigidbodyType2D.Dynamic;
    }
}
