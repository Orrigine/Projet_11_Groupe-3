Shader "Shaders/WorldXColor"
{
    Properties{
        _MainTex("Albedo", 2D) = "white" {} _ScrollSpeed("Scroll Speed", Range(0, 1)) = 0.5}

    SubShader
    {
        Tags{"RenderType" = "Opaque"}

        Pass
        {
            HLSLPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

            sampler2D _MainTex;
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
                o.uv = v.uv + float2(_Speed.x * _Time.y, _Speed.y * _Time.y);

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }

            ENDHLSL
        }
    }
}
