#version 330
uniform sampler2D s_texture;
uniform vec3 cameraPos;

in vec3 color;
in vec2 texCoord;
in vec3 normal;
in vec3 position;
layout(location = 0) out vec4 fragColor;
layout(location = 1) out vec4 fragColor2;


void main()
{
	vec3 lightDirection = normalize(vec3(1,1,1));

	float diffuse = dot(normalize(normal), lightDirection);
	float ambient = 0.3;
	float specular = pow(max(0.0, 
			dot(
				reflect(-lightDirection, normalize(normal)), 
				normalize(cameraPos-position)
			)), 100);
	if(dot(normal, lightDirection) < 0)
		specular = 0;

if(diffuse < 0)
	diffuse = 0;

	float lighting = clamp(ambient + 0.7 * diffuse + specular,0,1);

	vec4 texColor = texture2D(s_texture, texCoord);
	

	texColor *= vec4(lighting, lighting, lighting, 1);

	fragColor = texColor;
	fragColor2 = vec4(1,1,1,1);
}