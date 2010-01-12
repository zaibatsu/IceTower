xof 0303txt 0032
template FVFData {
 <b6e70a0e-8ef9-4e83-94ad-ecc8b0c04897>
 DWORD dwFVF;
 DWORD nDWords;
 array DWORD data[nDWords];
}

template EffectInstance {
 <e331f7e4-0559-4cc2-8e99-1cec1657928f>
 STRING EffectFilename;
 [...]
}

template EffectParamFloats {
 <3014b9a0-62f5-478c-9b86-e4ac9f4e418b>
 STRING ParamName;
 DWORD nFloats;
 array FLOAT Floats[nFloats];
}

template EffectParamString {
 <1dbc4c88-94c1-46ee-9076-2c28818c9481>
 STRING ParamName;
 STRING Value;
}

template EffectParamDWord {
 <e13963bc-ae51-4c5d-b00f-cfa3a9d97ce5>
 STRING ParamName;
 DWORD Value;
}


Material PDX01_-_Default {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

}

Frame Plane01 {
 

 FrameTransformMatrix {
  1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.500000,0.500000,0.000000,1.000000;;
 }

 Mesh  {
  6;
  -0.500000;0.500000;-1.000000;,
  -0.500000;-0.500000;-1.000000;,
  0.500000;0.500000;-1.000000;,
  0.500000;-0.500000;-1.000000;,
  0.500000;0.500000;-1.000000;,
  -0.500000;-0.500000;-1.000000;;
  2;
  3;0,1,2;,
  3;3,4,5;;

  MeshNormals  {
   6;
   -0.000000;-0.000000;-1.000000;,
   -0.000000;-0.000000;-1.000000;,
   -0.000000;-0.000000;-1.000000;,
   -0.000000;-0.000000;-1.000000;,
   -0.000000;-0.000000;-1.000000;,
   -0.000000;-0.000000;-1.000000;;
   2;
   3;0,1,2;,
   3;3,4,5;;
  }

  MeshMaterialList  {
   1;
   2;
   0,
   0;
   { PDX01_-_Default }
  }

  MeshTextureCoords  {
   6;
   0.000000;0.000000;,
   0.000000;1.000000;,
   1.000000;0.000000;,
   1.000000;1.000000;,
   1.000000;0.000000;,
   0.000000;1.000000;;
  }
 }
}