#version 330
uniform sampler2D s_texture;
uniform float time;
uniform vec3 shockParams = vec3(10.0, 0.3, 0.1);

in vec2 texCoord;

void main()
{
	float t = time - int(time);
	float ti = time - t;	

	vec2 center = vec2(0.5 + 0.5 * sin(ti*10), 0.5 + 0.5 * cos(ti*100));


	vec2 uv = texCoord;
	float distance = distance(texCoord, center);
	if(abs(t - distance) < shockParams.z)
	{
		float diff = (distance - t); 
		float powDiff = 1.0 - pow(abs(diff*shockParams.x), shockParams.y); 
		float diffTime = diff  * powDiff; 
		vec2 diffUV = normalize(texCoord - center); 
		uv = uv + (diffUV * diffTime);
	}

    vec4 color = texture2D(s_texture, uv);
	gl_FragColor = color;
}