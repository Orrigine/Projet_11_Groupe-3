Shader "Learning/Unlit/TO RENAME"
{
    Properties
    {
        _DisturbedFactor("Disturbed Factor", Range(0, 1)) = 0.5 _MainTex("Texture", 2D) = "white" {}
        _NoiseMap("Noise Map", 2D) = "white" {}
        _Speed("Speed", float4) = { 0.1,
                                    0.1,
                                    0,
                                    0 }
    }

    SubShader
    {
        Tags{"RenderType" = "Opaque"
                            "Queue" = "Geometry"}

        Pass
        {
            HLSLPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _NoiseMap;
            float _DisturbedFactor;
            float2 _Speed;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(vertexInput v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 offset = _Speed * i.uv;
                float2 noise = tex2D(_NoiseMap, i.uv + offset).rb;
                noise *= _DisturbedFactor;

                return tex2D(_MainTex, i.uv + noise);
            }

            ENDHLSL
        }Assets/Materials/AnimTex.mat
        new file:   Assets/Materials/AnimTex.mat.meta
        new file:   Assets/Materials/MaterialPlants.mat
        new file:   Assets/Materials/MaterialPlants.mat.meta
        new file:   Assets/Materials/Perturbation.mat
        new file:   Assets/Materials/Perturbation.mat.meta
        renamed:    Assets/Materials/WorldXColor.mat -> Assets/Materials/Plants.mat
        new file:   Assets/Materials/Plants.mat.meta
        new file:   Assets/Materials/ShaderGraph.mat
        new file:   Assets/Materials/ShaderGraph.mat.meta
        new file:   Assets/Materials/T_Plants_d.mat
        new file:   Assets/Materials/T_Plants_d.mat.meta
        new file:   Assets/Meshes.meta
        new file:   Assets/Meshes/3D Models.meta
        new file:   Assets/Meshes/3D Models/SM_Fern_01.FBX
        new file:   Assets/Meshes/3D Models/SM_Fern_01.FBX.meta
        new file:   Assets/Meshes/3D Models/SM_plant_01.FBX
        new file:   Assets/Meshes/3D Models/SM_plant_01.FBX.meta
        new file:   Assets/Noise Map.meta
        new file:   Assets/Noise Map/T_Distortion.png
        new file:   Assets/Noise Map/T_Distortion.png.meta
        modified:   Assets/Scenes/SampleScene.unity
        modified:   Assets/Settings/URP-Balanced.asset
        modified:   Assets/Settings/URP-Performant.asset
        new file:   Assets/Shaders/Perturbation.shader
        new file:   Assets/Shaders/Perturbation.shader.meta
        new file:   Assets/Shaders/Plants.shader
        new file:   Assets/Shaders/Plants.shader.meta
        new file:   Assets/Shaders/ShaderGraph.meta
        new file:   Assets/Shaders/ShaderGraph/Ref.shadergraph
        new file:   Assets/Shaders/ShaderGraph/Ref.shadergraph.meta
        modified:   Assets/Shaders/WorldXColor.shader
        new file:   Assets/Textures/T_Plants_d.TGA
        new file:   Assets/Textures/T_Plants_d.TGA.meta
    }
}
