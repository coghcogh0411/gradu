using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Storage;
using UnityEngine.UI;
public class firebaseimage : MonoBehaviour
{
    public RawImage rawImage;
    FirebaseStorage storage;
    // Start is called before the first frame update
    void Start()
    {
        // Firebase 초기화
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                // Firebase Storage 인스턴스 초기화
                storage = FirebaseStorage.DefaultInstance;
                Debug.Log("Firebase initialized successfully.");

                GetImageURL();
            }
            else
            {
                Debug.LogError("Failed to initialize Firebase: " + task.Exception);
            }
        });
        
    }
    public void GetImageURL()
    {
        if (storage == null)
        {
            Debug.LogError("Firebase Storage is not initialized.");
            return;
        }

        // 이미지의 참조 가져오기
        StorageReference imageRef = storage.GetReferenceFromUrl("gs://graduation-5bbb7.appspot.com/qwe (1).jpeg");

        // 이미지의 다운로드 URL 가져오기
        imageRef.GetDownloadUrlAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Failed to get download URL: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                string imageUrl = task.Result.ToString();
                Debug.Log("Image URL: " + imageUrl);

                // 다운로드한 이미지를 Raw Image에 적용
                LoadImage(imageUrl);
            }
        });
    }

    public void LoadImage(string imageUrl)
    {
        StartCoroutine(LoadImageCoroutine(imageUrl));
    }

    IEnumerator LoadImageCoroutine(string imageUrl)
    {
        // 이미지 다운로드
        using (WWW www = new WWW(imageUrl))
        {
            yield return www;

            if (www.error != null)
            {
                Debug.LogError("Failed to download image: " + www.error);
            }
            else
            {
                // 텍스처 생성
                Texture2D texture = new Texture2D(2, 2);
                www.LoadImageIntoTexture(texture);

                // Raw Image에 적용
                rawImage.texture = texture;
            }
        }
    }
}