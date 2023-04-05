Shader "Learning/Unlit/Scrolling"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _ScrollingMap("Scrolling Map", 2D) = "white" {}
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _ScrollingMap;
			struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv: TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;   
                float3 worldSpacePos : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.wsPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return float4(1,0,0,0); 
            }
            
            ENDHLSL
        }
    }
}
