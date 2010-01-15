float4 k=float4(1,1,0,0);
float4 uv=float4(1,1,0,0);
float4x4 viewProj;
float4x4 world;

texture tex;
sampler MeshTextureSampler =sampler_state
{
 Texture = <tex>;       
}; 

struct VertexToPixel
{
    float4 p  : POSITION0;
    float2 t  : TEXCOORD0;
};

VertexToPixel VS(float4 p : POSITION0,float2 t:TEXCOORD0)
{
 VertexToPixel OUT = (VertexToPixel)0;
 
 OUT.p = mul(p, world);
 OUT.p.xy = OUT.p.xy * k.xy + k.zw;
 OUT.p = mul(OUT.p, viewProj);
 OUT.t = t*uv.xy + uv.zw;

 return OUT;
}

float4 PS(VertexToPixel IN) : COLOR
{ 
 return tex2D(MeshTextureSampler, IN.t);
} 

technique simple
{
    pass p0
    {
     vertexshader = compile vs_2_0 VS();
     pixelshader  = compile ps_2_0 PS();
    }
}