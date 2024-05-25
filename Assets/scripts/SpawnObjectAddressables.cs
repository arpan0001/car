using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnObjwcAddressables : MonoBehaviour
{
    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetLabelReference assetLabelReference;

    private bool isInstantiated = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isInstantiated)
        {
            isInstantiated = true;
            assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("GameObject instantiated successfully");
                }
                else
                {
                    Debug.Log("Failed to instantiate GameObject!");
                    isInstantiated = false; // Reset the flag if instantiation fails
                }
            };

            // Uncomment this block if you want to load assets using assetLabelReference
            /*
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference.labelString).Completed +=
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperationHandle.Result);
                        isInstantiated = true;
                    }
                    else
                    {
                        Debug.Log("Failed to load!");
                    }
                };
            */
        }
    }
}
