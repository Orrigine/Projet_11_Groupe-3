Shader "Shaders/Plants"
{
    Properties
    {
        _Mesh("Mesh", 2D) = "white" {}
    }

    SubShader
    {
        Tags{"RenderType" = "Opaque"
                            "Queue" = "Geometry"}

        Pass
        {
            Cull Off
                HLSLPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

                    sampler2D _Mesh;

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
                o.uv = v.uv;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 texelColor = tex2D(_Mesh, i.uv);
                if (texelColor.a < 0.05)
                    discard;
                return texelColor;
            }

            ENDHLSL
        }
    }
}
