#version 330
uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;
in vec3 color;

layout(location = 0) out vec4 fragColor;
layout(location = 1) out vec4 fragColor2;


void main()
{
	vec4 texColor = texture(s_texture, texCoord);

	fragColor = texColor;
	if(int(time) % 5 == 0)
		fragColor2 = vec4(1,0,0,1);
	else
		fragColor2 = vec4(0,1,0,1);
}