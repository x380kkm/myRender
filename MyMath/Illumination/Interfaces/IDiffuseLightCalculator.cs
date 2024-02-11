using System.Numerics;
namespace MyMath.Illumination.Interfaces;

/// <summary>
/// Defines a method for calculating diffuse light.
/// 定义了一个用于计算漫反射光照的方法。
/// </summary>
public interface IDiffuseLightCalculator
{   /// <summary>
    /// Calculates the diffuse light based on the material color, normal vector, light vector, light intensity, and diffuse reflectivity.
    /// 根据材质颜色、法线向量、光照向量、光照强度和漫反射反射率来计算漫反射光照。
    /// </summary>
    Vector3 CalculateDiffuseLight(Vector3 materialColor, Vector3 normal, Vector3 lightVector, float? lightIntensity = null, float diffuseReflectivity = 1.0f);
}