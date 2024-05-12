using UnityEngine;
using Firebase;
using Firebase.Storage;
using System.Collections;
using System.Threading.Tasks;

public class MatMake : MonoBehaviour
{
    public Material material;
    public string mainImagePath;
    public string normalImagePath;
    private FirebaseStorage storage;

    void Start()
    {
        // Firebase 초기화
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            storage = FirebaseStorage.DefaultInstance;
        });
    }

    public void LoadImagesFromFirebase()
    {
        StartCoroutine(LoadImage(mainImagePath, texture =>
        {
            // 메인 텍스처(Base Map)에 이미지 적용
            material.mainTexture = texture;
        }));

        StartCoroutine(LoadImage(normalImagePath, texture =>
        {
            // 노말 맵(Normal Map)에 이미지 적용
            material.SetTexture("_BumpMap", texture);
        }));
    }

    private IEnumerator LoadImage(string imagePath, System.Action<Texture2D> callback)
    {
        // Firebase Storage에서 이미지 다운로드
        StorageReference storageRef = storage.GetReferenceFromUrl(imagePath);
        Task<byte[]> task = storageRef.GetBytesAsync(1024 * 1024); // 1MB 제한

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Failed to download image: " + task.Exception);
            yield break;
        }

        // 이미지 텍스처 생성
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(task.Result);

        // 콜백 호출
        callback(texture);
    }
}