Shader "Shaders/WorldXColor"
{
    Properties{
        _Albedo0("Albedo", 2D) = "white" {} _ScrollSpeed("Scroll Speed", Range(0, 1)) = 0.5}

    SubShader
    {
        Tags{"RenderType" = "Opaque"}

        Pass
        {
            HLSLPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

            sampler2D _Albedo0;

            struct vertexInput
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldSpacePos : TEXCOORD0;
                float4 uv : TEXCOORD1;
            };

            v2f vert(vertexInput v)
            {
                v2f o;
                o.uv = v.uv;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return tex2D(_Albedo0, (i.uv + _Time.y) * _ScrollSpeed);
            }

            ENDHLSL
        }
    }
}
