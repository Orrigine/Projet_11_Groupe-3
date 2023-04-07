Shader "Learning/Unlit/Rayure"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Albedo0("Texture", 2D) = "white" {}
        _MainColor("Main Color", Color) = (0.1,0.5,0.3)
        _Speed("Scrolling speed", float) = 1
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

            sampler2D _Albedo0;
            float4 _MainColor;
            float _Speed;
			
            struct vertexInput
            {
                float4 vertex : POSITION;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;   
                float worldSpacePos : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).y + _Speed * _Time.y;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float texelColor = tex2D(_Albedo0, float2(0, i.worldSpacePos)).r;
                if (texelColor < 0.05)
                    discard;

                return _MainColor;
            }
            
            ENDHLSL
        }
    }
}
