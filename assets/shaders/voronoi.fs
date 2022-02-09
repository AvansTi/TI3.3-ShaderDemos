uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;
in vec3 color;


const float count = 150.;


vec2 Hash22(vec2 i)
{
	vec3 a = fract(i.xyx  * vec3(123.456, 234.789, 456.123));
    a += dot(i, i+12.456);
	return fract(vec2(a.x*a.y, a.y*a.z));
}
vec3 hsv2rgb(vec3 c)
{
    vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 p = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
    return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    vec2 uv = fragCoord*10.;

    vec3 col = vec3(0,0,0);
    
    float minDist = 10000.;
    float color = 1.;
    
    for(float i = 0.; i < count; i++) {
      	vec2 pos = Hash22(vec2(i/count));
 		
        pos = sin(pos*time*.1) * 10;
        
        float dist = length(uv-pos);
        
        if(dist < minDist) {
	        minDist = dist;
            color = i;
        }
        col+=vec3(smoothstep(0.02,0.01,dist));

    }
    //col = vec3(1.-minDist);
    col += hsv2rgb(vec3(color/count,1.,1.));
    
    // Output to screen
    fragColor = vec4(col,1.0);
}


void main()
{
    vec4 color;
    mainImage(color, texCoord);

	gl_FragColor = color;
}

