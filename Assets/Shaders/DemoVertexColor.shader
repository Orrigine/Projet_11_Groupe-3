Shader "Learning/Unlit/DemoVertexColor"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }

		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            //Data de chaque vertex 			
			struct vertexInput
            {
                float4 vertex : POSITION;						
                float4 vertexColor : COLOR;
            };
			
            // v2f => vertex to fragment
            // Chaque élément doit être calculé dans le vertex shader
            // Toutes ces variables seront interpolées par le rasterizer et reçues en entrée du fragment shader
            struct v2f //vertexOutput
            {
                float4 vertex : SV_POSITION;   
                float4 vertexColor : COLOR;
            };


            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.vertexColor = v.vertexColor;
                return o;
            }

            // RASTERIZER

            float4 frag(v2f i) : SV_Target
            {
                return i.vertexColor; 
            }
            
            ENDHLSL
        }
    }
}
