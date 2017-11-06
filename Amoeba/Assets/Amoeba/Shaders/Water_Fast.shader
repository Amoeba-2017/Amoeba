// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:6558,x:33752,y:32940,varname:node_6558,prsc:2|diff-5769-OUT,spec-8306-RGB,alpha-4919-OUT,refract-213-OUT,voffset-213-OUT;n:type:ShaderForge.SFN_Tex2d,id:6901,x:33223,y:32890,ptovrint:False,ptlb:node_6901,ptin:_node_6901,varname:node_6901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1321-UVOUT;n:type:ShaderForge.SFN_Color,id:8939,x:33339,y:33094,ptovrint:False,ptlb:node_8939,ptin:_node_8939,varname:node_8939,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2901961,c2:0.3960784,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Multiply,id:5769,x:33523,y:32980,varname:node_5769,prsc:2|A-6901-RGB,B-8939-RGB;n:type:ShaderForge.SFN_ComponentMask,id:7946,x:33313,y:33301,varname:node_7946,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8735-RGB;n:type:ShaderForge.SFN_Panner,id:5254,x:32929,y:33092,varname:node_5254,prsc:2,spu:1,spv:1|UVIN-5933-UVOUT;n:type:ShaderForge.SFN_Slider,id:3174,x:32587,y:33484,ptovrint:False,ptlb:node_3174,ptin:_node_3174,varname:node_3174,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:1,max:3;n:type:ShaderForge.SFN_Tex2d,id:8735,x:33126,y:33186,ptovrint:False,ptlb:node_8735,ptin:_node_8735,varname:node_8735,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-5254-UVOUT;n:type:ShaderForge.SFN_Vector1,id:4919,x:33544,y:33203,varname:node_4919,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Time,id:9215,x:32543,y:33328,varname:node_9215,prsc:2;n:type:ShaderForge.SFN_Multiply,id:213,x:33544,y:33364,varname:node_213,prsc:2|A-7946-OUT,B-2425-OUT;n:type:ShaderForge.SFN_Multiply,id:1398,x:32817,y:33295,varname:node_1398,prsc:2|A-9215-TSL,B-3174-OUT;n:type:ShaderForge.SFN_TexCoord,id:5933,x:32674,y:33174,varname:node_5933,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:2425,x:33289,y:33576,ptovrint:False,ptlb:node_2425,ptin:_node_2425,varname:node_2425,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:0.1593571,max:3;n:type:ShaderForge.SFN_Color,id:8306,x:33510,y:32780,ptovrint:False,ptlb:node_8306,ptin:_node_8306,varname:node_8306,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8970588,c2:0.8179976,c3:0.3759732,c4:1;n:type:ShaderForge.SFN_Panner,id:1321,x:32985,y:32836,varname:node_1321,prsc:2,spu:0,spv:1|UVIN-1971-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1971,x:32762,y:32725,varname:node_1971,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Divide,id:7502,x:32778,y:32921,varname:node_7502,prsc:2|A-3807-TSL,B-985-OUT;n:type:ShaderForge.SFN_RemapRange,id:985,x:32570,y:32986,varname:node_985,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2438-OUT;n:type:ShaderForge.SFN_Slider,id:2438,x:32230,y:33055,ptovrint:False,ptlb:node_2438,ptin:_node_2438,varname:node_2438,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7008547,max:1;n:type:ShaderForge.SFN_Time,id:3807,x:32387,y:32873,varname:node_3807,prsc:2;proporder:6901-8939-3174-8735-2425-8306-2438;pass:END;sub:END;*/

Shader "Custom/waterfall" {
    Properties {
        _node_6901 ("node_6901", 2D) = "white" {}
        _node_8939 ("node_8939", Color) = (0.2901961,0.3960784,0.5019608,1)
        _node_3174 ("node_3174", Range(-3, 3)) = 1
        _node_8735 ("node_8735", 2D) = "white" {}
        _node_2425 ("node_2425", Range(-3, 3)) = 0.1593571
        _node_8306 ("node_8306", Color) = (0.8970588,0.8179976,0.3759732,1)
        _node_2438 ("node_2438", Range(0, 1)) = 0.7008547
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _node_6901; uniform float4 _node_6901_ST;
            uniform float4 _node_8939;
            uniform sampler2D _node_8735; uniform float4 _node_8735_ST;
            uniform float _node_2425;
            uniform float4 _node_8306;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_2607 = _Time;
                float2 node_5254 = (o.uv0+node_2607.g*float2(1,1));
                float4 _node_8735_var = tex2Dlod(_node_8735,float4(TRANSFORM_TEX(node_5254, _node_8735),0.0,0));
                float2 node_213 = (_node_8735_var.rgb.rg*_node_2425);
                v.vertex.xyz += float3(node_213,0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_2607 = _Time;
                float2 node_5254 = (i.uv0+node_2607.g*float2(1,1));
                float4 _node_8735_var = tex2D(_node_8735,TRANSFORM_TEX(node_5254, _node_8735));
                float2 node_213 = (_node_8735_var.rgb.rg*_node_2425);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + node_213;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = _node_8306.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float2 node_1321 = (i.uv0+node_2607.g*float2(0,1));
                float4 _node_6901_var = tex2D(_node_6901,TRANSFORM_TEX(node_1321, _node_6901));
                float3 diffuseColor = (_node_6901_var.rgb*_node_8939.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,0.5),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _node_6901; uniform float4 _node_6901_ST;
            uniform float4 _node_8939;
            uniform sampler2D _node_8735; uniform float4 _node_8735_ST;
            uniform float _node_2425;
            uniform float4 _node_8306;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1325 = _Time;
                float2 node_5254 = (o.uv0+node_1325.g*float2(1,1));
                float4 _node_8735_var = tex2Dlod(_node_8735,float4(TRANSFORM_TEX(node_5254, _node_8735),0.0,0));
                float2 node_213 = (_node_8735_var.rgb.rg*_node_2425);
                v.vertex.xyz += float3(node_213,0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_1325 = _Time;
                float2 node_5254 = (i.uv0+node_1325.g*float2(1,1));
                float4 _node_8735_var = tex2D(_node_8735,TRANSFORM_TEX(node_5254, _node_8735));
                float2 node_213 = (_node_8735_var.rgb.rg*_node_2425);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + node_213;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = _node_8306.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_1321 = (i.uv0+node_1325.g*float2(0,1));
                float4 _node_6901_var = tex2D(_node_6901,TRANSFORM_TEX(node_1321, _node_6901));
                float3 diffuseColor = (_node_6901_var.rgb*_node_8939.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 0.5,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_8735; uniform float4 _node_8735_ST;
            uniform float _node_2425;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_5049 = _Time;
                float2 node_5254 = (o.uv0+node_5049.g*float2(1,1));
                float4 _node_8735_var = tex2Dlod(_node_8735,float4(TRANSFORM_TEX(node_5254, _node_8735),0.0,0));
                float2 node_213 = (_node_8735_var.rgb.rg*_node_2425);
                v.vertex.xyz += float3(node_213,0.0);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
