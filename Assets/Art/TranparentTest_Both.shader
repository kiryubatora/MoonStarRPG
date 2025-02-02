// 透明物体，阴影
Shader "Unlit/AlphaBlendWithShadow"
{
    Properties
    {
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Main Tex", 2D) = "white" { }// 主纹理
        _AlphaScale ("Alpha Scale", Range(0, 1)) = 1 // 透明度
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }

        pass
        {
            Tags { "LightMode" = "ForwardBase" }

            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            
            // 编译指令，保证在pass中得到Pass中得到正确的光照变量
            #pragma multi_compile_fwdbase

            #pragma vertex vert
            #pragma fragment frag

            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            fixed4 _Color;
            sampler2D _MainTex;
            // _MainTex_ST(声明方式：name_ST): 声明_MainTex是一张采样图，用于uv运算, 下面2个是等价的
            // o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
            // o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
            // 如果没有声明是不能进行TRANSFORM_TEX的运算的。_MainTex_ST.xy为纹理图Tiling(缩放), zw为纹理中的offset(偏移)
            // 如果Tiling 和 Offset留的是默认值，即Tiling为（1，1） Offset为（0，0）的时候，可以不用TRANSFORM_TEX运算
            // 即：o.uv = v.texcoord
            fixed4 _MainTex_ST;
            fixed _AlphaScale;

            // 应用传递给顶点着色器的数据
            struct a2v
            {
                float4 vertex: POSITION; // 语义: 顶点坐标
                float3 normal: NORMAL; // 语义：法线
                float4 texcoord: TEXCOORD0; // 语义：第一组纹理的坐标
            };

            // 顶点着色器传递给片元着色器的数据
            struct v2f
            {
                float4 pos: SV_POSITION; // 语义：裁剪空间的顶点坐标
                float3 worldNormal: TEXCOORD0;
                float3 worldPos: TEXCOORD1;
                float2 uv: TEXCOORD2;
                SHADOW_COORDS(3) // 声明一个用于对阴影纹理采样的坐标 (这个宏参数需要是下一个可用的插值寄存器的索引值，这里是3)
            };

            // 顶点着色器
            v2f vert(a2v v)
            {
                v2f o;

                // 将顶点坐标从模型空间变换到裁剪空间
                // 等价于o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);

                // 将法线从模型空间变换到世界空间
                // 等价于o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);

                // 将顶点坐标从模型空间变换到世界空间
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                // 计算纹理坐标 (缩放和平移)
                // 等价于o.uv = v.texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

                // 计算声明的阴影纹理坐标
                TRANSFER_SHADOW(o);

                return o;
            }

            // 片元着色器
            fixed4 frag(v2f i): SV_TARGET
            {
                fixed3 worldNormal = normalize(i.worldNormal);

                // 世界空间光向量
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

                // 对纹理进行采样
                fixed4 texColor = tex2D(_MainTex, i.uv);

                fixed3 albedo = texColor.rgb * _Color.rgb;

                // 环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

                // 漫反射
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));

                // 计算阴影和光照衰减
                UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);

                return fixed4(ambient + diffuse * atten, texColor.a * _AlphaScale);
            }
            
            ENDCG
            
        }
    }

    FallBack "Transparent/VertexLit"
    // 或者强制投射阴影
    // FallBack "VertexLit"
}
