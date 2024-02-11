using System.Numerics;
using MyMath.Illumination.Interfaces;

namespace MyMath.Illumination.Implementations;
/// <summary>
/// Provides a method for calculating diffuse light.
/// 提供了一个用于计算漫反射光照的方法。
/// </summary>
public class DiffuseLightCalculator : IDiffuseLightCalculator
{
    /// <summary>
    /// Calculates the diffuse light based on the material color, normal vector, light vector, light intensity, and diffuse reflectivity.
    /// 根据材质颜色、法线向量、光照向量、光照强度和漫反射反射率来计算漫反射光照。
    /// </summary>
    /// <param name="materialColor">The color of the material. 材质的颜色。</param>
    /// <param name="normal">The normal vector. 法线向量。</param>
    /// <param name="lightVector">The light vector. 光照向量。</param>
    /// <param name="lightIntensity">The intensity of the light. 光照的强度。</param>
    /// <param name="diffuseReflectivity">The diffuse reflectivity of the material. 材质的漫反射反射率。</param>
    /// <returns>The color of the diffuse light. 漫反射光照的颜色。</returns>
    public Vector3 CalculateDiffuseLight(Vector3 materialColor, Vector3 normal, Vector3 lightVector, float? lightIntensity = null, float diffuseReflectivity = 1.0f)
    {
        
        Vector3 lightDirection = Vector3.Normalize(lightVector);
        float actualLightIntensity = lightIntensity ?? lightVector.Length();
        float dotProduct = Math.Max(Vector3.Dot(normal, lightDirection), 0);
        return diffuseReflectivity * actualLightIntensity * dotProduct * materialColor;
    }
}