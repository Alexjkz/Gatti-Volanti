
using UnityEngine;

public class ResolutionScaler : MonoBehaviour
{
    public int targetWidth = 800;
    public int targetHeight = 600;

    private Camera mainCamera;
    private RenderTexture renderTexture;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        renderTexture = new RenderTexture(targetWidth, targetHeight, 24);
        mainCamera.targetTexture = renderTexture;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination);
    }

    void OnDestroy()
    {
        mainCamera.targetTexture = null;
        Destroy(renderTexture);
    }
}