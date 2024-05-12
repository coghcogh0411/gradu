using UnityEngine;

// https://gist.github.com/bozzin/5895d97130e148e66b88ff4c92535b59

public class DepthFX : MonoBehaviour
{
    public float power = -0.02f;

    void Update()
    {
        var mpos = Input.mousePosition;
        mpos.x = (mpos.x / Screen.width * 2 - 1) * -power;
        mpos.y = (mpos.y / Screen.height * 2 - 1) * -power;
        Shader.SetGlobalVector("_MousePos", new Vector4(mpos.x, mpos.y, 0, 0));
    }
}