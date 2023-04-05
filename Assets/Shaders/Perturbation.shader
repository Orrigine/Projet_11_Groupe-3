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
        }
    }
}
