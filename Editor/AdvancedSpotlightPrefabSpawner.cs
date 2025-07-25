#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEssentials
{
    public class AdvancedSpotlightPrefabSpawner
    {
        [MenuItem("GameObject/Essentials/Advanced Spot Light", false, priority = 121)]
        private static void InstantiateAdvancedSpotLight(MenuCommand menuCommand)
        {
            var prefab = ResourceLoaderEditor.InstantiatePrefab("UnityEssentials_Prefab_AdvancedSpotLight", "Advanced Spot Light");
            if (prefab != null)
            {
                var spotlight = prefab.GetComponent<AdvancedSpotLight>();

                spotlight.MainLight = prefab.GetComponent<Light>();
                spotlight.MainLightData = prefab.GetComponent<HDAdditionalLightData>();

                spotlight.RedLight = prefab.transform.Find("Red Channel").GetComponent<Light>();
                spotlight.RedLightData = spotlight.RedLight.GetComponent<HDAdditionalLightData>();
                spotlight.RedLightData.gameObject.hideFlags = HideFlags.HideInHierarchy;

                spotlight.GreenLight = prefab.transform.Find("Green Channel").GetComponent<Light>();
                spotlight.GreenLightData = spotlight.GreenLight.GetComponent<HDAdditionalLightData>();
                spotlight.GreenLightData.gameObject.hideFlags = HideFlags.HideInHierarchy;

                spotlight.BlueLight = prefab.transform.Find("Blue Channel").GetComponent<Light>();
                spotlight.BlueLightData = spotlight.BlueLight.GetComponent<HDAdditionalLightData>();
                spotlight.BlueLightData.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }

            GameObjectUtility.SetParentAndAlign(prefab, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(prefab, "Create Advanced Spot Light");
            Selection.activeObject = prefab;
        }
    }
}
#endif